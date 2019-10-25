using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace demo_xử_lý_ảnh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBatDau());
        }
    }
}
