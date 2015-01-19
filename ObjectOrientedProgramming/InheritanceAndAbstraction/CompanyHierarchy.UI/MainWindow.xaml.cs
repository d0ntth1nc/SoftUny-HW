using DropNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace CompanyHierarchy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string API_KEY = "o24yo2zc3peh4kf";
        private const string APP_SECRET = "0rt02wrcaba57v6";

        private IEnumerable<IEmployee> employees;
        private DropNetClient dropNetClient;
        private bool isAuthenticated = false;
        private Page currentPage;

        public MainWindow()
        {
            try
            {
                this.dropNetClient = new DropNetClient(API_KEY, APP_SECRET);
                this.dropNetClient.UseSandbox = true;
                this.employees = HierarchyGenerator.GenerateEmployees();

                InitializeComponent();

                this.importDataBtn.Click += (sender, eventArgs) =>
                {
                    var reportsPage = new ReportsPage(employees);
                    this.pagesFrame.Navigate(reportsPage);
                    this.currentPage = reportsPage;
                };
                this.exportToDropBoxBtn.Click += ExportToDropBoxAccount;
                this.exportToWordBtn.Click += (sender, e) =>
                {
                    try
                    {
                        ExportToWordFile(sender, e);
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                };
                this.aboutBtn.Click += ShowAboutBox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAboutBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application generates hard-coded reports!\n" +
                "It can export the reports as word file\nand upload them to DropBox account!");
        }

        private void ExportToWordFile(object sender, RoutedEventArgs e)
        {
            if (this.currentPage is ReportsPage)
            {
                var employee = this.employees.First(x => x.FullName.Equals((this.currentPage as ReportsPage).SelectedItem));
                try
                {
                    DocumentGenerator.GenerateReport(employee);
                    MessageBox.Show("Word file is ready!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application error!");
                }
            }
            else
            {
                throw new InvalidOperationException("You have not selected employee!");
            }
        }

        private void UploadFilesToDropBox(Action onSuccess, Action<Exception> errorCallback)
        {
            try
            {
                var files = Directory.GetFiles(".", "*.docx");
                foreach (var file in files)
                {
                    using (var fileStream = File.OpenRead(file))
                    {
                        this.dropNetClient.UploadFile("/", System.IO.Path.GetFileName(file), fileStream, overwrite: true);
                    }
                }
                onSuccess();
            }
            catch (Exception ex)
            {
                errorCallback(ex);
            }
        }

        private void ShowError(Exception ex)
        {
            if (ex is DropNet.Exceptions.DropboxException)
            {
                MessageBox.Show((ex as DropNet.Exceptions.DropboxException).Response.Content, "DropBox error");
            }
            else
            {
                MessageBox.Show(ex.Message, "Application error!");
            }
        }

        private void ExportToDropBoxAccount(object sender, RoutedEventArgs e)
        {
            Action onSuccess = () => MessageBox.Show("Files uploaded!", "Success");
            if (!this.isAuthenticated)
            {
                Login(() => UploadFilesToDropBox(onSuccess, ShowError));
            }
            else
            {
                Task.Run(() => UploadFilesToDropBox(onSuccess, ShowError));
            }
        }

        private void Login(Action callback)
        {
            this.dropNetClient.UserLogin = this.dropNetClient.GetToken();
            var url = this.dropNetClient.BuildAuthorizeUrl("http://google.bg");

            var loginWindow = new LoginWindow(url);
            loginWindow.OnLoggedIn += () =>
            {
                loginWindow.Close();
                this.isAuthenticated = true;
                this.dropNetClient.UserLogin = this.dropNetClient.GetAccessToken();
                Task.Run(callback);
            };
            loginWindow.ShowDialog();
        }
    }
}