using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    class Utility
    {
        static string versiyon = null;

        public static string Versiyon
        {
            get
            {
                if (versiyon == null)
                {
                    Assembly entryPoint = Assembly.GetExecutingAssembly();
                    AssemblyName entryPointName = entryPoint.GetName();
                    Version entryPointVersion = entryPointName.Version;
                    versiyon = string.Format("{0}", entryPointVersion.ToString());
                }
                return versiyon;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {


            string Project = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            System.Diagnostics.Process[] Prc = System.Diagnostics.Process.GetProcessesByName(Project);

            if (Prc.Length > 1)
            {
                if (!(args != null && args.Length > 0))
                {
                    MessageBox.Show("Dosya aktarım servisi, hafızada ya da diğer kullanıcılarda çalışmaktadır.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseAll();
                }
                else
                {
                    CloseAll();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AddListener();
            XPOHelper.XPOStart();
            Application.Run(new FormMain());

        }

        public static void CloseAll()
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].Close();
            }
            Application.Exit();
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            string error = "Bir sistem hatası oluştu!\nBu hatayı sistem yöneticinize bildirin!\n" + e.Exception.ToString();

            WriteTrace(error);
            //System.Diagnostics.EventLog ev = new System.Diagnostics.EventLog("Application", System.Environment.MachineName, dom);

            //ev.WriteEntry(error, System.Diagnostics.EventLogEntryType.Error, 0);

            //ev.Close();

            Application.ExitThread();
        }

        #region TRACE

        private static string traceName = "";
        public static string TraceName
        {
            get
            {
                return traceName;
            }
        }

        private static void AddListener()
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\Trace"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Trace");

                if (!Directory.Exists(Application.StartupPath + "\\Trace\\" + DateTime.Now.ToString("MM")))
                    Directory.CreateDirectory(Application.StartupPath + "\\Trace\\" + DateTime.Now.ToString("MM"));

                if (Directory.Exists(Application.StartupPath + "\\Trace\\" + DateTime.Now.AddMonths(1).ToString("MM")))
                    Directory.Delete(Application.StartupPath + "\\Trace\\" + DateTime.Now.AddMonths(1).ToString("MM"), true);

                traceName = Application.StartupPath + "\\Trace\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd_TRACE") + ".log";

                System.IO.StreamWriter writer = new System.IO.StreamWriter(traceName, true, System.Text.Encoding.GetEncoding("windows-1254"));

                System.Diagnostics.TextWriterTraceListener listener = new System.Diagnostics.TextWriterTraceListener(writer);

                System.Diagnostics.Trace.Listeners.Add(listener);

                System.Diagnostics.Trace.AutoFlush = true;

                System.Diagnostics.Trace.WriteLine("-> " + DateTime.Now.ToString() + "\tBaşladı");
            }
            catch
            {
                ;
            }
        }

        public static void WriteTrace(string str)
        {
            try
            {
                string modul = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ToString();
                System.Diagnostics.Trace.WriteLine(modul + "\t" + DateTime.Now.ToString() + "\t" + str);//System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() + "\t" + str + "\t" + modul);
            }
            catch
            {
                ;
            }
        }

        #endregion

        public static void Hata(string str)
        {
            WriteTrace(str);
            Cursor.Current = Cursors.Default;
            string modul = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ToString();
            MessageBox.Show(string.Concat(str, "\nDetay:", modul, "\nBilgi:", DateTime.Now), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void Hata(Exception exc)
        {
            Cursor.Current = Cursors.Default;
            string modul = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ToString();
            string str = string.Concat(exc.Message, "\n", exc.StackTrace, "\nDetay:", modul, "\nBilgi:", DateTime.Now);
            WriteTrace(str);
            MessageBox.Show(str, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void Bilgi(string str)
        {
            WriteTrace(str);
            Cursor.Current = Cursors.Default;
            string modul = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ToString();
            MessageBox.Show(string.Concat(str, "\nDetay:", modul, "\nBilgi:", DateTime.Now), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static bool Sor(string str)
        {
            WriteTrace(str);
            Cursor.Current = Cursors.Default;
            string modul = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ToString();
            return MessageBox.Show(string.Concat(str, "\nDetay:", modul, "\nBilgi:", DateTime.Now), "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}
