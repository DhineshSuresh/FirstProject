using iTextSharp.text;

namespace PDF.Controllers
{
    internal class HeaderFooter
    {
        private Phrase footPhraseImg;
        private bool v;

        public HeaderFooter(Phrase footPhraseImg, bool v)
        {
            this.footPhraseImg = footPhraseImg;
            this.v = v;
        }
    }
}