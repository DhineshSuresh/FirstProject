using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iText;
using iText.Html2pdf;
using iText.StyledXmlParser;
using System.IO;
using System.Data;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.IO.Font;
using HtmlAgilityPack;
using iTextSharp.xmp.impl;
using iText.Layout.Properties;
using System.Web.WebPages;
using iText.IO.Util;
using iText.IO.Image;
using System.Xml;
using iText.Layout.Renderer;
using iText.Layout.Layout;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Annot;
using Spire.Pdf.General;
using iText.Kernel.Pdf.Navigation;
using static iText.IO.Util.IntHashtable;

namespace PDF.Controllers
{
    public class PdfIText7Controller : Controller
    {
        public PdfFont bold { get; private set; }
        public object CsvTo2DList { get; private set; }

        // GET: PdfIText7
        public ActionResult Index()
        {
            return View();
        }


        public class MyCanvasRenderer : CanvasRenderer
        {
            protected internal bool full = false;

            public MyCanvasRenderer(Canvas canvas) : base(canvas)
            {
            }

            public override void AddChild(IRenderer renderer)
            {
                //renderer = new LinkRenderer(renderer);
                //base.ApplyLinkAnnotation();
                base.AddChild(renderer);

               // base.AddAllProperties();
                full = true.Equals(GetPropertyAsBoolean(Property.FULL));
            }

            public virtual bool Full
            {
                get
                {
                    return full;
                }
            }
        }
        static string htmlResult = "";
        private bool newWindow;

