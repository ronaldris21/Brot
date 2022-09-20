namespace Brot.Views
{
    using AsyncAwaitBestPractices;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class MainTabbed : TabbedPage
    {
        public MainTabbed()
        {
            InitializeComponent();

            //CreateTabbedPage().ConfigureAwait(false);



            ////TODO: Improve Feed Startup!
            Children.Add(new Tabs.Feed());

            Children.Add(new Tabs.SellersMap());
            Children.Add(new Tabs.BrotsTabbedxaml());
            //Children.Add(new Tabs.BrotTen());
            Children.Add(new Tabs.Profile());

            //CurrentPage = Children[1];

        }

        private async Task  CreateTabbedPage()
        {
            Page pag1, pag2, pag3, pag4;
            pag1 = pag2 = pag3 = pag4 = default(Page);

            Task t1 = Task.Run(() => pag1 = new Tabs.Feed());
            Task t2 = Task.Run(() => pag2 = new Tabs.SellersMap());
            Task t3 = Task.Run(() => pag3 = new Tabs.BrotsTabbedxaml());
            Task t4 = Task.Run(() => pag4 = new Tabs.Profile());

            await Task.WhenAll(t1, t2, t3, t4);

            Children.Add(pag1);
            Children.Add(pag2);
            Children.Add(pag3);
            Children.Add(pag4);

        }
    }
}