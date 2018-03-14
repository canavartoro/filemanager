using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class OraHelper : IDisposable
    {
        DbProviderFactory factory = null;
        System.Data.IDbConnection conn = null;
        System.Data.IDbCommand comm = null;

        public OraHelper()
        {

        }

        private void Connect()
        {
            if (factory == null)
                factory = DbProviderFactories.GetFactory(StaticsVariable.PROVIDERNAME);

            if (conn == null)
            {
                conn = factory.CreateConnection();
                if (Properties.Settings.Default.test)
                    conn.ConnectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.11)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=uyumtest)));User Id=uyumsoft;Password=uyumsoft;");//StaticsVariable.CONNECTIONSTR;
                else
                    conn.ConnectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id=uyumsoft;Password=uyumsoft;", Properties.Settings.Default.orahost, Properties.Settings.Default.oraport, Properties.Settings.Default.oraservis);//StaticsVariable.CONNECTIONSTR;
                Utility.WriteTrace(string.Format("Data Source=(HOST={0})(PORT={1})(SERVICE_NAME={2})", Properties.Settings.Default.orahost, Properties.Settings.Default.oraport, Properties.Settings.Default.oraservis));
            }

            if (conn.State != ConnectionState.Open)
                conn.Open();

            comm = conn.CreateCommand();
        }

        public bool Exec(string commandText, IDataParameter[] parameters)
        {
            Connect();

            Utility.WriteTrace(commandText);

            comm.Parameters.Clear();
            comm.CommandText = commandText;
            if (parameters != null)
            {
                for (int loop = 0; loop < parameters.Length; loop++)
                {
                    comm.Parameters.Add(parameters[loop]);
                }
            }
            return comm.ExecuteNonQuery() > 0;
        }

        public IDataReader ExecReader(string commandText, IDataParameter[] parameters)
        {
            Connect();

            Utility.WriteTrace(commandText);

            comm.Parameters.Clear();
            comm.CommandText = commandText;
            if (parameters != null)
            {
                for (int loop = 0; loop < parameters.Length; loop++)
                {
                    comm.Parameters.Add(parameters[loop]);
                }
            }
            return comm.ExecuteReader();
        }

        public object ExecuteScalar(string commandText, IDataParameter[] parameters)
        {
            Connect();

            Utility.WriteTrace(commandText);

            comm.Parameters.Clear();
            comm.CommandText = commandText;
            if (parameters != null)
            {
                for (int loop = 0; loop < parameters.Length; loop++)
                {
                    comm.Parameters.Add(parameters[loop]);
                }
            }
            return comm.ExecuteScalar();
        }

        #region IDisposable
        ~OraHelper()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (comm != null)
                {
                    comm.Dispose();
                }
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Dispose();
                }
                conn = null;
                factory = null;
                comm = null;
            }

            disposed = true;
        }
        #endregion
    }
}
