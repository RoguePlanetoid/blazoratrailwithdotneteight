namespace Spotazor.Library;

/// <summary>
/// Spotify Embed Provider
/// </summary>
/// <param name="client">Http Client</param>
public class SpotifyEmbedProvider(HttpClient client)
{
    private const string endpoint = "https://open.spotify.com/oembed";
    private const string host = "open.spotify.com";
    private const string user_agent_header = "User-Agent";
    private const string user_agent = "Spotify";
    private const string host_header = "Host";

    /// <summary>
    /// Get Spotify Embed
    /// </summary>
    /// <param name="url">Spotify Url</param>
    /// <returns>Embed Response</returns>
    public async Task<SpotifyEmbedResponse?> GetSpotifyEmbed(string url)
    {
        if (!client.DefaultRequestHeaders.Contains(user_agent_header))
            client.DefaultRequestHeaders.Add(user_agent_header, user_agent);
        if (!client.DefaultRequestHeaders.Contains(host_header))
            client.DefaultRequestHeaders.Add(host_header, host);
        var request = $"{endpoint}?url={HttpUtility.UrlEncode(url)}";
        try
        {
			return await client.GetFromJsonAsync<SpotifyEmbedResponse>(request);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
