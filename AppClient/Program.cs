using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace AppClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    BonusSkins.Register();
                    SkinManager.EnableFormSkins();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    FrmMain apprun = new FrmMain();
                    UILogin app = new UILogin(); //new FrmMain();
                    app.FrmMain = apprun;
                    app.ShowDialog();
                    if (app.DialogResult == DialogResult.OK)
                    {                       
                        apprun.WindowState = FormWindowState.Maximized;
                        Application.Run(apprun);
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show("应用程序已经在运行中...");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(1);
                }
            }
        }
    }
}