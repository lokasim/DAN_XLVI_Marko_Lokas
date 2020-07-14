using ManagerAccount.Models;
using ManagerAccount.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
            txtWorkHours.Focus();
        }

        public AddReport(tblReport reportEdit)
        {
            InitializeComponent();

            this.DataContext = new AddReportViewmodel(this, reportEdit);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
            txtWorkHours.Focus();

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

        /// <summary>
        /// A method that allows only numbers to be entered
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Boolean NumberAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {
                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }
        private void PreviewNumberInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumberAllowed(e.Text);
        }

        private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
            }
        }
    }
}
