using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace xml_reader
{
    class Methods
    {
        public string title { get; set; }
        // public string text { get; set; }
        public string xmlUrl { get; set; }
       


       public void AutoUrlReplace()
        { 

            StreamReader reader = new StreamReader(MyGlobalTrash.MiGlobalVariable);
            string catcher = reader.ReadToEnd();
            catcher.Replace("feeds/videos.xml?channel_id=", "channel/");
            reader.Close();

            StreamWriter writer = new StreamWriter(MyGlobalTrash.MiGlobalVariable);
            writer.Write(catcher);
            writer.Close();
            //"D:\\Penthouse\\Комната Программирования\\Проекты Visual\\for fun\\XML Reader\\subscription_manager.xml"
        }
    }
}
