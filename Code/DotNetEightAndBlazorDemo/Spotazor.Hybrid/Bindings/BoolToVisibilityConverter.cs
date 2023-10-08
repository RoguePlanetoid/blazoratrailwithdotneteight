namespace Spotazor.Hybrid.Bindings;

/// <summary>
/// Bool to Visibility Converter
/// </summary>
public class BoolToVisibilityConverter : IValueConverter
{
	/// <summary>
	/// Convert
	/// </summary>
	/// <param name="value">Source Boolean</param>
	/// <param name="targetType">Target Type</param>
	/// <param name="parameter">Parameter</param>
	/// <param name="culture">Culture</param>
	/// <returns>Target Visibility</returns>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
		(bool)value ? Visibility.Visible : Visibility.Collapsed;

	/// <summary>
	/// Convert Back
	/// </summary>
	/// <param name="value">Source Visibility</param>
	/// <param name="targetType">Target Type</param>
	/// <param name="parameter">Parameter</param>
	/// <param name="culture">Culture</param>
	/// <returns>Target Boolean</returns>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
		value is Visibility visibility && visibility == Visibility.Visible;
}