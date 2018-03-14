using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    static class MailHelper
    {
        public static void MailSend(string data)
        {
            XPCollection<MailAdres> allAdress = new XPCollection<MailAdres>(CriteriaOperator.Parse("Gonderilsin=?", true), null);
            
            if (allAdress.Count == 0) return;

            SmtpClient client = new SmtpClient();
            client.Port = Convert.ToInt32(Properties.Settings.Default.mailport);
            client.Host = Properties.Settings.Default.mailhost;
            client.EnableSsl = false;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.mailuser, Properties.Settings.Default.mailpass);

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(string.Format("Otomasyon Bilgi <{0}>", Properties.Settings.Default.mailuser));
            for (int i = 0; i < allAdress.Count; i++)
            {
                mm.To.Add(new MailAddress(string.Format("{0} <{1}>", allAdress[i].Isim, allAdress[i].Adres)));
            }
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.Subject = "Web Erp’de Doküman Değişimi / Eklenmesi";
            mm.Body = "Web Erp’de Doküman (Teknik Resim, Şartname, Talimat, Sözleşme vb.) Eklenmiştir / Değiştirilmiştir. Lütfen kontrol ediniz ve varsa gerekli değişiklik için aksiyon alınız. " + data;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

            client.Send(mm);
        }
    }
}
