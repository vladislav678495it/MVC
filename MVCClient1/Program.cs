using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTriangle;

namespace MVCClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleModel tm1 = new TriangleModel();

            IObserver tv1 = new TriangleDigitalView(tm1, null, 40, 80, 1, 20);
            tm1.AddObserver(tv1);

            IObserver tv2 = new PictureView(tm1, null, 1, 39, 1, 20);
            tm1.AddObserver(tv2);

            tm1.A = 3;
            Console.Read();
            tm1.B = 4;
            Console.Read();
            tm1.C = 5; Console.Read();
            tm1.A = 5; Console.Read();
        }
    }
}
