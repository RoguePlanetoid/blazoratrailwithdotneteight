namespace Spotazor.Library;

/// <summary>
/// Spotify URI Provider
/// </summary>
public class SpotifyUriProvider
{
    private const string endpoint = "https://open.spotify.com";
    private const string prefix = "spotify";
    private const char slash = '/';
    private const char colon = ':';

    /// <summary>
    /// Get Spotify Uri
    /// </summary>
    /// <param name="url">Spotify Url e.g. open.spotify.com/artist/562Od3CffWedyz2BbeYWVn</param>
    /// <returns>Spotify Uri</returns>
    public string? GetSpotifyUri(string url)
    {
        string? result = null;
        if(url.StartsWith(endpoint, StringComparison.InvariantCultureIgnoreCase))
        {
            var source = new Uri(url);
            var path = source.AbsolutePath.Replace(slash, colon);
            result = $"{prefix}{path}";
        }
        return result;
    }
}