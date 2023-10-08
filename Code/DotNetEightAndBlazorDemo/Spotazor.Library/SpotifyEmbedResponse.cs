namespace Spotazor.Library;

/// <summary>
/// Spotify Embed Response
/// </summary>
public class SpotifyEmbedResponse
{
    /// <summary>
    /// Type of oEmbed
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// oEmbed version number
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    /// <summary>
    /// HTML of an Embed for this item
    /// </summary>
    [JsonPropertyName("html")]
    public required string Html { get; set; }

    /// <summary>
    /// Width in pixels of the Embed
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Height in pixels of the Embed
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Provider name for the oEmbed
    /// </summary>
    [JsonPropertyName("provider_name")]
    public string? ProviderName { get; set; }

    /// <summary>
    /// Provider URL
    /// </summary>
    [JsonPropertyName("provider_url")]
    public string? ProviderUrl { get; set; }

    /// <summary>
    /// Title of the item
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// URL of a thumbnail image for the item
    /// </summary>
    [JsonPropertyName("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }

    /// <summary>
    /// Width of the thumbnail image
    /// </summary>
    [JsonPropertyName("thumbnail_width")]
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Height of the thumbnail image
    /// </summary>
    [JsonPropertyName("thumbnail_height")]
    public int? ThumbnailHeight { get; set; }

    /// <summary>
    /// URL for Embed
    /// </summary>
    [JsonPropertyName("iframe_url")]
    public string? IFrameUrl { get; set; }
}
