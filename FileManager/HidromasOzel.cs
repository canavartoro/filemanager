using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HidromasOzel
{
    public class HidromasDosya
    {
        public List<object> DosyaTuru(string dosyaAd)
        {
            List<object> sonuc = new List<object>();
            try
            {
                string[] data = null;
                using (OracleConnection ora = new OracleConnection(string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.10)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=uyumsoft)));User Id=uyumsoft;Password=uyumsoft;")))
                {
                    OracleCommand comm = ora.CreateCommand();
                    comm.CommandType = System.Data.CommandType.Text;
                    data = dosyaAd.Split('_');

                    if (data == null || data.Length == 0) return sonuc;

                    ora.Open();

                    #region -- İş İstasyonu Dosyası (Dosya IsIstasyonKodu_UGTLXXX ile oluşur.)
                    if (dosyaAd.ToUpper().IndexOf("UGTL") != -1)
                    {
                        comm.CommandText = "SELECT W.WSTATION_ID, 249 as releationid, 476273311 as RelationObject, 3 as dosya FROM UYUMSOFT.PRDD_WSTATION W WHERE W.BRANCH_ID = 1010 AND W.CO_ID = 191 AND W.WSTATION_CODE = :istasyonkod";
                        comm.Parameters.AddWithValue(":istasyonkod", data[0]);
                        using (OracleDataReader dr = comm.ExecuteReader())
                        {
                            if (dr != null && dr.Read())
                            {
                                if (!dr.IsDBNull(0))
                                    sonuc.Add(dr.GetValue(0));
                                if (!dr.IsDBNull(1))
                                    sonuc.Add(dr.GetValue(1));
                                if (!dr.IsDBNull(2))
                                    sonuc.Add(dr.GetValue(2));
                                if (!dr.IsDBNull(3))
                                    sonuc.Add(dr.GetValue(3));
                            }
                        }
                        return sonuc;
                    }
                    #endregion
                    #region -- Ürün Ağacı Dosyası (Dosya Adı Sonunda "UA" veya "OG" yer alır.)
                    if (dosyaAd.ToUpper().IndexOf("UA") != -1 || dosyaAd.ToUpper().IndexOf("OG") != -1)
                    {

                        comm.CommandText = "SELECT U.BOM_M_ID, 56348 as Releationid, -2089279086 as OG_RelationObject, 1 as dosya FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_BOM_M U ON B.ITEM_ID = U.ITEM_ID WHERE B.BRANCH_ID = 1010 AND B.CO_ID = 191 AND M.ITEM_CODE = :stokkod AND M.ITEM_CODE || REPLACE(REPLACE(U.ALTERNATIVE_NO,'-',''),'_','') = REPLACE(REPLACE(:dosyaadi,'-',''),'_','')";
                        comm.Parameters.AddWithValue(":stokkod", data[0]);
                        comm.Parameters.AddWithValue(":dosyaadi", dosyaAd.Replace("UA","").Replace("OG",""));
                        using (OracleDataReader dr = comm.ExecuteReader())
                        {
                            if (dr != null && dr.Read())
                            {
                                if (!dr.IsDBNull(0))
                                    sonuc.Add(dr.GetValue(0));
                                if (!dr.IsDBNull(1))
                                    sonuc.Add(dr.GetValue(1));
                                if (!dr.IsDBNull(2))
                                    sonuc.Add(dr.GetValue(2));
                                if (!dr.IsDBNull(3))
                                    sonuc.Add(dr.GetValue(3));
                            }
                        }
                        return sonuc;
                    }
                    #endregion
                    #region -- Ürün Rotası Dosyası (Dosya Stok kodu ve Rota Alternatif No ile oluşur.)
                    comm = ora.CreateCommand();
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = "SELECT R.PRODUCT_ROUTE_M_ID, 2588 as releationid, 1098530797 as RelationObject, 2 as dosya FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_M R ON B.ITEM_ID = R.ITEM_ID WHERE B.BRANCH_ID = 1010 AND B.CO_ID = 191 AND M.ITEM_CODE = :stokkod AND M.ITEM_CODE || REPLACE(REPLACE(R.ALTERNATIVE_NO,'-',''),'_','') = REPLACE(REPLACE(:dosyaadi,'-',''),'_','')";
                    comm.Parameters.AddWithValue(":stokkod", data[0]);
                    comm.Parameters.AddWithValue(":dosyaadi", dosyaAd);
                    using (OracleDataReader dr = comm.ExecuteReader())
                    {
                        if (dr != null && dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                                sonuc.Add(dr.GetValue(0));
                            if (!dr.IsDBNull(1))
                                sonuc.Add(dr.GetValue(1));
                            if (!dr.IsDBNull(2))
                                sonuc.Add(dr.GetValue(2));
                            if (!dr.IsDBNull(3))
                                sonuc.Add(dr.GetValue(3));

                            if (dr != null) dr.Close();
                            return sonuc;
                        }
                    }
                    #endregion
                    #region -- Ürün Rota Detayı Dosyası (StokKodu_RotaAlternatifNo_OprsSıraNo_OprsKodu şeklinde oluşur.)
                    comm = ora.CreateCommand();
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = @"SELECT RD.PRODUCT_ROUTE_D_ID, R.PRODUCT_ROUTE_M_ID, -1228144813 as RelationObject, 2 as dosya 
FROM UYUMSOFT.INVD_BRANCH_ITEM            B 
INNER JOIN UYUMSOFT.INVD_ITEM             M ON B.ITEM_ID = M.ITEM_ID 
INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_M  R ON B.ITEM_ID = R.ITEM_ID 
INNER JOIN UYUMSOFT.PRDD_PRODUCT_ROUTE_D RD ON R.PRODUCT_ROUTE_M_ID = RD.PRODUCT_ROUTE_M_ID 
INNER JOIN UYUMSOFT.PRDD_OPERATION        O ON RD.OPERATION_ID      = O.OPERATION_ID 
WHERE B.BRANCH_ID = 1010 AND B.CO_ID = 191 AND M.ITEM_CODE = :stokkod AND (M.ITEM_CODE || REPLACE(REPLACE(R.ALTERNATIVE_NO,'-',''),'_','') || RD.OPERATION_SEQUENTIAL || O.OPERATION_CODE = REPLACE(REPLACE(:dosyaadi,'-',''),'_','') 
OR M.ITEM_CODE || REPLACE(REPLACE(R.ALTERNATIVE_NO,'-',''),'_','') || '0' || RD.OPERATION_SEQUENTIAL || O.OPERATION_CODE = REPLACE(REPLACE(:dosyaadi,'-',''),'_',''))";
                    comm.Parameters.AddWithValue(":stokkod", data[0]);
                    comm.Parameters.AddWithValue(":dosyaadi", dosyaAd);
                    using (OracleDataReader dr = comm.ExecuteReader())
                    {
                        if (dr != null && dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                                sonuc.Add(dr.GetValue(0));
                            if (!dr.IsDBNull(1))
                                sonuc.Add(dr.GetValue(1));
                            if (!dr.IsDBNull(2))
                                sonuc.Add(dr.GetValue(2));
                            if (!dr.IsDBNull(3))
                                sonuc.Add(dr.GetValue(3));

                            if (dr != null) dr.Close();
                            return sonuc;
                        }
                    }
                    #endregion
                    #region -- Stok Dosyası (Dosya Stok Kodu ile oluşur.)
                    comm = ora.CreateCommand();
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = @"SELECT M.ITEM_ID, 69076 as releationid, 1690415898 as RelationObject, 4 as dosya
FROM UYUMSOFT.INVD_BRANCH_ITEM B INNER JOIN UYUMSOFT.INVD_ITEM M ON B.ITEM_ID = M.ITEM_ID
WHERE B.BRANCH_ID = 1010 AND B.CO_ID = 191 AND M.ITEM_CODE = :dosyaadi";
                    comm.Parameters.AddWithValue(":dosyaadi", dosyaAd);
                    using (OracleDataReader dr = comm.ExecuteReader())
                    {
                        if (dr != null && dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                                sonuc.Add(dr.GetValue(0));
                            if (!dr.IsDBNull(1))
                                sonuc.Add(dr.GetValue(1));
                            if (!dr.IsDBNull(2))
                                sonuc.Add(dr.GetValue(2));
                            if (!dr.IsDBNull(3))
                                sonuc.Add(dr.GetValue(3));

                            if (dr != null) dr.Close();
                            return sonuc;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Trace.WriteLine("Dosya tipi bulmada hata!");
                System.Diagnostics.Trace.WriteLine(exc.Message);
                System.Diagnostics.Trace.WriteLine(exc.StackTrace);
                MessageBox.Show("Dosya tipi bulmada hata! " + exc.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sonuc.TrimExcess();
            }
            return sonuc;
        }
    }
}
