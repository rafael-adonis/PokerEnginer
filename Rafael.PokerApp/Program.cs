using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rafael.Engine;
using Rafael.ValueObject;
using Rafael.ValueObject.Enum;


namespace Rafael.PokerApp
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
            Application.Run(new frmAppPoker());
        }
    }
}
