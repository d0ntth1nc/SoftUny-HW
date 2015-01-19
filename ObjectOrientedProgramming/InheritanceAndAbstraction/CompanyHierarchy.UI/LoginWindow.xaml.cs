using System.Windows;

namespace CompanyHierarchy.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public delegate void LoggedInHandler();
        public event LoggedInHandler OnLoggedIn;


        public LoginWindow(string url)
        {
            InitializeComponent();
            this.loginBrowser.Navigating += OnNavigating;
            this.loginBrowser.Navigate(url);
        }

        private void OnNavigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.Uri.Host == "google.bg")
            {
                OnLoggedIn();
            }
        }
    }
}
