using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices; //DllImport
using System.Threading; //Mutex
using System.Diagnostics; //Process

namespace WindowsFormsApplication1
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            bool isNewInstance;
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Mutex mtx = new Mutex(true, appName, out isNewInstance);
            if (!isNewInstance)
            {
                Process[] myProcess = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(appName));
                if (null != myProcess.FirstOrDefault())
                {
                    ShowWindow(myProcess.FirstOrDefault().MainWindowHandle, 1);
                }
            }
            else
            {
                Application.Run(new Main());
            }
        }
    }
}
