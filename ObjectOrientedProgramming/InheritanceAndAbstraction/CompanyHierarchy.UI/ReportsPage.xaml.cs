using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyHierarchy.UI
{
    /// <summary>
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        private IEnumerable<IEmployee> employees;

        public ReportsPage(IEnumerable<IEmployee> employees)
        {
            this.employees = employees;
            InitializeComponent();
            this.reportsContainer.SelectionChanged += ShowDetails;
            this.reportsContainer.ItemsSource = employees.Select(x => x.FullName);
            this.reportsContainer.SelectedItem = this.reportsContainer.Items[0];
        }

        public dynamic SelectedItem
        {
            get { return this.reportsContainer.SelectedItem; }
        }

        private void ShowDetails(object sender, SelectionChangedEventArgs e)
        {
            this.flowDocument.Blocks.Clear();
            var employee = this.employees.First(x => x.FullName.Equals(e.AddedItems[0]));
            var personalInfoParagraph = new Paragraph(new Run(employee.ToString()));
            this.flowDocument.Blocks.Add(personalInfoParagraph);
        }
    }
}
