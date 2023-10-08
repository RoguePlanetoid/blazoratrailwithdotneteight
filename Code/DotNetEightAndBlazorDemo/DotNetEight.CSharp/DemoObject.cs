namespace DotNetEight.CSharp;

// New Primary Constructor
public class DemoObject(Half _half, Int128 _oneTwoEight)
{
	// New Non-Public Constructor for JSON
	[JsonConstructor]
	internal DemoObject() : this(Half.Zero, Int128.Zero) { }

    // New Non-Public Members for JSON
    [JsonInclude]
	internal Half Half = _half;

	// New ReadOnly Properties for JSON
	public Int128 OneTwoEight { get; } = _oneTwoEight;

	// New Allowed Values Validation Attribute
	[AllowedValues("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun")]
	public List<string> Days { get; set; } = new();
}