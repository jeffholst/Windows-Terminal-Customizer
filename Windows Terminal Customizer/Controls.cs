using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Terminal_Customizer
{
    public class Controls
    {
        public ProfileControl profile { get; set; }
    }

    public class ProfileControl
    {
        public List<string> fontFaces { get; set; }
        public List<string> fontSizes { get; set; }
    }
}
