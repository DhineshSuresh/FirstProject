using iTextSharp.text.pdf;

namespace PDF.Controllers
{
    internal class PdfWriterPipeline
    {
        private object document;
        private PdfWriter writer;

        public PdfWriterPipeline(object document, PdfWriter writer)
        {
            this.document = document;
            this.writer = writer;
        }
    }
}