using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasConsola
{
    class algo
    {
        public int MyProperty { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            ObservableCollection<algo> var = new ObservableCollection<algo>(default(List<algo>));
            Console.WriteLine("asa");
            Console.ReadKey();

        }
    }
}
