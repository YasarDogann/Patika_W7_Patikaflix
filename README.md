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

- Örnek Veriler
![g5LPfut-diziiiiler](https://github.com/user-attachments/assets/0917478b-c004-47a1-beb9-eb14894ef0ec)

Ardından aşağıda istenilen işlemleri gerçekleştiriniz.
- İlk listenizde bulunan komedi dizilerinden yeni bir liste oluşturunuz. Bu listede yalnızca Dizi Adı / Dizi Türü / Yönetmen bilgileri yer alsın (Yani başka bir class ihtiyacınız doğuyor.
- Bu yeni listenin bütün elemanlarını bütün özellikleriyle ekrana yazdırınız. Yazımın öncelikle dizi isimleri sonra da yönetmen isimleri baz alınarak sıralanmasına özen gösteriniz
    


## Kod: Series Class'ı
```csharp
public class Series
{
    public string SerieName { get; set; }
    public int DebutYear { get; set; }
    public string Type { get; set; }
    public int PremiereDate { get; set; }
    public string Directors { get; set; }
    public string Platform { get; set; }

    public Series() { }
    public Series(string serieName, int debutYear, string type, int premierDate, string directors, string platform)
    {
        SerieName = serieName;
        DebutYear = debutYear;
        Type = type;
        PremiereDate = premierDate;
        Directors = directors;
        Platform = platform;
    }

    public override string ToString()
    {
        return $"Dizi Adı: {SerieName.PadRight(10)} Yapım Yılı: {DebutYear}     Türü: {Type.PadRight(10)} " +
            $"Yayınlanma Tarihi: {PremiereDate}      Yönetmenler: {Directors.PadRight(10)} Platform: {Platform}  ";
    }

}
```

## Kod: ComedySeries Class

```csharp
public class ComedySeries : Series
{
    public string SerieName { get; set; }
    public string Type { get; set; }
    public string Directors { get; set; }
    public ComedySeries(string name, string type, string directors)
    {
        SerieName = name;
        Type = type;
        Directors = directors;
    }

    public override string ToString()
    {
        return $"{SerieName.PadRight(20)} {Type.PadRight(10)} {Directors}";
    }
}
```

## Kod: Main Class

```csharp
static void Main(string[] args)
{
    List<Series> series = new List<Series>();
    int debutYear, premiereDate;

    bool isContinue = true;

    while (isContinue)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("----- DİZİ EKLEME YAPMA İŞLEMİ -----");
        Console.ResetColor();

        Console.ForegroundColor= ConsoleColor.Red;
        Console.Write("Dizinin Adı: ");
        Console.ResetColor();
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yapım Yılı: ");
        Console.ResetColor();
        string yearInput = Console.ReadLine();
        while (!int.TryParse(yearInput, out debutYear))
        {
            Console.Write("Geçerli bir yıl girin: ");
            yearInput = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Türü: ");
        Console.ResetColor();
        string type = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yayınlanma Tarihi: ");
        Console.ResetColor();
        string premiereInput = Console.ReadLine();
        while (!int.TryParse(premiereInput, out premiereDate))
        {
            Console.Write("Geçerli bir yıl girin: ");
            premiereInput = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yönetmenler: ");
        Console.ResetColor();
        string directors = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yayınlanan Platform: ");
        Console.ResetColor();
        string platform = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Devam Etmek İstiyor Musun: (Evet: E-e || Hayır: H-h)");
        Console.ResetColor();
        char choose = char.Parse(Console.ReadLine().ToLower());

        if (choose == 'e' || choose == 'E') isContinue = true;
        else if (choose == 'h' || choose == 'H') isContinue = false;

        Series newSerie = new Series(name, debutYear, type, premiereDate, directors, platform);
        series.Add(newSerie);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dizi Başarıyla Eklendi\r\n");
        Console.ResetColor();
    }


    // Komedi dizilerinden yeni bir liste olşturduk
    List<ComedySeries> comedySeriesList = series.Where(s => s.Type.Contains("Komedi"))
                                                .Select(s => new ComedySeries(s.SerieName, s.Type, s.Directors))
                                                .OrderBy(cs => cs.SerieName)
                                                .ThenBy(cs => cs.Directors)
                                                .ToList();
    // Komedi dizilerini ekrana yazdırıyoruz
    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("\nKomedi Dizileri:");
    Console.ResetColor();
    foreach (var comedySeries in comedySeriesList)
    {
        Console.WriteLine(comedySeries);
    }

    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("\r\nEklenen dizizler");
    Console.ResetColor();
    foreach (Series serie in series)
    {
        Console.WriteLine(serie);
    }
}
```





