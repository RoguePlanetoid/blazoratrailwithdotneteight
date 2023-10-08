// New Alias Any Type, Existing Pattern Matching & String Interpolation

using Coord = (int x, int y);
using Winnie = (int x, int y, int z);

static void Pattern(object source) =>
	Console.WriteLine(source switch
	{
		Coord coordinate => $"X:{coordinate.x},Y:{coordinate.y}",
		Winnie pointOfOrigin => $"X:{pointOfOrigin.x},Y:{pointOfOrigin.y},Z:{pointOfOrigin.z}",
		_ => "Unknown",
	});

Pattern(1);
Pattern(new Coord(100, 200));
Pattern(new Winnie(100, 200, 300));

// Existing Local Method

static void Output(List<string> data) =>
	Console.WriteLine(string.Join(',', data));

// New Collection Expression, JSON Serialisation of Additional Types & Existing Generic List

List<string> days = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];
var json = JsonSerializer.Serialize(
	new DemoObject(Half.MaxValue, Int128.MaxValue)
	{
		Days = days
	});
Console.WriteLine(json);

DemoObject? demoObject = JsonSerializer.Deserialize<DemoObject>(json);
Output(demoObject!.Days);

// New Optional Parameters in Lambda, Inline Collection Spread Syntax & Existing LINQ Expression

var every = (string[] source, int other = 2) =>
	source
	.Where((x, i) => i % other == 0)
	.ToList();

Output(every([.. demoObject.Days]));
Output(every([.. demoObject.Days], 3));

// New Allowed Values Validation

demoObject.Days.Add("Today");
var results = new List<ValidationResult>();
if (!Validator.TryValidateObject(demoObject, new ValidationContext(demoObject), results, true))
{
	Output(results.Select(s => s.ToString()).ToList());
}

// New Keyed Dependency Injection, Time Abstraction & TimeProvider Testing Package

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddKeyedSingleton("yesterday",
	new FakeTimeProvider(DateTime.UtcNow.AddDays(-1))
	{
		AutoAdvanceAmount = TimeSpan.FromSeconds(1)
	});
builder.Services.AddKeyedSingleton("today",
	new FakeTimeProvider(DateTime.UtcNow)
	{
		AutoAdvanceAmount = TimeSpan.FromSeconds(1)
	});
var host = builder.Build();

static void Provider(TimeProvider? timeProvider)
{
	for (int i = 0; i < 5; i++)
	{
		Console.WriteLine(timeProvider?.GetUtcNow());
	}
}

var yesterday = host.Services.GetKeyedService<FakeTimeProvider>("yesterday");
Provider(yesterday);

var today = host.Services.GetKeyedService<FakeTimeProvider>("today");
Provider(today);