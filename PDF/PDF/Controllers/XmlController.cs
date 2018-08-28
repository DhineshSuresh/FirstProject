using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace PDF.Controllers
{
    public class XmlController : Controller
    {
        // GET: Xml
        public ActionResult Index()
        {
            return View();
        }

        public void GenerateXmlFile()
        {
            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            createNode("1", "Product 1", "1000", writer);
            createNode("2", "Product 2", "2000", writer);
            createNode("3", "Product 3", "3000", writer);
            createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml("E:\\XML\\Product.xml");
            //Response.ContentType = "text/xml";
            //Response.Write(doc.OuterXml);
            Response.ContentType = "text/xml";
            Response.End();

            try
            {
                System.IO.File.Delete("E:\\XML\\Product.xml");
            }
            catch (Exception ex)
            {
                //LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, ex.Message, ex.InnerException);
            }

            //MessageBox.Show("XML File created ! ");
        }

        public void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
        {
            writer.WriteStartElement("Product");
            writer.WriteStartElement("Product_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_price");
            writer.WriteString(pPrice);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}