namespace SolarSystem
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OrbitsCalculator data = new OrbitsCalculator();

        public MainWindow()
        {
            this.DataContext = this.data;
            this.InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.data.StartTimer();
        }

        private void Pause_Checked(object sender, RoutedEventArgs e)
        {
            this.data.Pause(true);
        }

        private void Pause_Unchecked(object sender, RoutedEventArgs e)
        {
            this.data.Pause(false);
        }
    }
}
