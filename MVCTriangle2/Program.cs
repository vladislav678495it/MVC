using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTriangle1
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleModel tm1 = new TriangleModel();
            TriangleDigitalView tv1 = new TriangleDigitalView(tm1,40,80,1,20);
            tm1.AddObserver(tv1);
            tm1.A=  3; Console.Read();
            tm1.B = 4; Console.Read();
            tm1.C = 5; Console.Read();
            tm1.A=  4; Console.Read();
            tm1.B = 5; Console.Read();
            tm1.C = 6; Console.Read();
        }
    }

    interface IObserver
    {
        void Update();
    }
 
    interface ISubject
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class TriangleModel:ISubject
    {
        private double a, b, c;
        public double A
        {   get { return a; }
            set
            {   a = value;
                NotifyObservers();
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                b = value;
                NotifyObservers();
            }
        }
        public double C
        {
            get { return c; }
            set
            {
                c = value;
                NotifyObservers();
            }
        }
        private List<IObserver> views = new List<IObserver>();
        public double Perimeter
        { get { return A + B + C; } }
        public double Area
        { get
            {
                double pp = A + B + C;
                return Math.Sqrt(pp * (pp - A) * (pp - B) * (pp - C));
            }
        }
        public void AddObserver(IObserver o) { views.Add(o); }
        public void RemoveObserver(IObserver o) { views.Remove(o); }
        public void NotifyObservers()
        {
            foreach (IObserver o in views)
                o.Update();
        }

    }
}
