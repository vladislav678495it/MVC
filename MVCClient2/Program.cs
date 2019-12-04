using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTriangle;

namespace MVCClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleModel tm1 = new TriangleModel();
            Controller tc = new Controller(tm1);
            TriangleDigitalView tv1 = new TriangleDigitalView(tm1, tc, 40, 80, 1, 20);
            //tm1.AddObserver(tv1);

            IObserver tv2 = new PictureView(tm1, tc, 1, 39, 1, 20);
            //tm1.AddObserver(tv2);

            //аналог цикла обработки сообщений - Run
            bool exit = tv1.GetCommand();
            while (exit!=true)
            {
                exit = tv1.GetCommand();
            }
        }
    }
}
