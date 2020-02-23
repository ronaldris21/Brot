namespace Brot.Views.Tabs
{
    using System;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.GoogleMaps;
    using Plugin.Permissions.Abstractions;
    using Plugin.Permissions;
    using Xamarin.Forms.Xaml;
    using XamarinStyles;
    using Xamarin.Essentials;
    using Microsoft.AppCenter.Crashes;
    using System.Collections.Generic;
    using Brot.Services;
    using System.Threading.Tasks;
    using AsyncAwaitBestPractices;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellersMap : ContentPage
    {
        SellersMapViewModel ViewModel;

        public SellersMap()
        {

            InitializeComponent();
            BindingContext = this.ViewModel = new SellersMapViewModel(ref Mapa);
            Mapa.MyLocationButtonClicked += Mapa_MyLocationButtonClicked1;
            //Mapa.MapStyle = MapStyle.FromJson(new XamarinMapStyle().Text);
            XamarinMapStyle Style = new XamarinMapStyle();
            //this.Mapa.MapStyle = MapStyle.FromJson(Style.Text);

            //TODO pedir permisos y si no los acepta, entonces NO ABRIR EL MAPA, porque dar error en iOS

        }

        private void Mapa_MyLocationButtonClicked1(object sender, MyLocationButtonClickedEventArgs e)
        {
            Plugin.Toast.CrossToastPopUp.Current.ShowToastMessage("Estás aquí");
        }

        bool isFirst = true;
        protected override void OnAppearing()
        {

            base.OnAppearing();
            if (isFirst)
            {
                isFirst = false;
               

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    this.Mapa.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(
                            13.994778,
                            -89.556642
                            ),
                    Distance.FromMeters(4000)
                        )
                    );
                });
                //this.ViewModel.InitPinsCommand.Execute(null);
                ask4LocationPermisssionsAsync().ConfigureAwait(false); //Que no espere a que termine, NO AWAIT

            }
        }

        private Task ask4LocationPermisssionsAsync()
        {
            return MainThread.InvokeOnMainThreadAsync(async () =>
            {

                try
                {
                    PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                    PermissionStatus status2 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                    PermissionStatus status3 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);

                    if (status == PermissionStatus.Granted)
                    {
                        Mapa.MyLocationEnabled = true;
                        Mapa.UiSettings.MapToolbarEnabled = true;
                        Mapa.UiSettings.MyLocationButtonEnabled = true;
                        Mapa.UiSettings.CompassEnabled = true;
                        
                        await MoveToSantaAna();
                        return;
                    }
                    else if (status != PermissionStatus.Granted)
                    {
                        Mapa.MyLocationEnabled = false;
                        await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                        status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                    }

                    if (status == PermissionStatus.Granted)
                    {
                        //Query permission
                        Mapa.MyLocationEnabled = true;
                        await MoveToSantaAna();
                        return;
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        //location denied
                        Mapa.MyLocationEnabled = false;
                    }
                    else
                    {
                        Mapa.MyLocationEnabled = false;
                    }
                }
                catch (System.Exception ex)
                {
                    //Something went wrong
                    Crashes.TrackError(ex,
                        new Dictionary<string, string>() { { "Geolocalization", "Error" } });
                }
            });

        }


        private async Task MoveToSantaAna()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    await MainThread.GetMainThreadSynchronizationContextAsync(); //Trae de vuelta el MainThread
                        Mapa.MoveToRegion(
                                MapSpan.FromCenterAndRadius(
                                    new Position(
                                        location.Latitude,
                                        location.Longitude
                                        ),
                                Distance.FromMeters(3000)
                        ));

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Crashes.TrackError(fnsEx, new Dictionary<string, string>() { { "Mapa", "FeatureNotSupportedException" } });
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IGPSService>().turnOnGps();
                }
                Crashes.TrackError(fneEx, new Dictionary<string, string>() { { "Mapa", "FeatureNotEnabledException" } });
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Crashes.TrackError(pEx, new Dictionary<string, string>() { { "Mapa", "PermissionException" } });
            }
            catch (Exception ex)
            {
                // Unable to get location
                Crashes.TrackError(ex, new Dictionary<string, string>() { { "Mapa", "Exception" } });
            }

        }

        private void Mapa_PinClicked(object sender, PinClickedEventArgs e)
        {
            var pines = ((Xamarin.Forms.GoogleMaps.Map)sender).Pins;
            for (int i = 0; i < pines.Count; i++)
            {
                if (e.Pin.Equals(pines[i]))
                {
                    ViewModel.pinClicked.Execute(i);
                    return;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MoveToSantaAna().ConfigureAwait(false);
        }

        private void Mapa_MyLocationButtonClicked(object sender, MyLocationButtonClickedEventArgs e)
        {
            
        }
    }
}