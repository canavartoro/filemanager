using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Persistent("FILES")]
    [OptimisticLocking(false), DeferredDeletion(false)]
    [DebuggerDisplay("Name = {Name}, FullPath = {FullPath}")]
    public class PdfFileInfo : XPObject
    {
        const int URUNAGAC_RELATION_OBJ = -2089279086;//1098530797;
        const int ROTA_RELATION_OBJ = -1228144813;//-1228144813;
        const int ROTA_UST_RELATION_OBJ = 1098530797;
        const int ISTASYON_RELATION_OBJ = 476273311;

        public PdfFileInfo() { }
        public PdfFileInfo(Session session) : base(session) { }

        [Size(300)]
        [Persistent("NAME")]
        public string Name { get; set; }

        [Size(20)]
        [Persistent("EXTENSION")]
        public string Extension { get; set; }

        [Persistent("FULL_PATH")]
        [Size(SizeAttribute.Unlimited)]
        public string FullPath { get; set; }

        [Persistent("FULL_NAME")]
        [Size(SizeAttribute.Unlimited)]
        public string FullName { get; set; }

        [Persistent("LENGTH")]
        public long Length { get; set; }

        [Persistent("CREATIONTIME")]
        public DateTime CreationTime { get; set; }

        [Indexed]
        [Persistent("IS_UPLOAD")]
        [Description("Dosya Erp'ye upload edildi.")]
        public bool IsUploaded { get; set; }

        [Persistent("UPLOAD_MSG")]
        [Size(SizeAttribute.Unlimited)]
        [Description("Dosya Erp'ye aktarılmazsa hata mesajı.")]
        public string UploadMsg { get; set; }

        [Indexed]
        [Persistent("IS_MAIL_SEND")]
        [Description("Bilgilendirme maili gönderildi.")]
        public bool IsMailSend { get; set; }

        [Persistent("MAIL_MSG")]
        [Size(SizeAttribute.Unlimited)]
        [Description("Mail gönderilezse hata mesajı.")]
        public string MailMsg { get; set; }

        [Persistent("UPLOAD_FILE_ID")]
        [Description("Erp deki kayıt Id si.")]
        public int UploadFileId { get; set; }

        [Persistent("CHANGE_TYPE")]
        public WatcherChangeTypes ChangeType { get; set; }

        [Persistent("STATUS")]
        [Description("0=AKTARILACAK, 1=AKTARILDI, 2=KAYIT YOK AKTARILAMADI, 3= KOPYALANAMADI")]
        public AktarimDurumu Aktarim { get; set; }

        [Persistent("FILE_TYPE")]
        public PdfFileType FileType { get; set; }

        private string[] dataList = null;
        [NonPersistent]
        [Description("DOSYA ADI '_' GÖRE BÖLÜNÜYOR")]
        private string[] DataList
        {
            get
            {
                if (dataList == null && Name != null && Name.IndexOf("_") != -1)
                {
                    dataList = Name.Split('_');
                }
                return dataList;
            }
        }

        [NonPersistent]
        [Description("Dosya adından gelen parametre sayısına göre dosya türü belirleniyor")]
        public int ParamCount
        {
            get
            {
                if (this.DataList != null)
                    return this.DataList.Length;
                else
                    return -1;
            }
        }

        [Persistent("RELATION_OBJECT")]
        [Description("Dosya turune gore guid id")]
        public int RelationObject { get; set; }
        //{
        //    get
        //    {
        //        switch (this.FileType)
        //        {
        //            case PdfFileType.UrunAgacKod:
        //                return URUNAGAC_RELATION_OBJ;
        //            case PdfFileType.RotaKod:
        //                if (operasyonNo > 0)
        //                    return ROTA_RELATION_OBJ;
        //                else
        //                    return ROTA_UST_RELATION_OBJ;
        //            case PdfFileType.IstasyonKod:
        //                return ISTASYON_RELATION_OBJ;
        //            default:
        //                return 0;
        //        }
        //    }
        //}

        [Persistent("RELATION_ID")]
        [Description("Dosya turune gore guid id")]
        public int RelationId { get; set; }

        [NonPersistent]
        [Description("Stok kodu.")]
        public string StokKodu
        {
            get
            {
                if (!string.IsNullOrEmpty(Name) && Name.IndexOf("_") != -1)
                {
                    return Name.Substring(0, Name.IndexOf("_"));
                }
                return string.Empty;
            }
        }

        [NonPersistent]
        [Description("Ürün ağaç revizyon kodu.")]
        public string UrunAgacRevizyonKodu { get; set; }
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Name) && Name.IndexOf("_") != -1)
        //        {
        //            return Name.Substring(Name.IndexOf("_") + 1, 4);
        //        }
        //        return string.Empty;
        //    }
        //}

        [NonPersistent]
        [Description("Rota alternatif no.")]
        public string RotaAlternatifNo { get; set; }
        //{
        //    get
        //    {
        //        if (this.DataList != null && this.DataList.Length > 0)
        //        {
        //            return this.DataList[1];
        //        }
        //        return "";
        //    }
        //}

        private int operasyonNo = -1;
        [NonPersistent]
        [Description("Operasyon no.")]
        public int OperasyonNo { get; set; }
        //{
        //    get
        //    {
        //        if (operasyonNo == -1)
        //        {
        //            if (this.DataList != null && this.DataList.Length > 2)
        //            {
        //                int.TryParse(this.DataList[2], out operasyonNo);
        //            }
        //            else
        //            {
        //                this.operasyonNo = 0;
        //            }
        //        }
        //        return operasyonNo;
        //    }
        //}

        private string operasyonKodu = null;
        [NonPersistent]
        [Description("Operasyon kodu.")]
        public string OperasyonKodu { get; set; }
        //{
        //    get
        //    {
        //        if (operasyonKodu == null)
        //        {
        //            if (this.DataList != null && this.DataList.Length > 3)
        //            {
        //                if (this.DataList[3].IndexOf('.') != -1)
        //                {
        //                    operasyonKodu = this.DataList[3].Substring(0, this.DataList[3].IndexOf('.'));
        //                }
        //                else
        //                {
        //                    operasyonKodu = this.DataList[3];
        //                }
        //            }
        //            else
        //            {
        //                this.operasyonKodu = string.Empty;
        //            }
        //        }
        //        return operasyonKodu;
        //    }
        //}

        public override string ToString()
        {
            return string.Format("AKTARIM:{0}, MAIL:{1}, ID:{2}, {3}, {4}, Tür:{5}", IsUploaded ? "Ok" : "Aktarılmadı", IsMailSend ? "Ok" : "Gönderilmedi", UploadFileId, UploadMsg, MailMsg, FileType);
        }

        protected override void OnSaving()
        {
            //if (this.ParamCount == 2)
            //{
            //    if (this.StokKodu.Length > 7)
            //    {
            //        this.FileType = PdfFileType.UrunAgacKod;
            //    }
            //    else
            //    {
            //        this.FileType = PdfFileType.IstasyonKod;
            //    }
            //}
            //else if (this.ParamCount > 2)
            //{
            //    this.FileType = PdfFileType.RotaKod;
            //}
            //else
            //{
            //    this.FileType = PdfFileType.Bilinmiyor;
            //}
            base.OnSaving();
        }
    }
}


