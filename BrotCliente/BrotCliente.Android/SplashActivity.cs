

namespace BrotCliente.Droid
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using System.Threading.Tasks;
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        protected override void OnResume()
        {
            base.OnResume();
            Task.Run(() => SimulateStartupAsync());
            //Task startupWork = new Task(async () => { await SimulateStartupAsync(); });
        }

        private async Task SimulateStartupAsync()
        {
            await Task.Delay(2000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}