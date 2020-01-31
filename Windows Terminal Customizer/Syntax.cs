using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Terminal_Customizer
{
    public class Syntax
    {
        public List<Language> languages { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public List<Token> tokens { get; set; }
    }

    public class Token
    {
        public string name { get; set; }
        public string color { get; set; }
    }
}
