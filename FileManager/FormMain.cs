using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using HidromasOzel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static object lockObject = new object();

        private void Dosyalar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                listView.BeginUpdate();
                listView.Items.Clear();

                var topFiles = (from q in new XPQuery<PdfFileInfo>(XpoDefault.Session)
                                orderby q.Oid descending
                                select new { q.Oid, q.Name, q.Length, q.UploadMsg, q.MailMsg, q.CreationTime, q.Aktarim }).Take(100).ToList();

                if (topFiles != null && topFiles.Count > 0)
                {
                    foreach (var f in topFiles)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = Convert.ToInt32(f.Aktarim);
                        item.Text = f.Oid.ToString();
                        item.SubItems.Add(f.Name);
                        item.SubItems.Add(f.Length.ToString());
                        item.SubItems.Add(f.CreationTime.ToString());
                        item.SubItems.Add(f.UploadMsg);
                        item.SubItems.Add(f.MailMsg);
                        listView.Items.Add(item);
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
            finally
            {
                listView.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            Utility.WriteTrace("Uygulama başladı");
            StaticsVariable.APPVISIBLE = false;
            //this.Hide();
            timerJop.Interval = Convert.ToInt32(Properties.Settings.Default.sure) * 60000;
            if (Directory.Exists(Properties.Settings.Default.argeklasor))
                fileSystemWatcher.Path = Properties.Settings.Default.argeklasor;
            else
                Utility.Hata(string.Format("{0} klasör yolu hatalı", Properties.Settings.Default.argeklasor));
            this.notifyIconApp.Visible = true;
            timerStartup.Enabled = false;
            timerJop_Tick(timerJop, EventArgs.Empty);
            timerJop.Enabled = true;
        }

        private void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (e.ChangeType == System.IO.WatcherChangeTypes.Created)
            {
                new Thread(new ParameterizedThreadStart(Kaydet)).Start(e.FullPath);
            }
        }

        private void Kaydet(object paramobj)
        {
            try
            {
                Thread.Sleep(1000);
                Thread.Sleep(1000);
                FileInfo inf = new FileInfo(paramobj.ToString());
                lock (lockObject)
                {
                    using (UnitOfWork wrk = new UnitOfWork())
                    {
                        PdfFileInfo pdf = new PdfFileInfo(wrk);
                        pdf.Name = inf.Name;
                        pdf.FullName = inf.FullName;
                        pdf.Extension = inf.Extension;
                        pdf.CreationTime = inf.CreationTime;
                        try
                        {
                            pdf.Length = inf.Length;
                        }
                        catch
                        {
                        }
                        //pdf.FileType = PDFExpression.DosyaTuru(Path.GetFileNameWithoutExtension(inf.FullName));
                        pdf.FileType = PdfFileType.Bilinmiyor;
                        pdf.ChangeType = WatcherChangeTypes.Created;
                        pdf.Save();
                        Utility.WriteTrace(pdf.ToString());
                        wrk.CommitChanges();
                    }
                }
                if (!StaticsVariable.APPVISIBLE)
                    this.notifyIconApp.ShowBalloonTip(1000, "UyumSoft", "Yeni dosya algılandı." + inf.Name, ToolTipIcon.Info);
                else
                    Utility.WriteTrace("Yeni dosya algılandı." + inf.Name);
            }
            catch (Exception exc)
            {
                Utility.WriteTrace(exc.Message);
                Utility.WriteTrace(exc.StackTrace);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.Listeners.Add(new TextTraceListener(richTrace));
        }

        private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void notifyIconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StaticsVariable.APPVISIBLE = true;
            this.Size = new Size(800, 600);
            this.Show();
            this.notifyIconApp.Visible = false;
        }

        private void timerJop_Tick(object sender, EventArgs e)
        {
            timerJop.Enabled = false;

            Dosyalar();

            using (UnitOfWork wrk = new UnitOfWork())
            {
                XPCollection<PdfFileInfo> allfiles = new XPCollection<PdfFileInfo>(wrk, CriteriaOperator.Parse("Aktarim=?", 0), new SortProperty[] { new SortProperty() { Property = "OID", PropertyName = "Oid", Direction = DevExpress.Xpo.DB.SortingDirection.Descending } });
                allfiles.TopReturnedObjects = 100;
                if (allfiles.Count > 0)
                {
                    Utility.WriteTrace(allfiles.Count + " adet dosya aktarılacak.");
                    using (OraHelper ora = new OraHelper())
                    {
                        foreach (PdfFileInfo f in allfiles)
                        {
                            int relationId = 0;
                            object objIds = null;
                            int relationObject = 0;

                            if (f.FileType == PdfFileType.Bilinmiyor)
                            {
                                List<object> arguman = new List<object>();
                                string koddosyasi = Application.StartupPath + "\\HidromasOzel.txt";
                                if (File.Exists(koddosyasi))
                                {
                                    string code = "";
                                    using (StreamReader reader = new StreamReader(new FileStream(koddosyasi, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.GetEncoding("windows-1254")))
                                    {
                                        code = reader.ReadToEnd().Trim();
                                    }
                                    Object[] requiredAssemblies = new Object[] { };
                                    dynamic classRef;
                                    try
                                    {
                                        classRef = ReflectionHelper.FunctionExec(code, "HidromasOzel.HidromasDosya", requiredAssemblies);

                                        //-------------------
                                        // If the compilation process returned an error, then show to the user all errors
                                        if (classRef is CompilerErrorCollection)
                                        {
                                            StringBuilder sberror = new StringBuilder();

                                            foreach (CompilerError error in (CompilerErrorCollection)classRef)
                                            {
                                                sberror.AppendLine(string.Format("{0}:{1} {2} {3}", error.Line, error.Column, error.ErrorNumber, error.ErrorText));
                                            }

                                            Trace.WriteLine(sberror.ToString());

                                            return;
                                        }

                                        arguman = classRef.DosyaTuru(Path.GetFileNameWithoutExtension(f.FullName));
                                    }
                                    catch (Exception ex)
                                    {
                                        // If something very bad happened then throw it
                                        MessageBox.Show(ex.Message);
                                        throw;
                                    }
                                }
                                else
                                {

                                    //using (StreamWriter wr = new StreamWriter(new FileStream(koddosyasi, FileMode.Create, FileAccess.Write, FileShare.Write), Encoding.GetEncoding("windows-1254")))
                                    //{
                                    //    wr.Write(ReflectionHelper.DosyaIcerik("FileManager.HidromasOzel.txt"));
                                    //    wr.Flush();
                                    //    wr.Close();
                                    //}

                                    HidromasDosya ozel = new HidromasDosya();
                                    arguman = ozel.DosyaTuru(Path.GetFileNameWithoutExtension(f.FullName));
                                }
                                if (arguman != null)
                                {
                                    if (arguman.Count > 3)
                                    {
                                        if (Convert.ToInt32(arguman[3]) == 0)
                                        {
                                            f.FileType = PdfFileType.Bilinmiyor;
                                        }
                                        else if (Convert.ToInt32(arguman[3]) == 1)
                                        {
                                            f.FileType = PdfFileType.UrunAgacKod;
                                        }
                                        else if (Convert.ToInt32(arguman[3]) == 2)
                                        {
                                            f.FileType = PdfFileType.RotaKod;
                                        }
                                        else if (Convert.ToInt32(arguman[3]) == 3)
                                        {
                                            f.FileType = PdfFileType.IstasyonKod;
                                        }
                                        else if (Convert.ToInt32(arguman[3]) == 4)
                                        {
                                            f.FileType = PdfFileType.StokKod;
                                        }
                                        else
                                        {
                                            f.FileType = PdfFileType.Diger;
                                        }
                                    }
                                    if (arguman.Count > 0)
                                    {
                                        relationId = Convert.ToInt32(arguman[0]);
                                    }
                                    if (arguman.Count > 2)
                                    {
                                        relationObject = Convert.ToInt32(arguman[2]);
                                    }
                                    f.RelationId = relationId;
                                    f.RelationObject = relationObject;
                                }
                            }

                            if (f.FileType == PdfFileType.Bilinmiyor)
                            {
                                Utility.WriteTrace("Dosya hatalı! Eksik parametre:" + f.Name);
                                f.UploadMsg = "Dosya türü bilinmiyor:" + f.Name;
                                f.Aktarim = AktarimDurumu.RelationIdYok;
                                f.Save();
                                continue;
                            }

                            #region İptal
                            /*else if (f.FileType == PdfFileType.UrunAgacKod)
                            {
                                f.UrunAgacRevizyonKodu = PDFExpression.RevizyonNumarasi(f.Name);

                                objIds = ora.ExecuteScalar(string.Format("SELECT U.BOM_M_ID FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_BOM_M U ON B.ITEM_ID = U.ITEM_ID WHERE B.BRANCH_ID = '{0}' AND B.CO_ID = '{1}' AND M.ITEM_CODE = '{2}' AND replace(replace(U.ALTERNATIVE_NO, '-', ''),'_','') = '{3}'", Properties.Settings.Default.branchid, Properties.Settings.Default.coid, f.StokKodu, f.UrunAgacRevizyonKodu), null);
                                if (objIds != null)
                                {
                                    relationId = Convert.ToInt32(objIds);
                                }
                                else
                                {
                                    Utility.WriteTrace("Ürün ağaç kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu);
                                    f.UploadMsg = "Ürün ağaç kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu;
                                    f.Aktarim = AktarimDurumu.RelationIdYok;
                                    f.Save();
                                    continue;
                                }
                            }
                            else if (f.FileType == PdfFileType.RotaKod)
                            {
                                f.UrunAgacRevizyonKodu = PDFExpression.RevizyonNumarasi(f.Name);
                                f.OperasyonNo = PDFExpression.OperasyonSiraNo(f.Name);
                                f.OperasyonKodu = PDFExpression.OperasyonKod(f.Name);

                                if (f.OperasyonNo > 0)
                                {
                                    objIds = ora.ExecuteScalar(string.Format("SELECT D.PRODUCT_ROUTE_D_ID FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_M R ON R.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_D D ON R.PRODUCT_ROUTE_M_ID = D.PRODUCT_ROUTE_M_ID INNER JOIN UYUMSOFT.PRDD_OPERATION O ON D.OPERATION_ID = O.OPERATION_ID WHERE B.BRANCH_ID = '{0}' AND B.CO_ID = '{1}' AND M.ITEM_CODE = '{2}' AND replace(replace(R.ALTERNATIVE_NO, '-', ''),'_','') = '{3}' AND O.OPERATION_CODE = '{4}' AND D.OPERATION_NO = {5} AND ROWNUM = 1", Properties.Settings.Default.branchid, Properties.Settings.Default.coid, f.StokKodu, f.UrunAgacRevizyonKodu, f.OperasyonKodu, f.OperasyonNo), null);
                                }
                                else
                                {
                                    f.UrunAgacRevizyonKodu = PDFExpression.RotaRevizyonNumarasi(f.Name);
                                    objIds = ora.ExecuteScalar(string.Format("SELECT R.PRODUCT_ROUTE_M_ID FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_M R ON R.ITEM_ID = M.ITEM_ID  WHERE B.BRANCH_ID = '{0}' AND B.CO_ID = '{1}' AND M.ITEM_CODE = '{2}' AND replace(replace(R.ALTERNATIVE_NO, '-', ''),'_','') = '{3}' AND ROWNUM = 1", Properties.Settings.Default.branchid, Properties.Settings.Default.coid, f.StokKodu, f.UrunAgacRevizyonKodu), null);
                                }
                                if (objIds != null)
                                {
                                    relationId = Convert.ToInt32(objIds);
                                }
                                else
                                {
                                    Utility.WriteTrace("Ürün rota kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu);
                                    f.UploadMsg = "Ürün rota kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu;
                                    f.Aktarim = AktarimDurumu.RelationIdYok;
                                    f.Save();
                                    continue;
                                }
                            }
                            else if (f.FileType == PdfFileType.IstasyonKod)
                            {
                                objIds = ora.ExecuteScalar(string.Format("SELECT WSTATION_ID FROM UYUMSOFT.PRDD_WSTATION WHERE BRANCH_ID = '{0}' AND CO_ID = '{1}' AND WSTATION_CODE = '{2}'", Properties.Settings.Default.branchid, Properties.Settings.Default.coid, f.StokKodu), null);
                                if (objIds != null)
                                {
                                    relationId = Convert.ToInt32(objIds);
                                }
                                else
                                {
                                    Utility.WriteTrace("Ürün ağaç kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu);
                                    f.UploadMsg = "Ürün ağaç kodu bulunamadı:" + f.StokKodu + "," + f.UrunAgacRevizyonKodu;
                                    f.Aktarim = AktarimDurumu.RelationIdYok;
                                    f.Save();
                                    continue;
                                }
                            }*/

                            #endregion

                            if (relationId > 0)
                            {
                                try
                                {
                                    Utility.WriteTrace("Dosya kopyalanıyor:" + f.FullName + " to " + string.Concat(Properties.Settings.Default.hedefklasor, "\\", f.Name));

                                    SaveACopyfileToServer(f.FullName, string.Concat(Properties.Settings.Default.hedefklasor, "\\", f.Name));

                                }
                                catch (IOException io)
                                {
                                    Utility.WriteTrace("Dosya klasore kopyalanamadı:" + io.Message);
                                    f.UploadMsg = "Dosya klasore kopyalanamadı:" + io.Message;
                                    f.Aktarim = AktarimDurumu.Kopyalanamadi;
                                    f.Save();
                                    continue;
                                }
                                catch (Exception exc)
                                {
                                    Utility.WriteTrace("Dosya klasore kopyalanamadı:" + exc.Message);
                                    f.UploadMsg = "Dosya klasore kopyalanamadı:" + exc.Message;
                                    f.Aktarim = AktarimDurumu.Kopyalanamadi;
                                    f.Save();
                                    continue;
                                }

                                try
                                {
                                    Utility.WriteTrace("Dosya siliniyor:" + f.FullName);

                                    File.Delete(f.FullName);
                                }
                                catch (IOException io)
                                {
                                    Utility.WriteTrace("Dosya silinemedi:" + io.Message);
                                }
                                catch (Exception exc)
                                {
                                    Utility.WriteTrace("Dosya silinemedi:" + exc.Message);
                                }
                            }

                            if (File.Exists(string.Concat(Properties.Settings.Default.hedefklasor, "\\", f.Name)))
                            {
                                try
                                {
                                    OracleParameter[] delParameters = new OracleParameter[2];
                                    delParameters[0] = new OracleParameter(":RELATION_OBJECT", relationObject);
                                    delParameters[1] = new OracleParameter(":RELATION_ID", relationId);
                                    ora.Exec("DELETE FROM GNLD_UPLOAD_FILE WHERE RELATION_OBJECT = :RELATION_OBJECT AND RELATION_ID = :RELATION_ID", delParameters);
                                }
                                catch (Exception delexception)
                                {
                                    Utility.WriteTrace("Öncei dökümanlar silinemedi! Hata:" + delexception.Message);
                                }

                            }

                            int uploadFileId = 1;
                            objIds = ora.ExecuteScalar("SELECT MAX(UPLOAD_FILE_ID) AS UPLOAD_FILE_ID FROM GNLD_UPLOAD_FILE", null);

                            if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
                            {
                                uploadFileId = Convert.ToInt32(objIds) + 1;
                            }
                            string commandText = "INSERT INTO GNLD_UPLOAD_FILE (UPLOAD_FILE_ID, RELATION_OBJECT, RELATION_ID, SH0RT_FILE_NAME, LONG_FILE_NAME, DOCUMENT_TYPE, DESCRIPTION, CREATE_DATE, CREATE_USER_ID) VALUES (:UPLOAD_FILE_ID, :RELATION_OBJECT, :RELATION_ID, :SH0RT_FILE_NAME, :LONG_FILE_NAME, :DOCUMENT_TYPE, :DESCRIPTION, :CREATE_DATE, :CREATE_USER_ID)";
                            OracleParameter[] oraParameters = new OracleParameter[9];
                            oraParameters[0] = new OracleParameter(":UPLOAD_FILE_ID", uploadFileId);
                            oraParameters[1] = new OracleParameter(":RELATION_OBJECT", relationObject);
                            oraParameters[2] = new OracleParameter(":RELATION_ID", relationId);
                            oraParameters[3] = new OracleParameter(":SH0RT_FILE_NAME", f.Name);
                            oraParameters[4] = new OracleParameter(":LONG_FILE_NAME", f.Name);
                            oraParameters[5] = new OracleParameter(":DOCUMENT_TYPE", StaticsVariable.DOCUMENT_TYPE);
                            oraParameters[6] = new OracleParameter(":DESCRIPTION", StaticsVariable.DESCRIPTION);
                            oraParameters[7] = new OracleParameter(":CREATE_DATE", DateTime.Now);
                            oraParameters[8] = new OracleParameter(":CREATE_USER_ID", Properties.Settings.Default.userid);
                            if (!ora.Exec(commandText, oraParameters))
                            {
                                Utility.WriteTrace("Veritabanına yazılamadı!" + f.Name);
                                f.UploadMsg = "Veritabanına yazılamadı!";
                                f.Aktarim = AktarimDurumu.Kaydedilemedi;
                                f.Save();
                            }
                            else
                            {
                                OracleParameter[] selParameters = new OracleParameter[2];
                                selParameters[0] = new OracleParameter(":UPLOAD_FILE_ID", uploadFileId);
                                selParameters[1] = new OracleParameter(":SH0RT_FILE_NAME", f.Name);
                                objIds = ora.ExecuteScalar("SELECT UPLOAD_FILE_ID FROM GNLD_UPLOAD_FILE WHERE UPLOAD_FILE_ID = :UPLOAD_FILE_ID OR SH0RT_FILE_NAME = :SH0RT_FILE_NAME", selParameters);

                                if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
                                {
                                    uploadFileId = Convert.ToInt32(objIds);
                                }

                                try
                                {
                                    MailHelper.MailSend(f.Name);
                                    f.IsMailSend = true;
                                }
                                catch (Exception exc)
                                {
                                    f.IsMailSend = false;
                                    f.MailMsg = exc.Message;
                                }
                                f.IsUploaded = true;
                                f.UploadFileId = uploadFileId;
                                f.UploadMsg = string.Format("{0} aktarıldı.", uploadFileId);
                                f.Aktarim = AktarimDurumu.Aktarildi;
                                f.Save();
                            }
                        }

                    }
                    wrk.CommitChanges();
                    Dosyalar();
                }
                else
                {
                    Utility.WriteTrace("Aktarılacak dosya yok.");
                    //MailHelper.MailSend("TTTTTTTT");
                }
            }

            timerJop.Enabled = true;
        }

        private static void SaveACopyfileToServer(string filePath, string savePath)
        {
            var directory = Path.GetDirectoryName(savePath).Trim();
            var username = "hdrms\barset";
            var password = "!brst123";
            var filenameToSave = Path.GetFileName(savePath);

            if (!directory.EndsWith("\\"))
                filenameToSave = "\\" + filenameToSave;

            var command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);

            command = "NET USE " + directory + " /user:" + username + " " + password;
            ExecuteCommand(command, 5000);

            command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\" /Z /Y";

            ExecuteCommand(command, 5000);


            command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);
        }

        public static int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };

            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIconApp.Visible = true;
                this.notifyIconApp.ShowBalloonTip(600, "UyumSoft", "Uygulama çalışıyor.", ToolTipIcon.Info);
            }
            else if (WindowState == FormWindowState.Normal)
            {
                this.Show();
                this.notifyIconApp.Visible = false;
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            if (settings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                timerJop.Interval = Convert.ToInt32(Properties.Settings.Default.sure) * 60000;
                fileSystemWatcher.Path = Properties.Settings.Default.argeklasor;
            }
        }

        private void mnuList_Opening(object sender, CancelEventArgs e)
        {
            btnSend.Enabled = btnUpd.Enabled = btnDel.Enabled = listView.SelectedIndices.Count > 0;
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            richTrace.Text = "";
        }

        private void bntOpenTrace_Click(object sender, EventArgs e)
        {
            Process.Start(string.Format("\"{0}\"", Utility.TraceName));
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedIndices.Count > 0)
                {
                    int oid = Convert.ToInt32(listView.Items[listView.SelectedIndices[0]].Text);
                    if (Utility.Sor(oid + " nolu kayıt silinecek kabul ediyor musunuz?"))
                    {
                        PdfFileInfo file = XpoDefault.Session.GetObjectByKey<PdfFileInfo>(oid);
                        if (file != null) file.Delete();
                        Dosyalar();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedIndices.Count > 0)
                {
                    int oid = Convert.ToInt32(listView.Items[listView.SelectedIndices[0]].Text);
                    if (Utility.Sor(oid + " nolu kayıt gönderildi olarak güncellenecek, kabul ediyor musunuz?"))
                    {
                        PdfFileInfo file = XpoDefault.Session.GetObjectByKey<PdfFileInfo>(oid);
                        if (file != null)
                        {
                            file.UploadMsg = "";
                            file.Aktarim = AktarimDurumu.Aktarildi;
                            file.Save();
                        }
                        Dosyalar();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedIndices.Count > 0)
                {
                    int oid = Convert.ToInt32(listView.Items[listView.SelectedIndices[0]].Text);
                    if (Utility.Sor(oid + " nolu kayıt gönderilmedi olarak güncellenecek, kabul ediyor musunuz?"))
                    {
                        PdfFileInfo file = XpoDefault.Session.GetObjectByKey<PdfFileInfo>(oid);
                        if (file != null)
                        {
                            file.FileType = PdfFileType.Bilinmiyor;
                            file.UploadMsg = "";
                            file.Aktarim = AktarimDurumu.Bekliyor;
                            file.Save();
                        }
                        Dosyalar();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dosyalar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormKod kd = new FormKod();
            kd.ShowDialog();
        }
    }
}
