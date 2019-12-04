using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTriangle
{
    public class Controller
    {
        TriangleModel tm;
        public Controller(TriangleModel tm)
        {
            this.tm = tm;
        }
        public void PerimeterAdjustment(double p)
        {
            Random rnd = new Random();
            tm.A = rnd.NextDouble() * p / 2;
            tm.B = rnd.NextDouble() * p / 2;
            tm.C = p - tm.A - tm.B;
        }
        private double AreaAdjustment (double p)
        {
            double s = Math.Sqrt(p*(p-tm.A)*(p-tm.B)*(p-tm.C));
            return s;
        }
    }
}
