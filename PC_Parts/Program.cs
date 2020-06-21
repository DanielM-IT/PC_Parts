using System;
using System.Windows.Forms;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
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
            Application.Run(frmMain.Instance);
        }
    }
}
