namespace Spotazor.Hybrid;

/// <summary>
/// Application Provider
/// </summary>
public class ApplicationProvider
{
	private const char colon = ':';
    private const char dash = '-';

    private readonly HttpClient _httpClient;
    private readonly Provider _provider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="provider">Provider</param>
    public ApplicationProvider(HttpClient client, Provider provider) =>
        (_httpClient, _provider, Content) = (client, provider, 
            new ContentModel(async (p) => await Accept(), async (p) => await Save()));

    /// <summary>
    /// Accept
    /// </summary>
    private async Task Accept()
    {
        Content.IsLoaded = false;
        Content.Model = await _provider.GetModel(Content.Model);
        Content.IsLoaded = Content.Model.Embed != null;
    }

    /// <summary>
    /// Download
    /// </summary>
    /// <param name="filename">Filename</param>
    private async Task Download(string filename)
    {
		try
		{
			_httpClient.DefaultRequestHeaders.Clear();
            if(Content.Model.Request.Format == SpotifyCodeFormat.SVG)
            {
                var dialog = new ColorDialog()
                {
                    Color = Content.Model.Request.Bar == 
                        SpotifyCodeBar.White ? 
                        Color.FromArgb(255, 255, 255, 255) : 
                        Color.FromArgb(255, 0, 0, 0)
                };
                var source = ColorTranslator.ToHtml(dialog.Color).ToLower();
				if(dialog.ShowDialog() == DialogResult.OK)
                {
					var target = ColorTranslator.ToHtml(dialog.Color).ToLower();
					var content = await _httpClient.GetStringAsync(Content.Model.SpotifyCode);
                    await File.WriteAllTextAsync(filename, content.Replace(source, target));
				}
			}
            else
            {
				var bytes = await _httpClient.GetByteArrayAsync(Content.Model.SpotifyCode);
				await File.WriteAllBytesAsync(filename, bytes);
			}           
		}
		catch (Exception)
		{
		}
	}

    /// <summary>
    /// Save
    /// </summary>
    private async Task Save()
    {
		if (Content?.Model is not null)
		{
			var filename = Content?.Model?.Uri?.Replace(colon, dash);
			var format = Enum.GetName(Content!.Model.Request.Format)?.ToLower();
            _provider.GetCode(Content.Model);
            var dialog = new SaveFileDialog
            {
                FileName = filename,
                DefaultExt = $".{format}",
                Filter = $"{format?.ToUpper()}|*.{format}"
			};
			var result = dialog.ShowDialog();
            if (result == true && dialog.FileName != null)
                await Download(dialog.FileName);
		}
	}

    /// <summary>
    /// Content
    /// </summary>
    public ContentModel Content { get; private set; }
}
