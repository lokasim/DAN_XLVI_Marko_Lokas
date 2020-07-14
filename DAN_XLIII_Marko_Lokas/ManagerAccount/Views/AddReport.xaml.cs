using ManagerAccount.ViewModels;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerAccount.Views
{
    /// <summary>
    /// Interaction logic for AddReport.xaml
    /// </summary>
    public partial class AddReport : Window
    {
        public AddReport()
        {
            InitializeComponent();
            this.DataContext = new AddReportViewmodel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
            txtProject.Focus();
        }

        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                // throw;
            }
        }
    }
}
