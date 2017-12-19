using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ManifestGenerator
{
    public class StringNumberParser
    {
        public static void ParseString()
        {
            using (StreamReader sr = new StreamReader("injectedVersionNumber.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.WriteLine(line);
                }
            } 
        }
    }
}
