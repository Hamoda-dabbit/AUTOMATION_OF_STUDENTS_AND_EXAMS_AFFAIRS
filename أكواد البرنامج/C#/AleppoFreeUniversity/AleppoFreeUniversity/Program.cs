using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AleppoFreeUniversity
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmlogin());
              // Application.Run(new PL.FRM_MAIN());
        }
            catch (Exception)
            { MessageBox.Show("يرجى اعادة تشغيل البرنامج"); }
}
    }
}
