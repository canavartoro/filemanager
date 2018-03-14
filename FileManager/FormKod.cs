using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormKod : Form
    {
        public FormKod()
        {
            InitializeComponent();
        }
        string koddosyasi = Application.StartupPath + "\\HidromasOzel.txt";
        private void fctb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < fctb.LeftIndent)
            {
                var place = fctb.PointToPlace(e.Location);
                if (fctb.Bookmarks.Contains(place.iLine))
                    fctb.Bookmarks.Remove(place.iLine);
                else
                    fctb.Bookmarks.Add(place.iLine);
            }
        }

        private void FormKod_Load(object sender, EventArgs e)
        {
            string code = "";

            if (File.Exists(koddosyasi))
            {
                using (StreamReader reader = new StreamReader(new FileStream(koddosyasi, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.GetEncoding("windows-1254")))
                {
                    code = reader.ReadToEnd().Trim();
                }
            }
            else
            {

                using (StreamWriter wr = new StreamWriter(new FileStream(koddosyasi, FileMode.Create, FileAccess.Write, FileShare.Write), Encoding.GetEncoding("windows-1254")))
                {
                    code = ReflectionHelper.DosyaIcerik("FileManager.HidromasOzel.txt");
                    wr.Write(code);
                    wr.Flush();
                    wr.Close();
                }
            }
            fctb.Text = code;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            using (StreamWriter wr = new StreamWriter(new FileStream(koddosyasi, FileMode.Create, FileAccess.Write, FileShare.Write), Encoding.GetEncoding("windows-1254")))
            {
                wr.Write(fctb.Text);
                wr.Flush();
                wr.Close();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaAd.Text))
            {
                Utility.Hata("Dosya adı girmelisiniz!");
                txtDosyaAd.Focus();
                return;
            }

            Object[] requiredAssemblies = new Object[] { };
            dynamic classRef;
            try
            {
                classRef = ReflectionHelper.FunctionExec(fctb.Text, "HidromasOzel.HidromasDosya", requiredAssemblies);

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

                StringBuilder sonuc = new StringBuilder();
                List<object> arguman = classRef.DosyaTuru(Path.GetFileNameWithoutExtension(txtDosyaAd.Text));
                if (arguman != null)
                {
                    if (arguman.Count > 3)
                    {
                        if (Convert.ToInt32(arguman[3]) == 0)
                        {
                            sonuc.AppendLine("Dosya türü:Bilinmiyor");
                        }
                        else if (Convert.ToInt32(arguman[3]) == 1)
                        {
                            sonuc.AppendLine("Dosya türü:Ürün ağaç kodu");
                        }
                        else if (Convert.ToInt32(arguman[3]) == 2)
                        {
                            sonuc.AppendLine("Dosya türü:Rota kodu");
                        }
                        else if (Convert.ToInt32(arguman[3]) == 3)
                        {
                            sonuc.AppendLine("Dosya türü:İstasyon kodu");
                        }
                        else if (Convert.ToInt32(arguman[3]) == 4)
                        {
                            sonuc.AppendLine("Dosya türü:Stok kodu");
                        }
                    }
                    if (arguman.Count > 0)
                    {
                        sonuc.AppendLine("Relation Id:" + arguman[0]);
                    }
                    if (arguman.Count > 2)
                    {
                        sonuc.AppendLine("Relation Obje:" + arguman[2]);
                    }
                    sonuc.AppendLine("Eleman sayısı:" + arguman.Count);
                }
                else
                {
                    sonuc.Append("Hiç bir sonuç donmedi!");
                }
                Utility.Bilgi(sonuc.ToString());
            }
            catch (Exception ex)
            {
                // If something very bad happened then throw it
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
