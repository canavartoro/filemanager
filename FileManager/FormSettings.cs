using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        MailAdres currentAdres = null;

        private void Adresler()
        {
            try
            {
                listView1.BeginUpdate();
                listView1.Items.Clear();

                XPCollection<MailAdres> allAdress = new XPCollection<MailAdres>(CriteriaOperator.Parse(""), null);
                for (int i = 0; i < allAdress.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = allAdress[i];
                    item.Text = allAdress[i].Isim;
                    item.Checked = allAdress[i].Gonderilsin;
                    item.SubItems.Add(allAdress[i].Adres);
                    item.SubItems.Add(allAdress[i].Gonderilsin ? "√" : "");
                    listView1.Items.Add(item);
                }

                listView1.EndUpdate();
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void Temizle()
        {
            currentAdres = null;
            txtAd.Text = "";
            txtAdres.Text = "";
            chkstatu.Checked = false;
            txtAd.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMailHost.Text) || 
                string.IsNullOrEmpty(txtHost.Text) ||
                string.IsNullOrEmpty(txtMailPass.Text) ||
                string.IsNullOrEmpty(txtMailUser.Text))
            {
                Utility.Hata("Alanlar boş bırakılamaz!");
                return;
            }

            if (!Directory.Exists(txtHedefKlasor.Text))
            {
                Utility.Hata("Hedef klasör hatalı!");
                return;
            }

            if (!Directory.Exists(txtKaynakKlasor.Text))
            {
                Utility.Hata("Kaynak klasör hatalı!");
                return;
            }

            if (!Regex.IsMatch(txtMailUser.Text, @"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$"))
            {
                Utility.Hata("Mail adresi formatı hatalı!");
                return;
            }

            Properties.Settings.Default.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Adresler();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                currentAdres = listView1.Items[listView1.SelectedIndices[0]].Tag as MailAdres;
                if (currentAdres != null)
                {
                    txtAd.Text = currentAdres.Isim;
                    txtAdres.Text = currentAdres.Adres;
                    chkstatu.Checked = currentAdres.Gonderilsin;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentAdres == null)
            {
                currentAdres = new MailAdres();
            }

            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtAdres.Text))
            {
                Utility.Hata("Alanlar boş bırakılamaz!");
                return;
            }

            if (!Regex.IsMatch(txtAdres.Text, @"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$"))
            {
                Utility.Hata("Mail adresi formatı hatalı!");
                return;
            }

            currentAdres.Adres = txtAdres.Text;
            currentAdres.Isim = txtAd.Text;
            currentAdres.Gonderilsin = chkstatu.Checked;
            currentAdres.Save();
            Temizle();
            Adresler();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (currentAdres == null)
            {
                Utility.Hata("Listeden silinecek adresi seçin!");
                return;
            }

            if (!Utility.Sor(currentAdres.Isim + " mail adresi silinecek onaylıyor musunuz?")) return;

            currentAdres.Delete();
            Temizle();
            Adresler();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
           
        }

        private void btnKaynakFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.Description = "İzlenecek klasörü seçin.";
            fl.ShowNewFolderButton = false;
            if (fl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtKaynakKlasor.Text = fl.SelectedPath;
            }
        }

        private void btnHedefFold_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.Description = "Dosyaların kopyalanacağı klasörü seçin.";
            fl.ShowNewFolderButton = false;
            if (fl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHedefKlasor.Text = fl.SelectedPath;
            }
        }
    }
}
