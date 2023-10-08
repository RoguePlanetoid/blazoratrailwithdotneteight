using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Spotazor.Hybrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Host
        /// </summary>
        public static IHost? Host { get; private set; }

        /// <summary>
        /// Start Service Host
        /// </summary>
        private static async Task StartServiceHostAsync()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices(services => services.AddServices()).Build();
            await Host!.StartAsync();
        }

        /// <summary>
        /// Stop Service Host
        /// </summary>
        private static async Task StopServiceHostAsync() =>
            await Host!.StopAsync();

        /// <summary>
        /// On Startup
        /// </summary>
        /// <param name="e">Startup Event Args</param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            await StartServiceHostAsync();
            Host?.Services.GetRequiredService<MainWindow>()?.Show();
            base.OnStartup(e);
        }

        /// <summary>
        /// On Exit
        /// </summary>
        /// <param name="e">Exit Event Args</param>
        protected override async void OnExit(ExitEventArgs e)
        {
            await StopServiceHostAsync();
            base.OnExit(e);
        }
    }

}
