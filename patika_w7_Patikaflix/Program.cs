namespace patika_w7_Patikaflix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Series sınıfından dinamik bir liste oluşturuluyor
            List<Series> series = new List<Series>();
            int debutYear, premiereDate;

            bool isContinue = true;

            while (isContinue)
            {
                // Kullanıcıya dizi bilgilerini sorma ve input alma
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

                // Devam edip etmeyeceği soruluyor
                if (choose == 'e' || choose == 'E') isContinue = true; // evet derse yeni dizi eklemek için döngü başına döner
                else if (choose == 'h' || choose == 'H') isContinue = false; // hayır derse döngü biter

                // Yeni bir dizi oluşturulup listeye ekleniyor
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

            // Eklenen Tüm diziler ekrana yazdırırlır
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\r\nEklenen dizizler");
            Console.ResetColor();
            foreach (Series serie in series)
            {
                Console.WriteLine(serie);
            }
        }
    }
}
