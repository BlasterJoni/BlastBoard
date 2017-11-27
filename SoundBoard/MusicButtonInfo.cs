using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlastBoard
{
    class MusicButtonInfo
    {
        public string text;
        public Color textColor;
        public string file;
        public string image;
        public string background;

        public MusicButtonInfo(string text, Color textColor, string file, string image, string background)
        {
            this.text = text;
            this.textColor = textColor;
            this.file = file;
            this.image = image;
            this.background = background;
        }
    }
}
