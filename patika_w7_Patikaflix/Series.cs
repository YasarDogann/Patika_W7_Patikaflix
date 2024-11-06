using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_w7_Patikaflix
{
    public class Series
    {
        // Özellikler - Properties
        public string SerieName { get; set; }
        public int DebutYear { get; set; }
        public string Type { get; set; }
        public int PremiereDate { get; set; }
        public string Directors { get; set; }
        public string Platform { get; set; }

        // Boş Yapıcı method
        public Series() { }

        // parametreli yapıcı method
        public Series(string serieName, int debutYear, string type, int premierDate, string directors, string platform)
        {
            SerieName = serieName;
            DebutYear = debutYear;
            Type = type;
            PremiereDate = premierDate;
            Directors = directors;
            Platform = platform;
        }

        // dizi bilgilerini string formata dönüştüren object sınıfından override edilen ToString methodu
        public override string ToString()
        {
            return $"Dizi Adı: {SerieName.PadRight(20)}  Yapım Yılı: {DebutYear}     Türü: {Type.PadRight(10)} " +
                $"Yayınlanma Tarihi: {PremiereDate}      Yönetmenler: {Directors.PadRight(10)} Platform: {Platform}  ";
        }

    }
}
