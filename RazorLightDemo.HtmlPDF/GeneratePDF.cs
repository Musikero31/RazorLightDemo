using WkHtmlToPdfDotNet;

namespace RazorLightDemo.HtmlPDF
{
    public class GeneratePDF : IGeneratePDF
    {
        public byte[] GenerateByteArray(string html)
        {
            var pdfConverter = new BasicConverter(new PdfTools());

            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.Letter,
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = html,
                        PagesCount = true,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }

                    }
                }
            };

            return pdfConverter.Convert(doc);
        }

        public void GeneratePDFFile(string html)
        {
            var pdfConverter = new BasicConverter(new PdfTools());

            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.Letter,
                    // For test purposes
                    Out = @"C:\DEV\test.pdf"
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = html,
                        PagesCount = true,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }

                    }
                }
            };

            pdfConverter.Convert(doc);
        }
    }
}
