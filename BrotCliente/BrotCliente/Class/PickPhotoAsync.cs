using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace BrotCliente.Class
{
    public class PickPhotoAsync
    {
        private MediaFile _mediaFile;
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
            
            var resp = await App.Current.MainPage.DisplayAlert("Confirmacion", "Desea que esta sea su foto de perfil?", "Aceptar", "Cancelar");
            if (resp)
            {
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
