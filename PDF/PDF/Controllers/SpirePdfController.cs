using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spire.Pdf;
using Spire.Pdf.HtmlToPdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using System.Threading;
using Spire.Doc;
using System.Text;



namespace PDF.Controllers
{
    public class SpirePdfController : Controller
    {
        // GET: SpirePdf
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PdfGenerationSpire()
        {
           
            PdfDocument doc = new PdfDocument();
            //doc.LoadFromFile("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf7.pdf");
            //for (int i = 0; i < doc.Pages.Count; i++)
            //{
            //    PdfImage headerImage = PdfImage.FromFile("http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png");
            //    float width = headerImage.Width / 3;
            //    float height = headerImage.Height / 3; 
            //    doc.Pages[i].Canvas.DrawImage(headerImage, 85, 20, width, height);
            //}

            //PdfDocument doc = new PdfDocument();

            var url1 = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/Home/GenerateClientPdf";
            String url = url1;
            Thread thread = new Thread(() =>
            { doc.LoadFromHTML(url, false, true, true); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
           

            //for (int i = 0; i < doc.Pages.Count; i++)
            //{
            //    string headerText = "HEADER TEXT";
            //    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 15f));
            //    SizeF size = font.MeasureString(headerText);
            //    doc.Pages[i].Canvas.DrawString(headerText, font, PdfBrushes.RoyalBlue, doc.Pages[i].Size.Width - 90 - size.Width, 35);
            //}

            doc.SaveToFile("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\output1.pdf");
            doc.Close();

            Document document = new Document();

            document.LoadFromFile("S.docx");
            document.Sections[0].AddColumn(100f, 20f);
            document.Sections[0].PageSetup.ColumnsLineBetween = true;




            //System.Diagnostics.Process.Start("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\output.pdf");

            return View();
        }
    }
}