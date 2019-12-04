using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVCTriangle;

namespace MVCWinClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TriangleModel tm = new TriangleModel();
            tm.A = 10; tm.B = 15; tm.C = 20;
            Application.Run(new Form1(tm));
        }
    }
}
