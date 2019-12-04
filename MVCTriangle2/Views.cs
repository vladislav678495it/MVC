using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTriangle1
{
    abstract class CursorDrivenView
    {
        private TriangleModel tm1;
        protected int leftBound, rightBound;
        protected int topBound, bottomBound;
        public CursorDrivenView(TriangleModel tm1,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
        {
            this.tm1 = tm1;
            this.leftBound = leftBound;
            this.rightBound = rightBound;
            this.topBound = topBound;
            this.bottomBound = bottomBound;

        }
    }
    class TriangleDigitalView : CursorDrivenView, IObserver
    {

        private SourceParamView sourceParams;
        private CalcParamView calcParams;
        private PictureView picParams;

        public TriangleDigitalView(TriangleModel tm,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
            :base(tm, leftBound, rightBound, topBound, bottomBound)
        {
            sourceParams = 
                new SourceParamView(tm, leftBound+2, rightBound, topBound+2, bottomBound);
            calcParams = 
                new CalcParamView(tm, leftBound+2, rightBound, 
                topBound+(bottomBound-topBound)/2, bottomBound);
            picParams =
                new PictureView(tm, leftBound, rightBound, topBound, bottomBound);
        }
        public void Update()
        {
            Console.SetCursorPosition(leftBound, 0);
            //Console.WriteLine("{0}-{1}-{2}-{3}", tm1.GetA(), tm1.B, tm1.C, tm1.Perimeter);
            Console.Write("Triangle (Digital view)");
            sourceParams.Update();
            calcParams.Update();
            picParams.Update();
        }
    }
    class SourceParamView : CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public SourceParamView(TriangleModel tm,
            int leftBound, int rightBound,
            int topBound, int bottomBound)
            : base(tm, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public void Update()
        {
            Console.SetCursorPosition(leftBound, topBound);
            Console.WriteLine("a={0}", tm.A);
            Console.SetCursorPosition(leftBound, topBound + 2);
            Console.WriteLine("b={0}", tm.B);
            Console.SetCursorPosition(leftBound, topBound + 4);
            Console.WriteLine("c={0}", tm.C);

        }
    }
    class CalcParamView: CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public CalcParamView(TriangleModel tm,
           int leftBound, int rightBound,
           int topBound, int bottomBound)
           : base(tm, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public void Update()
        {
            Console.SetCursorPosition(leftBound, topBound);
            Console.WriteLine("Perimeter={0}", tm.Perimeter);
            Console.SetCursorPosition(leftBound, topBound+2);
            Console.WriteLine("Area={0}", tm.Area);

        }
    }
    class PictureView : CursorDrivenView, IObserver
    {
        TriangleModel tm;
        public PictureView(TriangleModel tm,
           int leftBound, int rightBound,
           int topBound, int bottomBound)
           : base(tm, leftBound, rightBound, topBound, bottomBound)
        { this.tm = tm; }
        public void Update()
        {
            double height = tm.Perimeter;
            Console.SetCursorPosition(rightBound-80, topBound);
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
