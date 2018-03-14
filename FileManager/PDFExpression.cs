using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.OracleClient;

namespace FileManager
{
    internal class PDFExpression
    {
        public static PdfFileType DosyaTuru(string filename)
        {
            //43175555506_01_001_OG
            //43175555506_01_001_UA
            //00000000_0000                 rota
            //00000000000_00_000_OU-GA      urun agac
            //00000000000_00_000_000_0000   rota
            //1201541_UGTL003               ist

            string[] data = null;
            string str = filename.ToLower();
            
            if (str.IndexOf("ugtl") != -1) return PdfFileType.IstasyonKod;

            if (str.IndexOf("og") != -1 || str.IndexOf("ua") != -1)
            {
                return PdfFileType.UrunAgacKod;
            }

            data = str.Split('_');

            if (data.Length == 2) return PdfFileType.RotaKod;
            else if (data.Length == 4) return PdfFileType.RotaKod;
            else return PdfFileType.Bilinmiyor;

            //var regexUrunAgac = new Regex(@"^\(?([0-9]{11})\)?[_]([0-9]{2})?[_]([0-9]{3})?[_]([O,U][G,A])$");
            //var regexUrunAgac2 = new Regex(@"^\(?([0-9]{8})\)?[_]([0-9]{4})?[_]([O,U][G,A])$");
            //var regexUrunAgac3 = new Regex(@"^\(?([0-9]{17})\)?[_]([0-9]{4})?[_]([O,U][G,A])$");
            //var regexRotaKod = new Regex(@"^\(?([0-9]{8})\)?[_]([0-9]{4})$");
            //var regexRotaKod2 = new Regex(@"^\(?([0-9]{11})\)?[_]([0-9]{2})?[_]([0-9]{3})?[_]([0-9]{3})?[_]([0-9]{4})$");
            //if (regexUrunAgac.IsMatch(filename.Trim()) || regexUrunAgac2.IsMatch(filename.Trim()) || regexUrunAgac3.IsMatch(filename.Trim()))
            //{
            //    return PdfFileType.UrunAgacKod;
            //}
            //else if (regexRotaKod.IsMatch(filename.Trim()) || regexRotaKod2.IsMatch(filename.Trim()))
            //{
            //    return PdfFileType.RotaKod;
            //}
            //else
            //{
            //    return PdfFileType.Bilinmiyor;
            //}
        }

        public static string RevizyonNumarasi(string filename)
        {
            string[] data = filename.Split('_');
            if (data != null && data.Length > 3)
            {
                return string.Concat(data[1], data[2]);
            }
            else if (data != null && data.Length == 3)
            {
                return data[1].Trim();
            }
            else
                return string.Empty;
        }

        public static string RotaRevizyonNumarasi(string filename)
        {
            if (filename.IndexOf(".") != -1)
            {
                filename = filename.Substring(0, filename.IndexOf("."));
            }
            string[] data = filename.Split('_');
            if (data != null && data.Length > 1)
            {
                return string.Concat(data[1]);
            }
            else
                return string.Empty;
        }

        //43175555506_01_001_040_1820
        public static int OperasyonSiraNo(string filename)
        {
            int t = 0;
            string[] data = filename.Split('_');
            if (data != null && (data.Length == 4 || data.Length == 5))
            {
                int.TryParse(data[3], out t);
                return t;
            }
            else
                return 0;
        }

        public static string OperasyonKod(string filename)
        {
            if (filename.IndexOf(".") != -1)
            {
                filename = filename.Substring(0, filename.IndexOf("."));
            }
            string[] data = filename.Split('_');
            if (data != null && data.Length > 3)
            {
                return data[3];
            }
            else if (data != null && data.Length > 4)
            {
                return data[4];
            }
            else
                return string.Empty;
        }
    }
}
