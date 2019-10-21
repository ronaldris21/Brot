using BrotVendedor.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace BrotVendedor.Class
{
    public class PickPhotoAsync
    {
        private MediaFile _mediaFile;
        public static String name;
        public static ImageSource path;
        public async void ChangePicture()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No es posible elegir una foto", "Aceptar");
                return;
            }
            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile == null)
            {
                return;
            }
            name = _mediaFile.Path.Split('/').LastOrDefault();
            var resp = await App.Current.MainPage.DisplayAlert("Confirmacion", "Desea utilizar esta imagen", "Aceptar", "Cancelar");
            if (resp)
            {
                if (Singleton.fromProfile)
                {
                    Singleton.current.user.img = name;
                }
                path = ImageSource.FromStream(() =>
                {
                    return _mediaFile.GetStream();
                });
                UploadImage();
            }
        }
        private async void UploadImage()
        {
            //metodo para publicar la imagen en el servidor web
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(_mediaFile.GetStream()), "\"file\"", $"\"{_mediaFile.Path}\"");
                var httpClient = new HttpClient();
                var uploadServiceBaseAddress = "http://images.somee.com/api/Files/Upload";
                var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
                Debug.Print(await httpResponseMessage.Content.ReadAsStringAsync());
                //await DisplayAlert("Exito", await httpResponseMessage.Content.ReadAsStringAsync(), "Aceptar");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
            }
        }
    }
}
