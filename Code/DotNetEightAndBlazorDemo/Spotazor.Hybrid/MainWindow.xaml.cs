namespace Spotazor.Hybrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="application">Application</param>
        /// <param name="services">Services</param>
        public MainWindow(ApplicationProvider application, IServiceProvider services)
        {
            InitializeComponent();
            Resources.Add(nameof(services), services);
            Display.DataContext = application.Content;
        }
    }
}