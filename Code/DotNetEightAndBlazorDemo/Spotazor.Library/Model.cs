namespace Spotazor.Library;

/// <summary>
/// Model
/// </summary>
public class Model
{
	/// <summary>
	/// Spotify Url
	/// </summary>
	public string? Url { get; set; }

	/// <summary>
	/// Spotify Uri
	/// </summary>
	public string? Uri { get; set; }

	/// <summary>
	/// Spotify Code
	/// </summary>
	public string? SpotifyCode { get; set; }

	/// <summary>
	/// Spotify Embed Response
	/// </summary>
	public SpotifyEmbedResponse? Embed { get; set; }

	/// <summary>
	/// Spotify Code Request
	/// </summary>
	public SpotifyCodeRequest Request { get; set; } = new();
}
