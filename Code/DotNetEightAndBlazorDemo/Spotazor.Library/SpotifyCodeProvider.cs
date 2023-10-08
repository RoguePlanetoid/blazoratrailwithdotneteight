namespace Spotazor.Library;

/// <summary>
/// Spotify Code Provider
/// </summary>
/// <param name="client">Http Client</param>
public class SpotifyCodeProvider()
{
    private const string endpoint = "https://scannables.scdn.co/uri/plain";
    private const char hash = '#';

    /// <summary>
    /// Get Spotify Code
    /// </summary>
    /// <param name="uri">Spotify URI</param>
    /// <param name="request">Spotify Code Request</param>
    /// <returns>Spotify Code Uri</returns>
    public string GetSpotifyCode(string? uri, SpotifyCodeRequest request)
    {
        var bar = Enum.GetName(request.Bar)?.ToLower();
        var format = Enum.GetName(request.Format)?.ToLower();
        var background = request.Background.Trim(hash).ToLower();
        return $"{endpoint}/{format}/{background}/{bar}/{request.Size}/{uri}";
    }
}
