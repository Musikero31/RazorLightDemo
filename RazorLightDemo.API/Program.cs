using RazorLight;
using RazorLight.Extensions;
using RazorLightDemo.Lib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorLight(() => new RazorLightEngineBuilder().UseEmbeddedResourcesProject(typeof(TemplateParser))
                                                                  .SetOperatingAssembly(typeof(TemplateParser).Assembly)
                                                                  .UseMemoryCachingProvider()
                                                                  .Build());

builder.Services.AddSingleton<ITemplateParser, TemplateParser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
