namespace Spotazor.Hybrid;

/// <summary>
/// Extensions
/// </summary>
internal static class Extensions
{
    /// <summary>
    /// Add Blazor
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <returns>Service Collection</returns>
    private static IServiceCollection AddBlazor(this IServiceCollection services)
    {
        services.AddWpfBlazorWebView();
        return services;
    }

	/// <summary>
	/// Add Http Client
	/// </summary>
	/// <param name="services">Service Collection</param>
	/// <returns>Service Collection</returns>
	private static IServiceCollection AddHttpClient(this IServiceCollection services) => 
        services.AddScoped(sp => new HttpClient());

	/// <summary>
	/// Add Services
	/// </summary>
	/// <param name="services">Service Collection</param>
	/// <returns>Service Collection</returns>
	public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
        .AddSingleton<MainWindow>()
        .AddSingleton<ApplicationProvider>()
        .AddHttpClient()
        .AddBlazor()
        .AddProvider();
}
