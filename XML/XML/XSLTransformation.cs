using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace XML
{
    class XSLTransformation
    {
        public string fileXSL;

        public void Transform(string fileRead, string fileWrite)
        {
            XslTransform transform;
            transform = new XslTransform();
            transform.Load(fileXSL);
            transform.Transform(fileRead, fileWrite);
        }
    }
}
