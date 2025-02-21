namespace RazorLightDemo.HtmlPDF
{
    public interface IGeneratePDF
    {
        byte[] GenerateByteArray(string html);
        void GeneratePDFFile(string html);
    }
}