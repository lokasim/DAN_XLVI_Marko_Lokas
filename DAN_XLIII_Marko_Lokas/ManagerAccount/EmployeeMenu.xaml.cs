using ManagerAccount.ViewModels;
using ManagerAccount.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ManagerAccount
{
    /// <summary>
    /// Interaction logic for EmployeeMenu.xaml
    /// </summary>
    public partial class EmployeeMenu : Window
    {
        //readonly MainWindow main;
        //readonly Employee employee;
        public EmployeeMenu()
        {
            InitializeComponent();

            this.DataContext = new EmployeeMenuViewModel(this);

            Vreme();


            string sector = LoggedEmployee.sector.ToString();
            string position = LoggedEmployee.position.ToString();
            string access = LoggedEmployee.accessLevel.ToString();
            if (sector == "")
            {
                lblMenu.Content = $"Employee";
                lblaccess.Content = access;
                lblPosition.Content = position;
            }
            else
            {
                lblMenu.Content = $"{LoggedEmployee.sector.ToString()}";
                lblaccess.Content = "Manager: {" + access + "}";
                lblPosition.Content = position;
            }


            lblIme.Content = LoggedEmployee.name.ToString();
            lblPrezime.Content = LoggedEmployee.surname.ToString();


            if (access == "read-only")
            {

                if (sector == "Finance")
                {
                    var menuWorkHours = new List<SubItem>
                    {
                        new SubItem("Work Hours"),
                    };

                    var item1 = new ItemMenu("Work hours", menuWorkHours, PackIconKind.EuroSymbol);

                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports",new PersonalReports())
                    };

                    var item3 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.Finance);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                    Menu.Children.Add(new UserControlMenuItem(item3, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));

                }
                else if (sector == "HR")
                {
                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports", new PersonalReports()),
                        new SubItem("Wiew all Reports", new Reports())

                    };

                    var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.NaturePeople);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                }
                else
                {
                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports",new PersonalReports())
                    };

                    var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);
                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.DeveloperBoard);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                }
            }
            else if (access == "modify")
            {
                if (sector == "Finance")
                {
                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports",new PersonalReports()),
                        new SubItem("Wiew all Reports", new Reports())
                    };

                    var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);
                    var menuWorkHours = new List<SubItem>
                    {
                        new SubItem("Work Hours"),
                    };

                    var item3 = new ItemMenu("Work hours", menuWorkHours, PackIconKind.EuroSymbol);
                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.Finance);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item3, this));

                }
                else if (sector == "HR")
                {
                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports",new PersonalReports()),
                        new SubItem("Wiew all Reports", new Reports())
                    };

                    var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);
                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.NaturePeople);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                }
                else
                {
                    var menuReports = new List<SubItem>
                    {
                        new SubItem("Write personal Reports",new PersonalReports())
                    };

                    var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

                    var menuEmployee = new List<SubItem>
                    {
                        new SubItem("One Employee", new ViewOneEmployee()),
                        new SubItem("All Employee", new Employee())
                    };
                    var item2 = new ItemMenu("Employee", menuEmployee, PackIconKind.PersonBoxOutline);

                    var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.DeveloperBoard);

                    Menu.Children.Add(new UserControlMenuItem(item50, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item2, this));
                }
            }
            else
            {
                var menuReports = new List<SubItem>
                    {
                        new SubItem("Write Reports",new PersonalReports())
                    };

                var item1 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

                var item50 = new ItemMenu("L-Company", new UserControl(), PackIconKind.FileUploadOutline);

                Menu.Children.Add(new UserControlMenuItem(item50, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
            }



        }


        private void Vreme()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Dogadjaj;
            timer.Start();
        }

        private void Dogadjaj(object sender, EventArgs e)
        {
            vr.Text = DateTime.Now.ToString(@"HH:mm:ss");

        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            MainWindowViewModel.loggedBool = false;


            main.ShowDialog();

        }
        private void Exit(object sender, RoutedEventArgs e)
        {

            MessageBoxResult dijalog = MessageBox.Show("Do you want to leave the program", "Exit app", MessageBoxButton.YesNo);

            if (dijalog == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void Povecaj_prozor(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                PovecajProzor.ToolTip = "Restore Down";
                PovecajProzor1.Visibility = Visibility.Visible;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                PovecajProzor.ToolTip = "Maximize";
                PovecajProzor1.Visibility = Visibility.Collapsed;
            }
        }

        private void Spusti_prozor(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }
    }
}
