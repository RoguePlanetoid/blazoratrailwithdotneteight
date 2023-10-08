namespace Spotazor.Library;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add Provider
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <returns>Service Collection</returns>
    public static IServiceCollection AddProvider(this IServiceCollection services) =>
        services
        .AddScoped<SpotifyEmbedProvider>()
        .AddScoped<SpotifyCodeProvider>()
        .AddScoped<SpotifyUriProvider>()
        .AddScoped<Provider>();
}
