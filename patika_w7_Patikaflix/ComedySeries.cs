using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace patika_w7_Patikaflix
{
    public class ComedySeries 
    {
        // Özellikler - Properties
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
}
