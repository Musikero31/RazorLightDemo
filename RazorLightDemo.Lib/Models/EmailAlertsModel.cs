namespace RazorLightDemo.Lib.Models
{
    public class EmailAlertsModel
    {
        public string? PhotoUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/8/87/Smiley_Face.JPG";
        public string? Body { get; set; } = "This is a good body";

        public int Year { get; } = DateTime.Now.Year;
    }
}
