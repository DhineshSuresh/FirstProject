using System.Web.Mvc;
using System;
using Pechkin;
using System.Drawing.Printing;
using System.IO;
using TuesPechkin;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf.parser;


namespace PDF.Controllers
{
    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Index()
        {
            return View();
        }
        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from  a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // Close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process while trying to save : {0}", _Exception.ToString());
            }

            return false;
        }

        public ActionResult ItextSharpPdfGen()
        {


            try
            {

                string html = "";

                //var url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/Home/GenerateClientPdf";
                //var url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/Home/Pdffile";

                var url = "http://lowen.activitystaging.com:81/news-insights/client-alerts/lessons-from-merit-management-the-settlement-payment-defense-lives-if-you-are-a-financial-institution";


                var pdf = ExportPDF(url);


                string directory = "C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\";
                // Name of the PDF
                string filename = "pdf5.pdf";

                

                ByteArrayToFile(directory + filename, pdf);



       
                //Return the PDF file
                Response.Clear();

                Response.ClearContent();
                Response.ClearHeaders();

                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=EmployeeContract.pdf; size={0}", pdf.Length));
                Response.BinaryWrite(pdf);

                //string filename1 = "C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\sitecore2.pdf";
                //string filename2 = "C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\sitecore3.pdf";


                MemoryStream ms = new MemoryStream();
                ms.Write(pdf, 0, pdf.Length);
                PdfReader reader = new PdfReader(pdf);
                int n = reader.NumberOfPages;
                Rectangle psize = reader.GetPageSize(1);
                Document document = new Document(psize, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf7.pdf", FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                int p = 0;
                Console.WriteLine("There are " + n + " pages in the document.");

                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    document.NewPage();
                    p++;
                    PdfImportedPage importedPage = writer.GetImportedPage(reader, page);

                    cb.AddTemplate(importedPage, 0, 0);

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, +p + "/" + n, 44, 7, 0);
                    cb.EndText();


                }

                document.Close();


                ////Document copyDoc = new Document();
                ////PdfCopy copyPdf = new PdfCopy(copyDoc, new FileStream(filename2, FileMode.Create));
                ////copyPdf.SetPageSize(PageSize.A4.Rotate());
                ////copyDoc.Open();
                ////Font textFont = FontFactory.GetFont("Helvetica", 9, Font.NORMAL, BaseColor.BLACK);
                ////Font headerFont = FontFactory.GetFont("Helvetica", 12, Font.BOLD, BaseColor.BLACK);
                ////// read the initial pdf document
                ////PdfReader reader = new PdfReader(filename1);
                ////int totalPages = reader.NumberOfPages;


                ////PdfImportedPage copiedPage = null;
                ////iTextSharp.text.pdf.PdfCopy.PageStamp stamper = null;
                ////Image L = Image.GetInstance("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\leader1.jpg");
                ////PdfPCell cell = new PdfPCell(L);
                ////for (int i = 0; i < totalPages; i++)
                ////{
                ////    // get the page and create a stamper for that page
                ////    copiedPage = copyPdf.GetImportedPage(reader, (i + 1));
                ////    stamper = copyPdf.CreatePageStamp(copiedPage);

                ////    copyPdf.Add(L);
                ////    // add a page number to the page
                ////    //ColumnText.ShowTextAligned(stamper.GetUnderContent(), Element.ALIGN_CENTER, new Phrase((i + 1) + "/" + totalPages, textFont), 820f, 15, 0);
                ////    ColumnText.ShowTextAligned(stamper.GetUnderContent(), Element.ALIGN_CENTER, new Phrase(String.Format("Page {0} of {1}", i + 1, reader.NumberOfPages, headerFont)), 300f, 40, 0);


                ////    //ColumnText.ShowTextAligned(stamper.GetOverContent(), Element.ALIGN_CENTER, new Phrase("your page heading name", headerFont), 300f, 780, 0);


                ////    stamper.AlterContents();

                ////    // add the altered page to the new document
                ////    copyPdf.AddPage(copiedPage);
                ////}
                ////copyDoc.Close();
                ////reader.Close();

                Response.Buffer = true;
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {

            }

            return Json(1, JsonRequestBehavior.AllowGet);


        }

        //void AddPageNumber(string filename1,string filename2)
        //{
        //    byte[] bytes = File.
        //    Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        PdfReader reader = new PdfReader(bytes);
        //        using (PdfStamper stamper = new PdfStamper(reader, stream))
        //        {
        //            int pages = reader.NumberOfPages;
        //            for (int i = 1; i <= pages; i++)
        //            {
        //                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
        //            }
        //        }
        //        bytes = stream.ToArray();
        //    }
        //    File.WriteAllBytes(filename2, bytes);
        //}
        //public string ParsePdf(string fileName)
        //{
        //    if (!File.Exists(fileName))
        //        throw new FileNotFoundException("fileName");
        //    using (PdfReader reader = new PdfReader(fileName))
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        //        for (int page = 0; page < reader.NumberOfPages; page++)
        //        {
        //            string text = PdfTextExtractor.GetTextFromPage(reader, page + 1, strategy);
        //            if (!string.IsNullOrWhitespace(text))
        //            {
        //                sb.Append(Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
        //            }
        //        }

        //        return sb.ToString();
        //    }
        //}



        //private static IConverter converter = new ThreadSafeConverter(new RemotingToolset<PdfToolset>(new Win64EmbeddedDeployment(new TempFolderDeployment())));
        private static TempFolderDeployment tempFolderDeployment = new TempFolderDeployment();
        private static Win32EmbeddedDeployment win32EmbeddedDeployment = new Win32EmbeddedDeployment(tempFolderDeployment);
        private static RemotingToolset<PdfToolset> remotingToolset = new RemotingToolset<PdfToolset>(win32EmbeddedDeployment);
        private static IConverter converter = new ThreadSafeConverter(remotingToolset);
        public static byte[] ExportPDF(string url, int no_copy = 1, double zoomfactor = 1.28, int javascriptdelay = 0)
        {
            var result = (dynamic)null;

            //var _headerSettings = new HeaderSettings { HtmlUrl = "http://google.com", ContentSpacing = 10 };
            //string headerPath = Path.Combine("http://lowen.activitystaging.com:81/pdfTemplate/img/banner.jpg");

            //var _headerSettings = new HeaderSettings { HtmlUrl = "<h1><font color=red>Hello</font></H1>", ContentSpacing = 10 };
            var marginSettings = new MarginSettings { All = 2.5, Top = 5, Unit = Unit.Centimeters };
            var _footerSettings = new FooterSettings { ContentSpacing = 10, FontSize = 10, RightText = "[page] / [topage]" };

     

            try
            {
                var doc = new HtmlToPdfDocument();
                doc.Objects.Add(new ObjectSettings
                {

                    PageUrl = url,
                    WebSettings =
                {
                 //   EnableIntelligentShrinking=true,
                    EnableJavascript=true,
                    LoadImages=true,
                    PrintBackground=true,
                    EnablePlugins=true,

                },
                    LoadSettings =
                {
                    ZoomFactor=zoomfactor,
                    RenderDelay=javascriptdelay
                },
                   // HtmlText = "<h1>welcome</h1>",
                   
                //HeaderSettings = new HeaderSettings { LeftText = "Sample"},
                //HeaderSettings = _headerSettings,
                // HeaderSettings = new HeaderSettings { HtmlUrl = headerPath },
               //  HeaderSettings = { RightText = "<h1>welcome</h1>", ContentSpacing = 10 },
                  //  FooterSettings = _footerSettings,

                    // FooterSettings = new FooterSettings { LeftText = "Last", RightText = "[page]" },

                });

                


                doc.GlobalSettings.PaperSize = PaperKind.A4;
                doc.GlobalSettings.Copies = no_copy;
                result =  converter.Convert(doc);

                //remotingToolset.Unload();
            }
            catch (Exception ex)
            {
                //remotingToolset.Unload();
                result = null;
            }
            return result;
        }


    }
}