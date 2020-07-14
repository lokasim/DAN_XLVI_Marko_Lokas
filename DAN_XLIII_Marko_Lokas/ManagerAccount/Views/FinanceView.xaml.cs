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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagerAccount.Views
{
    /// <summary>
    /// Interaction logic for FinanceView.xaml
    /// </summary>
    public partial class FinanceView : UserControl
    {
        public FinanceView()
        {
            InitializeComponent();
            this.DataContext = new FinanceViewModel(this);

        }

        private void RefreshSector_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new FinanceViewModel(this);
        }
    }
}
