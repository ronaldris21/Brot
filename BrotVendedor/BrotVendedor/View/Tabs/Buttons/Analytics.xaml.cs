using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

namespace BrotVendedor.View.Tabs.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Analytics : ContentPage
    {
        List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(212)
            {
                Label = "Brots",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new Microcharts.Entry(248)
            {
                Label = "Comentarios",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new Microcharts.Entry(128)
            {
                Label = "Vistas",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            }
            };
        public Analytics()
        {
            InitializeComponent();
            Chart1.Chart = new BarChart { Entries = entries, LabelTextSize = 35 };
            //Chart1.Chart = new LineChart { Entries = entries , LabelTextSize=35,PointMode=PointMode.Square};
        }
    }
}