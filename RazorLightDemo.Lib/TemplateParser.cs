using RazorLight;
using System.Reflection;

namespace RazorLightDemo.Lib
{
    public class TemplateParser : ITemplateParser
    {
        private readonly IRazorLightEngine _lightEngine;
        private readonly string _templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");


        public TemplateParser(IRazorLightEngine lightEngine)
        {
            _lightEngine = lightEngine;
            CompileTemplates().GetAwaiter().GetResult();
        }
                
        public async Task<string> ParseTemplateAsync<T>(T model)
        {
            var template = await _lightEngine.CompileTemplateAsync(model.GetType().FullName);
            var result = await _lightEngine.RenderTemplateAsync(template, model);


            return result.Replace("\r\n", string.Empty);
        }

        private ICollection<ParseableTemplate> GetTemplates()
        {
            List<ParseableTemplate> templates = new List<ParseableTemplate>();

            /* If no templates directory exist, return nothing */
            var templateDirectories = new DirectoryInfo(_templateFolderPath);
            if (!templateDirectories.Exists)
                return new List<ParseableTemplate>();

            var files = templateDirectories.GetFiles();
            foreach (var file in files)
            {
                var template = new ParseableTemplate(File.ReadAllText(file.FullName), file.Name.Split('.')[0]);
                templates.Add(template);
            }

            return templates;
        }

        private async Task CompileTemplates()
        {
            var templates = GetTemplates();
            foreach (var template in templates)
            {
                var typeName = $"{Assembly.GetExecutingAssembly().GetName().Name}.Models.{template.Name}Model";
                var type = Type.GetType(typeName);
                var instance = Activator.CreateInstance(type);

                await _lightEngine.CompileRenderStringAsync(typeName, template.UnparsedTemplate, instance);
            }
        }
    }
}
