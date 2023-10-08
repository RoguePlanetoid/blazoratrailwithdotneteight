// New Direct Rendering
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddLogging();

var provider = builder.Services.BuildServiceProvider();
var factory = provider.GetRequiredService<ILoggerFactory>();

await using var renderer = new HtmlRenderer(provider, factory);
var html = await renderer.Dispatcher.InvokeAsync(async () =>
{
    var component = await renderer.RenderComponentAsync<BlazorComponent>();
    return component.ToHtmlString();
});
Console.WriteLine(html);