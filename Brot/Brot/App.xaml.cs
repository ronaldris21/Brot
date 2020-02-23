namespace Brot
{
    using AsyncAwaitBestPractices;
    using Brot.Patterns;
    using Brot.Services;
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;
    using Microsoft.AppCenter.Push;
    using Plugin.LocalNotification;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Views;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

    public partial class App : Xamarin.Forms.Application
    {
        private bool DentroApp { get; set; }
        Stopwatch stopwatch = new Stopwatch();
        long tiempo;
        public App(long tiempo)
        {
            this.tiempo = tiempo;
            Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            stopwatch.Start();
            InitializeComponent();

            CheckStoragePermissions();
            DentroApp = true;
            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += Push_PushNotificationReceived;
            }
            inicializar();
        }

        private async void CheckStoragePermissions()
        {
            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            //await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        }
        private void inicializar()
        {
            string BarBackgroundColorHEX = "#031540";
            try
            {
                if (Singleton.Instance.isLoggued)
                {
                    MainPage = new NavigationPage(new MainTabbed())
                    {
                        BarBackgroundColor = Color.FromHex(BarBackgroundColorHEX)
                    };
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess("Bienvendo " + Singleton.Instance.User.username, Plugin.Toast.Abstractions.ToastLength.Long);
                }
                else
                {
                    MainPage = new NavigationPage(new Login())
                    {
                        BarBackgroundColor = Color.FromHex(BarBackgroundColorHEX)
                    };
                    Plugin.Toast.CrossToastPopUp.Current.ShowToastMessage("Brot Amigo - Inicia Sesión");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);

                //Capturo el error y lo mando a AppCenter antes que el app muera!!
                Crashes.TrackError(ex, new System.Collections.Generic.Dictionary<string, string>() {
                    {"AppStart", "Falló" }
                });

                MainPage = new NavigationPage(new Login())
                {
                    BarBackgroundColor = Color.FromHex(BarBackgroundColorHEX)
                };
            }

            //Know how much it takes the start up
            //MainPage.DisplayAlert("Tiempo Android", tiempo.ToString() + "  Milisegundos", "Ok");

        }




        private void Current_NotificationTapped(NotificationTappedEventArgs e)
        {
            try
            {
                if (MainPage == null || MainPage == default(Page))
                {
                    MainPage = new NavigationPage(new MainTabbed());
                }
                AccionNotificacion(Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(e.Data));
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new System.Collections.Generic.Dictionary<string, string>() {
                    {"Push Notification Local-Error","Error interpretandola" }
                });
            }
        }

        PushNotificationReceivedEventArgs lastNoti;
        public void Push_PushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            try
            {
                List<string> variables = new List<string>();
                foreach (var keyPair in e.CustomData)
                {
                    variables.Add(keyPair.Key + "," + keyPair.Value);
                }
                if (e == lastNoti) //Event activates more than once due to having two INTENT For Notifications!
                    return;

                if (DentroApp && !String.IsNullOrEmpty(e.Title))
                {
                    string data = Newtonsoft.Json.JsonConvert.SerializeObject(variables);
                    var r = new Random();

                    var notification = new NotificationRequest
                    {
                        NotificationId = r.Next(1, 50),
                        Title = e.Title,
                        Description = e.Message,
                        ReturningData = data // Returning data when tapped on notification.
                    };
                    NotificationCenter.Current.Show(notification);
                }
                else
                {
                    if (String.IsNullOrEmpty(e.Title))//For Some Reasons Push Notification Event is Activate Twice when Notification is Tapped
                    {
                        if (MainPage == null || MainPage == default(Page))
                        {
                            MainPage = new NavigationPage(new MainTabbed());
                        }
                        AccionNotificacion(variables);
                        DentroApp = true;
                    }
                }
            }
            catch (Exception ex)
            {

                Crashes.TrackError(ex, new System.Collections.Generic.Dictionary<string, string>() {
                    {"Push Notification AppCenter Error","Error interpretandola" }
                });
            }
            lastNoti = e;
        }

        private void AccionNotificacion(List<string> CustomData)
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
            {
                int id_user, id_comment, id_post;
                id_user = 1;
                id_comment = 1;
                id_post = 1;
                string gotoPage = String.Empty;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (var item in CustomData)
                {
                    var data = item.Split(",");
                    dic.Add(data[0], data[1]);
                }
                try
                {
                    gotoPage = dic[PushConstantes.gotoPage];
                }
                catch (Exception) { }
                try
                {
                    id_comment = Convert.ToInt32(dic[PushConstantes.id_comentario]);
                }
                catch (Exception) { }
                try
                {
                    id_user = Convert.ToInt32(dic[PushConstantes.id_user]);
                }
                catch (Exception) { }
                try
                {
                    id_post = Convert.ToInt32(dic[PushConstantes.id_post]);
                }
                catch (Exception) { }

                if (gotoPage == PushConstantes.goto_post)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Views.Post(new ViewModels.PostViewModel(id_post), id_user));
                }
                else if (gotoPage == PushConstantes.goto_profile)
                {
                    var perfil = await RestAPI.GetOtherUserrofile(id_user, Singleton.Instance.User.id_user).ConfigureAwait(false);
                    perfil.UserProfile.img = String.IsNullOrEmpty(perfil.UserProfile.img)
                                            ? DLL.constantes.ProfileImageError
                                            : DLL.constantes.urlImages + perfil.UserProfile.img;
                    await App.Current.MainPage.Navigation.PushAsync(new Views.SellerProfile(perfil.UserProfile)).ConfigureAwait(false);
                }
            });

        }

        #region AppCenter Initializers
        private async Task InitAppCenterPushAsync()
        {
            AppCenter.Start("android=ce90d30b-e395-4d05-be5b-a1461a3bec8e;" +
                          "ios=0caa730c-a7e0-45b2-82bb-302f376b133d",
                           typeof(Analytics), typeof(Crashes), typeof(Push));
            //NO AWAIT, Quiero que continue sin esperar a que termine
            //await System.Threading.Tasks.Task.WhenAll(Crashes.SetEnabledAsync(true),
            //                                          Push.SetEnabledAsync(true),
            //                                          Analytics.SetEnabledAsync(true))
            //    .ConfigureAwait(false);

            await Crashes.SetEnabledAsync(true).ConfigureAwait(false);
            await Analytics.SetEnabledAsync(true).ConfigureAwait(false);
            await Push.SetEnabledAsync(true).ConfigureAwait(false);

            bool pushestado = await Push.IsEnabledAsync().ConfigureAwait(false);

            //Registrar telefono en base de datos, así activo PUSH en el Dispositivo!
            var idInstalled02 = await Microsoft.AppCenter.AppCenter.GetInstallIdAsync().ConfigureAwait(false);
            string DeviceID = idInstalled02.Value.ToString();
            Analytics.TrackEvent("Device Name", new System.Collections.Generic.Dictionary<string, string>()
                            {
                                { "Device",DeviceID},
                                {Singleton.Instance.User.username, DeviceID }
                            });
            Singleton.Instance.User.Device_id = DeviceID;
            Singleton.Instance.User.Phone_OS = Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS ? "iOS" : "Android";
            await RestClient.Post<Models.userModel>("users/device", Singleton.Instance.User).ConfigureAwait(false);


        }
        private async Task InitAppCenterServicesAsync()
        {
            AppCenter.Start("android=ce90d30b-e395-4d05-be5b-a1461a3bec8e;" +
                          "ios=0caa730c-a7e0-45b2-82bb-302f376b133d",
                           typeof(Analytics), typeof(Crashes));
            //NO AWAIT, Quiero que continue sin esperar a que termine
            await Crashes.SetEnabledAsync(true).ConfigureAwait(false);
            await Analytics.SetEnabledAsync(true).ConfigureAwait(false);
        }
        #endregion

        #region System App Life Cycle

        protected override void OnStart()
        {

            if (Singleton.Instance.isLoggued)
            {
                InitAppCenterPushAsync().SafeFireAndForget();
            }
            else
            {
                InitAppCenterServicesAsync().SafeFireAndForget();
            }

            stopwatch.Stop();
            //MainPage.DisplayAlert("Tiempo App", stopwatch.ElapsedMilliseconds.ToString() + "  Milisegundos", "Ok");
        }
        protected override void OnSleep()
        {
            DentroApp = false;
        }

        protected override void OnResume()
        {
            DentroApp = true;
        }
        #endregion
    }
}
