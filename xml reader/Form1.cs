using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace xml_reader
{
    public partial class Form1 : Form
    {
        private int checker = 0;
        public Form1()
        {
            InitializeComponent();
           // this.BackColor = Color.FromArgb(61, 60, 60);
            this.BackColor = Color.FromArgb(40, 41, 41);
            button1.BackColor = Color.FromArgb(157, 90, 179);
            listView1.BackColor = Color.FromArgb(25, 26, 26);
        }
        #region Choose Or Drag & Drop
            //################## 1. Drag and Drop
        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dragfile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string dropfile in dragfile)
            {
                MyGlobalTrash.MiGlobalVariable = dropfile;
                checker = 1;
            }
            button1.PerformClick();  

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checker == 0)
            {
                // #################  2-ый вариaнt  Выбираем. Получаем название
                string result = "";
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "Open XML File";
                file.Filter = "XML File|*.xml";
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    result = file.FileName;
                MyGlobalTrash.MiGlobalVariable = result;
            }
  #endregion
            // ################      Заменяем текст
            StreamReader reader = new StreamReader(MyGlobalTrash.MiGlobalVariable);
            string catcher = reader.ReadToEnd();
            reader.Close();
            catcher = catcher.Replace("feeds/videos.xml?channel_id=", "channel/");

            StreamWriter writer = new StreamWriter(MyGlobalTrash.MiGlobalVariable);
            writer.Write(catcher);
            writer.Close();

            
            // ################      Открываем измененный XML Файл и загружаем его в дату.
            var list = new List<XmlData>();
            var xDoc = XDocument.Load(MyGlobalTrash.MiGlobalVariable);


            foreach (var data in xDoc.Element("opml").Element("body").Elements("outline").Elements("outline"))
            {
                list.Add(new XmlData
                {
                    title = data.Attribute("title").Value,
                   // text = data.Attribute("text").Value,
                    xmlUrl = data.Attribute("xmlUrl").Value,
                });
            }
            int kol = 0;

           // ############## Заполнение ListView

            foreach (var data in list)
            {
                ListViewItem item = new ListViewItem(data.ToString2());
                item.SubItems.Add(data.ToString());
                listView1.Items.Add(item);
              //  item.SubItems.Add(data.ToString());
              //  listView1.Items.Add(item);
              //  richTextBox1.Text += data.ToString();
              //  listView1.Items.Add(data.ToString2());

                kol = kol + 1;


            }

            richTextBox1.Text += Convert.ToString(kol);
              
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                    
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
