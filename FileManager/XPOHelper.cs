using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    static class XPOHelper
    {
        public static void XPOStart()
        {
            try
            {
                string conString = SQLiteConnectionProvider.GetConnectionString(string.Format("{0}\\{1}_files.dat", System.Windows.Forms.Application.StartupPath, DateTime.Now.Year));
                DevExpress.Xpo.Metadata.XPDictionary dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(conString, AutoCreateOption.DatabaseAndSchema);
                DevExpress.Xpo.XpoDefault.Session = new DevExpress.Xpo.Session(XpoDefault.DataLayer);
                //DevExpress.Xpo.Helpers.SessionStateStack.SuppressCrossThreadFailuresDetection = true;
                //DevExpress.Xpo.Session.DefaultSession.UpdateSchema();

                //IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
                //var layer = new ThreadSafeDataLayer(dictionary, store);

            }
            catch (Exception ex)
            {
                Utility.Hata(ex);
                Utility.CloseAll();
            }
        }
    }
}


