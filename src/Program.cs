using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UltiLaunch2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        readonly static public uint WM_COPYDATA = 0x4a;

        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)] public string lpData;
    }

    internal static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool IsRunningOnMono = (Type.GetType("Mono.Runtime") != null);
            Process other = null;
            if (!IsRunningOnMono)
            {
                Process current = Process.GetCurrentProcess();
                other = Process.GetProcessesByName(current.ProcessName).FirstOrDefault(p => p.Id != current.Id);
            }

            if (other != null)
            {
                // We're already running. Send a full path to that process.
                string path = Directory.GetCurrentDirectory();
                if (args.Length > 0)
                    path = Path.Combine(path, args[0]);
   
                var cds = new COPYDATASTRUCT
                {
                    dwData = (IntPtr)31337,
                    lpData = path + "\0"
                };
                cds.cbData = cds.lpData.Length;

                int x = SendMessage(other.MainWindowHandle, COPYDATASTRUCT.WM_COPYDATA, IntPtr.Zero, ref cds);
            }
            else
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                //ApplicationConfiguration.Initialize();
#if NETCOREAPP
                ApplicationConfiguration.Initialize();
#else
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
#endif
                Application.Run(new LauncherForm(args));
            }

        }
    }
}