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

            var personalInfoParagraph = new Paragraph();
            var employee = this.employees.First(x => x.FullName.Equals(e.AddedItems[0]));
            personalInfoParagraph.Inlines.Add(new Run("Employee info:\n"));
            personalInfoParagraph.Inlines.Add(new Run(string.Format("ID: {0}\n", employee.Id)));
            personalInfoParagraph.Inlines.Add(new Run(string.Format("Name: {0}\n", employee.FullName)));
            personalInfoParagraph.Inlines.Add(new Run(string.Format("Salary: {0:0.00}lv\n", employee.Salary)));
            personalInfoParagraph.Inlines.Add(new Run(string.Format("Department: {0}\n", employee.Department)));
            if (employee is ICustomer)
            {
                personalInfoParagraph.Inlines.Add(new Run(string.Format("Net purchase amount: {0}\n",
                    (employee as ICustomer).NetPurchaseAmount)));
            }
            this.flowDocument.Blocks.Add(personalInfoParagraph);

            if (employee is IManager)
            {
                var employeesParagraph = new Paragraph();
                var sb = new StringBuilder("Employees under command:\n");
                int index = 1;
                foreach (Employee _employee in (employee as IManager).Empoyees)
                {
                    sb.AppendFormat("{0}. {1}\n", index++, _employee.FullName);
                }
                employeesParagraph.Inlines.Add(new Run(sb.ToString()));
                this.flowDocument.Blocks.Add(employeesParagraph);
            }
            else if (employee is IDeveloper)
            {
                var projectsParagraph = new Paragraph();
                var sb = new StringBuilder("Projects:\n");
                int index = 1;
                foreach (var project in (employee as IDeveloper).Projects)
                {
                    sb.AppendFormat("{0}. {1}\n", index++, project);
                }
                projectsParagraph.Inlines.Add(new Run(sb.ToString()));
                this.flowDocument.Blocks.Add(projectsParagraph);
            }
            else if (employee is ISalesEmployee)
            {
                var salesParagraph = new Paragraph();
                var sb = new StringBuilder("Sales:\n");
                int index = 1;
                foreach (var sale in (employee as ISalesEmployee).Sales)
                {
                    sb.AppendFormat("{0}. {1}\n", index++, sale);
                }
                salesParagraph.Inlines.Add(new Run(sb.ToString()));
                this.flowDocument.Blocks.Add(salesParagraph);
            }
        }
    }
}
