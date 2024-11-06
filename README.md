# Patika+ Week7 Patikaflix Dizi App Uygulaması
Merhaba,
Bu proje C# ile Patika+ 7.hafta Patikaflix Dizi app uygulaması için yapılmış bir uygulamadır.

## 📚 Proje Hakkında
Bu proje, aşağıdaki konuları öğrenmeye yardımcı olmak için tasarlanmıştır:
- Basit bir C# programı yazmak
- C# konsol uygulamasının yapısını anlamak
- List yapısını öğrenmek
- Döngüler'i kullanmak
- Linq yapısını kullanmak
- Class yapısı


## İstenilen Görev
Bu pratikte sizlerden bir Diziler listesi oluşturmanız ve içerisindeki nesneleri tanımlamanız bekleniyor. Elemanların oluşturuluşu Console ekranı üzerinden olacak.
Yani kullanıcıya her diziyi oluşturup listeye ekledikten sonra yeni bir dizi ekleyip eklemediğini sormamız gerekiyor.

Örnek Veriler
![g5LPfut-diziiiiler](https://github.com/user-attachments/assets/0917478b-c004-47a1-beb9-eb14894ef0ec)

Ardından aşağıda istenilen işlemleri gerçekleştiriniz.
1- İlk listenizde bulunan komedi dizilerinden yeni bir liste oluşturunuz. Bu listede yalnızca Dizi Adı / Dizi Türü / Yönetmen bilgileri yer alsın (Yani başka bir class ihtiyacınız doğuyor.
2- Bu yeni listenin bütün elemanlarını bütün özellikleriyle ekrana yazdırınız. Yazımın öncelikle dizi isimleri sonra da yönetmen isimleri baz alınarak sıralanmasına özen gösteriniz
    


## Kod: Singer Class'ı
```csharp
public class Singer 
{
    public string NameSurname { get; set; }
    public string MusicGenre { get; set; }
    public int DebutYear { get; set; }
    public double AlbumSales { get; set; }

    public Singer(string nameSurname, string musicGenre, int debutYear, double aldumSales)
    {
        NameSurname = nameSurname;
        MusicGenre = musicGenre;
        DebutYear = debutYear;
        AlbumSales = aldumSales;
    }

    public override string ToString()
    {
        // Sanatçının ad ve soyadını, müzik türünü, çıkış yılını ve albüm satışlarını belirli bir formatta döndürür.
        // 'PadRight' metodu, yazdırma işlemi sırasında her bir değerin sağda hizalanmasını sağlar.
        return $"{NameSurname.PadRight(20)} {MusicGenre.PadRight(30)} {DebutYear}         yaklaşık {AlbumSales} milyon";
    }
}
```

## Kod: Main Class

```csharp
static void Main(string[] args)
{
    // Sanatçı listesini oluşturduk ama nerdenn Singer Class'ından 
    List<Singer> singers = new List<Singer>
    {
        new Singer("Ajda Pekkan","Pop",1968,20),
        new Singer("Sezen Aksu","Türk Halk Müziği / Pop", 1971,10),
        new Singer("Funda Arar", "Pop", 1999, 3),
        new Singer("Sertab Erener", "Pop", 1994, 5),
        new Singer("Sıla", "Pop", 2009, 3),
        new Singer("Serdar Ortaç", "Pop", 1994, 10),
        new Singer("Tarkan", "Pop", 1992, 40),
        new Singer("Hande Yener", "Pop", 1999, 7),
        new Singer("Hadise", "Pop", 2005, 5),
        new Singer("Gülben Ergen", "Pop / Türk Halk Müziği", 1997, 10),
        new Singer("Neşet Ertaş", "Türk Halk Müziği / Türk Sanat Müziği", 1960, 2)
    };


    // Adı S ile başlayan sanatçılar
    Console.ForegroundColor = ConsoleColor.Green; // Yazı rengi değiştirme
    Console.WriteLine("----- S ile Başlayan Sanatçı İsimleri -----");
    Console.ResetColor();
    var singersStartingWithS = singers.Where(singers => singers.NameSurname.StartsWith("S")).ToList(); // where ile filtreledik StartWitd kullan
    singersStartingWithS.ForEach(singers => Console.WriteLine(singers)); // filtrelenen veriyi yazdırdık döngü ile


    //Albüm satışları 10 Milyon'un üzerinde olan sanatçılar
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\r\n----- 10 Milyon'dan Fazla Albüm Satan Sanatçılar -----");
    Console.ResetColor();
    var singersWithHighSales = singers.Where(s => s.AlbumSales > 10).ToList(); // 'Where' yöntemi ile 10 milyonun üzerinde albüm satan sanatçıları filtreliyoruz.
    singersWithHighSales.ForEach(singers => Console.WriteLine(singers));  // filtrelenen veriyi yazdırdık döngü ile


    //2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar. ( Çıkış yıllarına göre gruplayarak, alfabetik bir sıralı.
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\r\n----- 2000 Yılından Önce Çıkmış Pop Sanatçıları -----");
    Console.ResetColor();
    /*
     * 'Where' yöntemi ile 2000 yılından önce çıkış yapan ve pop müzik yapan sanatçıları filtreliyoruz.
     * 'OrderBy' yöntemi, filtrelenmiş sonuçları çıkış yılına göre artan sırada sıralar.
     * 'ThenBy' yöntemi, aynı çıkış yılına sahip sanatçılar arasında isimlerine göre alfabetik sıralama yapar.
     * 'ToList' yöntemi, sıralanan verileri listeye dönüştürür.
    */
    var singersBefore2000Pop = singers.Where(s => s.DebutYear < 2000 && s.MusicGenre.Contains("Pop"))
                                      .OrderBy(s => s.DebutYear)
                                      .ThenBy(s => s.NameSurname)
                                      .ToList();
    singersBefore2000Pop.ForEach(singers => Console.WriteLine(singers));


    // En Çok albüm satan sanatçı
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\r\n----- En Çok Albüm Satan Sanatçı -----");
    Console.ResetColor();
    // 'OrderByDescending' yöntemi, albüm satışlarını azalan sırada sıralar ve en yüksek satışa sahip sanatçıyı bulur.
    // 'FirstOrDefault', liste boşsa null döner.
    var topSellingSinger = singers.OrderByDescending(s => s.AlbumSales).FirstOrDefault();
    Console.WriteLine($"En Çok Albüm Satan Sanatçı : {topSellingSinger}");


    // En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\r\n----- En Yeni ve En Eski Sanatçı -----");
    Console.ResetColor();
    // 'OrderByDescending' yöntemi, çıkış yılını azalan sırada sıralar ve en yeni sanatçıyı bulur.
    // 'OrderBy' yöntemi, çıkış yılını artan sırada sıralar ve en eski sanatçıyı bulur.
    var newestSinger = singers.OrderByDescending(s => s.DebutYear).First();
    var oldestSinger = singers.OrderBy(s => s.DebutYear).FirstOrDefault();
    Console.WriteLine($"En Yeni Çıkış Yapan Şarkıcı: {newestSinger}");
    Console.WriteLine($"En Eski Çıkış Yapan Şarkıcı: {oldestSinger}");


    Console.ReadKey();
}
```






