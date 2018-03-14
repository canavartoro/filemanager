using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public enum AktarimDurumu
    {
        //0=AKTARILACAK, 1=AKTARILDI, 2=KAYIT YOK AKTARILAMADI, 3= KOPYALANAMADI
        Bekliyor = 0,
        Aktarildi=1,
        RelationIdYok=2,
        Kopyalanamadi = 3,
        Kaydedilemedi = 4
    }
}