        public static void iterateNodes(HtmlNodeCollection htc)
        {
            try
            {
                foreach (var item in htc)
                {
                    if (item.HasChildNodes)
                        iterateNodes(item.ChildNodes);
                    else
                    {
                        if (item.Name == "img")
                            item.Attributes.Add("class", "img");
                        if (item.Name == "a")
                            item.Attributes.Add("class", "a");
                    }
                    htmlResult += item.OuterHtml;
                }

                string h1 = htmlResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void multilayoutpdf()
        {

            // string htmltext = "Indented paragraphs demonstrated in the US Constitution In ancient manuscripts, another means to divide sentences into paragraphs was a line break (newline)followed by an initial at the beginning of the next paragraph. An initial is an oversized capital letter, sometimes outdented beyond the margin of the text. This style can be seen, for example, in the original Old English manuscript of Beowulf.Outdenting is still used in English typography, though not commonly.[3] Modern English typography usually indicates a new paragraph by indenting the first line.This style can be seen in the(handwritten) United States Constitution from 1787.For additional ornamentation, a hedera leaf or other symbol can be added to the inter - paragraph whitespace, or put in the indentation space.";
            try
            {
                System.IO.File.Delete(@"E:\\PDF\\Twocolumns10.pdf");
            }
            catch (Exception e) { }



            string arrowfontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Arrows.ttf";

            PdfFont arrowfont = PdfFontFactory.CreateFont(arrowfontpath, PdfEncodings.IDENTITY_H, true);

            PdfWriter pdfwrite = new PdfWriter("E:\\PDF\\Twocolumns11.pdf");
            PdfDocument pdf = new PdfDocument(pdfwrite);

            Document document = new Document(pdf);
            int nPage = 0;
            PdfPage page;
            PdfCanvas pdfCanvas;
            Rectangle rectangle;
            Canvas canvas;
            MyCanvasRenderer renderer;
            Paragraph P;

            page = pdf.AddNewPage();
            nPage++;
            pdfCanvas = new PdfCanvas(page);
            rectangle = new Rectangle(30, 40, 510, 750);
            canvas = new Canvas(pdfCanvas, pdf, rectangle);

            //Link l = new Link("here", PdfAction.CreateURI("www.google.com"));



           
            renderer = new MyCanvasRenderer(canvas);

            canvas.SetRenderer(renderer);



           

            for (int i = 0; i < 20; i++)
            {
                float rx = renderer.GetCurrentArea().GetBBox().GetX();
                float ry = renderer.GetCurrentArea().GetBBox().GetY();
                float height = renderer.GetCurrentArea().GetBBox().GetHeight();
                float width = renderer.GetCurrentArea().GetBBox().GetHeight();

                P = new Paragraph("welcome");

             
                Link link = new Link("Click here", PdfAction.CreateGoToR("Hello", "http: // www.tutorialspoint.com/"));
                P.Add("welcome");
                P.Add(link.SetUnderline()).SetFixedPosition(ry, width, height);
                P.Add("welcome");

                canvas.Add(P);

               // document.Add(P);

            }

            //////page = pdf.AddNewPage();

            ////rectangle = new Rectangle(30, 150, 250, 500);
            ////pdfCanvas = new PdfCanvas(page);
            ////canvas = new Canvas(pdfCanvas, pdf, rectangle);
            ////renderer = new MyCanvasRenderer(canvas);
            ////canvas.SetRenderer(renderer);


            ////int nBlock = 2;
            ////int b;

            ////for (int y = 0; y < 10; y++)
            ////{

            ////    // string pp = "1234567890-=asdfghjkl;'zxcvbnm,./";

            ////    string pp = "Hear";



            ////    //string pp = "!@#$%%^&*()_+QWERTYUIOPASDFGHJKLZXCVBNM{}|";

            ////    //string pp = "!@#$%%^&*()_";


            ////    // P = new Paragraph().Add(new Link("Google", PdfAction.CreateGoToR("HELLO", "www.google.com"))).SetFixedPosition(36, 650, 80);

            ////    //float rheight = renderer.GetOccupiedArea().GetBBox().GetHeight();
            ////    //float rwidght = renderer.GetOccupiedArea().GetBBox().GetHeight();
            ////    //float rx = renderer.GetOccupiedArea().GetBBox().GetX();
            ////   // float ry = renderer.GetOccupiedArea().GetBBox().GetY();



            ////    // Table table = new Table(1);
            ////    // table.SetWidth(500);
            ////    // Cell cell = new Cell();
            ////    // Paragraph p = new Paragraph();
            ////    //// Link link = new Link("link to top of next page", null);

            ////    // p.SetAction(null);

            ////    // cell.Add(p);
            ////    // table.AddCell(cell);



            ////    //PdfAction action = PdfAction.CreateURI("http: // www.tutorialspoint.com/");
            ////    //annotation.SetAction(action);

            ////    //Link link = new Link("Click here", annotation);

            ////    // iText.Kernel.Pdf.Navigation.PdfDestination jekyll =PdfExplicitDestination.CreateFitH(1, 416);

            ////    // P = new Paragraph(new Link("here" , jekyll));

            ////    //// P.Add(link.SetUnderline());

            ////    //            String url = String.Format(
            ////    //"http://www.imdb.com/title/tt%s", record.get(0));

            ////    //PdfDestination destination = new PdfDestination();
            ////    // P.SetAction(PdfAction.CreateJavaScript("app.alert('Boo!');"));

            ////    //P = new Paragraph().Add(new Link("Google", PdfAction.CreateGoTo("www.google.com")));

            ////    //P = new Paragraph(new Link("Link", iText.Kernel.Pdf.Action.PdfAction.CreateGoTo("dest2")));



            ////    //Text t = new Text("This certificate is an important document");

            ////    if (renderer.Full)
            ////    {
            ////        if (nBlock == 1)
            ////        {
            ////            rectangle = new Rectangle(30, 30, 250, 750);
            ////            nBlock = 2;
            ////            page = pdf.AddNewPage();
            ////            nPage++;
            ////        }
            ////        else
            ////        {
            ////            if (nPage == 1)
            ////            {
            ////                rectangle = new Rectangle(300, 150, 250, 500);
            ////            }
            ////            else
            ////            {
            ////                rectangle = new Rectangle(300, 30, 250, 750);
            ////            }
            ////            nBlock = 1;
            ////        }

            ////        pdfCanvas = new PdfCanvas(page);
            ////        canvas = new Canvas(pdfCanvas, pdf, rectangle);
            ////        renderer = new MyCanvasRenderer(canvas);
            ////        canvas.SetRenderer(renderer);
            ////       // document.Add(P);
            ////       canvas.Add(P);
            ////        //canvas.Add(newstr);
            ////    }
            ////    else
            ////    {
            ////        //document.Add(P);
            ////        canvas.Add(P);
            ////        // canvas.Add(P);
            ////        //canvas.Add(newstr);
            ////    }



            ////}




            document.Close();
                pdf.Close();


            

        }


    }


}




   