using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace XML
{
    class XMLSchema
    {
        public string message;
        public string Message { get => message; set => message = value; }
        static Error popup;

        public void Validation(string fileXML, string fileSchema)
        {
            try
            {
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add("http://www.example.com", fileSchema);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileXML);
                xmlDoc.Schemas = schema;
                xmlDoc.Validate(ValidationHandler);

                message = "Validation finished";
            } catch(Exception e)
            {
                message = e.Message;
                popup = new Error(e.Message);
                popup.ShowDialog();
            }
        }


        public static void ValidationHandler(object sender, ValidationEventArgs e)
        {    
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
                popup = new Error(e.Message);
                popup.ShowDialog();
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
                popup = new Error(e.Message);
                popup.ShowDialog();
            }
        }       
    }
}
