namespace RazorLightDemo.Lib
{
    public class ParseableTemplate
    {
        public string UnparsedTemplate { get; private set; }
        public string Name { get; private set; }

        public ParseableTemplate(string unparsedTemplate, string name)
        {
            UnparsedTemplate = unparsedTemplate;
            Name = name;
        }
    }
}
