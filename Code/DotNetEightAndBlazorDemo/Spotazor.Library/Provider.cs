namespace Spotazor.Library;

/// <summary>
/// Provider
/// </summary>
/// <param name="uriProvider">Spotify Uri Provider</param>
/// <param name="codeProvider">Spotify Code Provider</param>
/// <param name="embedProvider">Spotify Embed Provider</param>
public class Provider(
	SpotifyUriProvider uriProvider,
	SpotifyCodeProvider codeProvider,
	SpotifyEmbedProvider embedProvider)
{
    /// <summary>
    /// Get Model
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Model</returns>
    public async Task<Model> GetModel(Model model)
    {
		if (model.Url != null)
		{
			model.Embed = await embedProvider.GetSpotifyEmbed(model.Url);
			if (model.Embed != null)
			{
				model.Uri = uriProvider.GetSpotifyUri(model.Url);
                GetCode(model);
            }
		}
        return model;
	}

    /// <summary>
    /// Get Code
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Model</returns>
    public Model? GetCode(Model? model)
    {
        if (model?.Uri != null)
           model.SpotifyCode = codeProvider.GetSpotifyCode(model!.Uri, model.Request);
        return model;
    }
}
