namespace PDF.Controllers
{
    internal class HtmlPipeline
    {
        private HtmlPipelineContext htmlContext;
        private PdfWriterPipeline pdfWriterPipeline;

        public HtmlPipeline(HtmlPipelineContext htmlContext, PdfWriterPipeline pdfWriterPipeline)
        {
            this.htmlContext = htmlContext;
            this.pdfWriterPipeline = pdfWriterPipeline;
        }
    }
}