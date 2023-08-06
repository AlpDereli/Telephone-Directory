// See https://aka.ms/new-console-template for more information
List<Kisi> Kisiler = new List<Kisi>();
islemler bu = new islemler();
Kisi Kisi1 = new Kisi();
Kisi1.ad = "Alp";
Kisi1.soyad = "Dereli";
Kisi1.no = 09999999999;
Kisiler.Add(Kisi1);

Kisi Kisi2 = new Kisi();
Kisi2.ad = "Ahmet";
Kisi2.soyad = "Hakan";
Kisi2.no = 09999999899;
Kisiler.Add(Kisi2);

bool b = true;
while (b)
{
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
    Console.WriteLine("*******************************************");
    Console.WriteLine("(1) Yeni Numara Kaydetmek");
    Console.WriteLine("(2) Varolan Numarayı Silmek");
    Console.WriteLine("(3) Varolan Numarayı Güncelleme");
    Console.WriteLine("(4) Rehberi Listelemek");
    Console.WriteLine("(5) Rehberde Arama Yapmak﻿");
    Console.WriteLine("(0) Çıkış Yapmak");
    int secim = int.Parse(Console.ReadLine());
    if (secim == 1)
    {
        bu.ekleme(Kisiler);
    }
    if (secim == 2)
    {
        bu.silme(2,Kisiler);
    }
    if (secim == 3)
    {
        bu.guncelleme(Kisiler);
    }
    if (secim == 4) 
    {
        bu.rehberyaz(Kisiler);
    }
    if (secim == 5)
    {
        bu.arama(Kisiler);
    }
    if (secim == 0)
        b = false;
}




class Kisi
{
    public string ad;
    public string soyad;
    public long no;
}

class islemler
{
    public void silme(int secim, List<Kisi> Kisiler)
    {
        if (secim == 2)
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string silinecekkisi = Console.ReadLine();
            int kontrol = 0;
            foreach (Kisi kisi in Kisiler)
            {
                if (kisi.ad == silinecekkisi || kisi.soyad == silinecekkisi)
                {
                    kontrol++;
                    Console.WriteLine(silinecekkisi + "  isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                    char s = char.Parse(Console.ReadLine());
                    if (s == 'y')
                    {
                        Kisiler.Remove(kisi);
                        break;
                    }
                    if (s == 'n')
                    {
                        break;
                    }
                }
            }
            int secim2 = 0;
            if ((kontrol == 0))
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                secim2 = int.Parse(Console.ReadLine());
            }
            if (secim2 == 2)
            {
                silme(2, Kisiler);
            }
        }
    }
    public void ekleme(List<Kisi> Kisiler)
    {
        Kisi kisi = new Kisi();
        Console.WriteLine("Lütfen isim giriniz             :");
        string isim = Console.ReadLine();
        kisi.ad = isim;
        Console.WriteLine("Lütfen soyisim giriniz          :");
        string soyisim = Console.ReadLine();
        kisi.soyad = soyisim;
        Console.WriteLine("Lütfen telefon numarası giriniz :");
        long no = long.Parse(Console.ReadLine());
        kisi.no = no;
        Kisiler.Add(kisi);
    }
    public void guncelleme(List<Kisi> Kisiler)
    {
        Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
        string guncellenecekkisi = Console.ReadLine();
        int kontrol = 0;
        foreach (Kisi kisi in Kisiler)
        {
            if (kisi.ad == guncellenecekkisi || kisi.soyad == guncellenecekkisi)
            {
                kontrol++;
                Console.WriteLine("Yeni No: ");
                long yno = long.Parse(Console.ReadLine());
                kisi.no = yno;
                break;
            }
        }
        int secim2 = 0;
        if ((kontrol == 0))
        {
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");
            secim2 = int.Parse(Console.ReadLine());
        }
        if (secim2 == 2)
        {
            guncelleme(Kisiler);
        }
    }
    public void rehberyaz(List<Kisi> Kisiler) 
    {
        Console.WriteLine("Telefon Rehberi");
        Console.WriteLine("**********************************************");
        foreach (Kisi kisi in Kisiler)
        {
            Console.WriteLine("İsim: " + kisi.ad + " Soyisim: " + kisi.soyad + " Telefon Numarası: " + kisi.no);
            Console.WriteLine("-");
        }
    }

    public void arama(List<Kisi> Kisiler)
    {
        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
        Console.WriteLine("**********************************************");
        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
        int secim3 = int.Parse(Console.ReadLine());
        List<Kisi> list = new List<Kisi>();
        if (secim3 == 1)
        {
            Console.WriteLine("Aranacak Ad veya Soyad: ");
            string ara = Console.ReadLine();
            foreach (Kisi kisi in Kisiler)
            {
                if (kisi.ad == ara || kisi.soyad == ara)
                {
                    list.Add(kisi);
                }
            }
        }
        if (secim3 == 2)
        {
            Console.WriteLine("Bulunacak Numara: ");
            long bunum = long.Parse(Console.ReadLine());
            foreach (Kisi kisi in Kisiler)
            {
                if (kisi.no == bunum)
                {
                    list.Add(kisi);
                }
            }
        }
        Console.WriteLine("Arama Sonuçlarınız:");
        Console.WriteLine("**********************************************");
        foreach (Kisi kisi in list)
        {
            Console.WriteLine("İsim: " + kisi.ad + " Soyisim: " + kisi.soyad + " Telefon Numarası: " + kisi.no);
            Console.WriteLine("-");
        }
    }
}
    

