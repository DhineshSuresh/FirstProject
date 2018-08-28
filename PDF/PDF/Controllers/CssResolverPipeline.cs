namespace PDF.Controllers
{
    internal class CssResolverPipeline : IPipeline
    {
        private object cssResolver;
        private HtmlPipeline htmlPipeline;

        public CssResolverPipeline(object cssResolver, HtmlPipeline htmlPipeline)
        {
            this.cssResolver = cssResolver;
            this.htmlPipeline = htmlPipeline;
        }
    }
}