using System;

namespace Spotazor.Library;

/// <summary>
/// Spotify Code Bar Colour
/// </summary>
public enum SpotifyCodeBar
{
    White,
    Black
}

/// <summary>
/// Spotify Code Format
/// </summary>
public enum SpotifyCodeFormat
{
    SVG,
    PNG,
    JPEG
}

/// <summary>
/// Spotify Code Request
/// </summary>
public class SpotifyCodeRequest
{
	private const string endpoint = "https://scannables.scdn.co/uri/plain";
	private const char hash = '#';

	/// <summary>
	/// Background Colour
	/// </summary>
	public string Background { get; set; } = "#000000";

    /// <summary>
    /// Bar Colour
    /// </summary>
    public SpotifyCodeBar Bar { get; set; } = SpotifyCodeBar.White;

    /// <summary>
    /// Size
    /// </summary>
    [Range(265, 2047)]
    public int Size { get; set; } = 640;

    /// <summary>
    /// Format
    /// </summary>
    public SpotifyCodeFormat Format { get; set; } = SpotifyCodeFormat.PNG;
}
