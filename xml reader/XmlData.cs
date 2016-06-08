using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_reader
{
    class XmlData
    {
        public string title { get; set; }
       // public string text { get; set; }
        public string xmlUrl { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", xmlUrl);
        }
        public string ToString2()
        {
            return string.Format("{0}", title);
        }
      // public override string ToStringUrl()
        //{
          //  return string.Format("xmlUrl:{0}", xmlUrl);
        //}
    }
}
