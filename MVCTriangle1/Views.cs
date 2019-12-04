using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTriangle
{
    public abstract class CursorDrivenView: IObserver
    {
        private TriangleModel tm1;
        protected Controller controller;
        protected int leftBound, rightBound;
        protected int topBound, bottomBound;
        public CursorDrivenView(TriangleModel tm1, Controller tc,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
        {
            this.tm1 = tm1;
            this.tm1.AddObserver(this);
            controller = tc;
            this.leftBound = leftBound;
            this.rightBound = rightBound;
            this.topBound = topBound;
            this.bottomBound = bottomBound;
        }
        public void SetController(Controller c)
        { controller = c; }
        public abstract void Update();
    }
    public class TriangleDigitalView : CursorDrivenView, IObserver
    {
        private SourceParamView sourceParams;
        private CalcParamView calcParams;

        public TriangleDigitalView(TriangleModel tm, Controller tc,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
            :base(tm, tc, leftBound, rightBound, topBound, bottomBound)
        {
            sourceParams = 
                new SourceParamView(tm, tc, leftBound+2, rightBound, topBound+2, bottomBound);
            calcParams = 
                new CalcParamView(tm, tc, leftBound+2, rightBound, 
                topBound+(bottomBound-topBound)/2, bottomBound);
        }
        public override  void Update()
        {
            Console.SetCursorPosition(leftBound, 0);
            //Console.WriteLine("{0}-{1}-{2}-{3}", tm1.GetA(), tm1.B, tm1.C, tm1.Perimeter);
            Console.Write("Triangle (Digital view)");
            sourceParams.Update();
            calcParams.Update();
        }
        public bool GetCommand()
        {
            Console.SetCursorPosition(leftBound, bottomBound);
            Console.WriteLine("                   ");
            Console.SetCursorPosition(leftBound, bottomBound);

            string command = Console.ReadLine();
            if (command == "exit") return true;
            string prefix = command.Substring(0, 2);
            string strValue = command.Substring(2);
            double value;
            try { value = Convert.ToDouble(strValue); }
            catch
            {   value = 0;
               return false;
            }
            switch (prefix)
            {
                case "P=":
                   controller.PerimeterAdjustment(value);
                   break;
                //case "S=":
                //    controller.AreaAdjustment();
                //    break;
            }
            return false;
        }
    }
    public class SourceParamView : CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public SourceParamView(TriangleModel tm, Controller tc,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
            : base(tm, tc, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public override void Update()
        {
            Console.SetCursorPosition(leftBound, topBound);
            Console.WriteLine("a={0}", tm.A);
            Console.SetCursorPosition(leftBound, topBound + 2);
            Console.WriteLine("b={0}", tm.B);
            Console.SetCursorPosition(leftBound, topBound + 4);
            Console.WriteLine("c={0}", tm.C);

        }
    }
    public class CalcParamView : CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public CalcParamView(TriangleModel tm, Controller tc, 
           int leftBound, int rightBound,
           int topBound, int bottomBound)
           : base(tm, tc, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public override void Update()
        {
            Console.SetCursorPosition(leftBound, topBound);
            Console.WriteLine("Perimeter={0}", tm.Perimeter);
            Console.SetCursorPosition(leftBound, topBound+2);
            Console.WriteLine("Area={0}", tm.Area);
        }
    }
    public class PictureView : CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public PictureView(TriangleModel tm, Controller tc, 
           int leftBound, int rightBound,
           int topBound, int bottomBound)
           : base(tm, tc, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public override void Update()
        {
            double height = tm.Perimeter;
            Console.SetCursorPosition(leftBound, topBound);
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= 2 * i - 1; j++)
                    //for (int j = 1; j < i +1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
