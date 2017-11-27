using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlastBoard
{
    class RemoteMessageToSend
    {
        public RemoteMessageToSend(string m, bool l, int lV, bool L, bool o, int oV, string cL, System.Windows.Forms.ComboBox.ObjectCollection lL, List<MusicButtonInfo> b)
        {
            message = m;
            data = new RemoteData(m, l, lV, L, o, oV, cL, lL, b);
        }

        public string message;
        public RemoteData data;

        public class RemoteData
        {
            public RemoteData(string m, bool l, int lV, bool L, bool o, int oV, string cL, System.Windows.Forms.ComboBox.ObjectCollection lL, List<MusicButtonInfo> b)
            {
                if (m == "full" || m == "audio"){
                    audio = new DataAudio(l, lV, L, o, oV);
                }
                if (m == "full" || m == "layout"){
                    layout = new DataLayout(cL, lL, b);
                }
            }

            public DataAudio audio;
            public DataLayout layout;

            public class DataAudio
            {
                public DataAudio(bool l, int lV, bool L, bool o, int oV)
                {
                    local = l;
                    localVolume = lV;
                    link = L;
                    output = o;
                    outputVolume = oV;
                }

                public bool local;
                public int localVolume;
                public bool link;
                public bool output;
                public int outputVolume;
            }

            public class DataLayout
            {
                public DataLayout(string cL, System.Windows.Forms.ComboBox.ObjectCollection lL, List<MusicButtonInfo> b)
                {
                    currentLayout = cL;
                    foreach (var layout in lL)
                    {
                        layoutList.Add(layout.ToString());
                    }
                    foreach (MusicButtonInfo mb in b)
                    {
                        buttons.Add(new MusicButtonInfoForRemote(mb));
                    }
                }

                public string currentLayout;
                public List<string> layoutList = new List<string>();
                public List<MusicButtonInfoForRemote> buttons = new List<MusicButtonInfoForRemote>();

                public class MusicButtonInfoForRemote
                {
                    public string text;
                    public string textColor;
                    public string image;
                    public string background;

                    public MusicButtonInfoForRemote(MusicButtonInfo mb)
                    {
                        text = mb.text;
                        textColor = ColorTranslator.ToHtml(mb.textColor);
                        image = "";
                        background = "";
                        if (mb.image != "")
                        {
                            using (var ms = new MemoryStream())
                            {
                                Image tempImg = Image.FromFile(mb.image);
                                tempImg.Save(ms, tempImg.RawFormat);
                                image = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                        if (mb.background != "")
                        {
                            using (var ms = new MemoryStream())
                            {
                                Image tempBg = Image.FromFile(mb.background);
                                tempBg.Save(ms, tempBg.RawFormat);
                                background = Convert.ToBase64String(ms.ToArray());
                            }
                        }  
                    }
                }
            }
        }
    }

    class RemoteMessageReceived
    {
        public string message;
        public RemoteData data;

        public class RemoteData
        {
            public DataAudio audio;
            public DataLayout layout;

            public class DataAudio
            {
                public bool local;
                public int localVolume;
                public bool link;
                public bool output;
                public int outputVolume;
            }

            public class DataLayout
            {
                public string currentLayout;
                public List<string> layoutList;
                public List<MusicButtonInfoForRemote> buttons;

                public class MusicButtonInfoForRemote
                {
                    public string text;
                    public string textColor;
                    public string image;
                    public string background;
                }
            }
        }
    }
}
