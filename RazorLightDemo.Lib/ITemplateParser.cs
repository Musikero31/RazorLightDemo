namespace RazorLightDemo.Lib
{
    public interface ITemplateParser
    {
        Task<string> ParseTemplateAsync<T>(T emailModel);
    }
}
