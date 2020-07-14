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

namespace ManagerAccount
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        EmployeeMenu _context;
        private bool mouseClicked;

        public UserControlMenuItem(ItemMenu itemMenu, EmployeeMenu context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mouseClicked)
            {
                if (e.AddedItems.Count > 0)
                    _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
            }
            
        }
        private void ListViewMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClicked = true;

            if (ListViewMenu.SelectedItem != null)
            {
                _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
            }
        }
    }
}
