using ManagerAccount.Commands;
using ManagerAccount.Models;
using ManagerAccount.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagerAccount.ViewModels
{
    class EmployeeMenuViewModel : ViewModelBase
    {
        readonly EmployeeMenu employeeMenu;
        public static bool addEmployee = false;

        private tblEmployee allEmployee;
        public tblEmployee AllEmployee
        {
            get
            {
                return allEmployee;
            }
            set
            {
                allEmployee = value;
                OnPropertyChanged("AllEmployee");
            }
        }

        private List<tblEmployee> allEmployeeList;
        public List<tblEmployee> AllEmployeeList
        {
            get
            {
                return allEmployeeList;
            }
            set
            {
                allEmployeeList = value;
                OnPropertyChanged("AllEmployeeList");
            }
        }



        public EmployeeMenuViewModel(EmployeeMenu employeeMenu)
        {
            this.employeeMenu = employeeMenu;

            Service s = new Service();

            AllEmployeeList = s.GetAllEmployee().ToList();
        }

        #region Comands
        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddExecute(), param => CanAddExecute());
                }
                return add;
            }
        }

        /// <summary>
        /// Open a form to add a report
        /// </summary>
        private void AddExecute()
        {
            try
            {
                addEmployee = true;
                MainWindow main = new MainWindow();
                main.txtIme.Focus();
                main.title.Text = "Add New Employee";
                main.nazad.Visibility = Visibility.Collapsed;
                main.login.Visibility = Visibility.Collapsed;
                main.Images0.Visibility = Visibility.Visible;
                main.Images1.Visibility = Visibility.Collapsed;
                main.SignUp.Visibility = Visibility.Visible;
                main.dpDatumRodjenja.Text = "1.1.1990";
                main.tbCapsLock.Visibility = Visibility.Collapsed;
                main.ShowDialog();

                if ((main.DataContext as MainWindowViewModel).IsUpdateEmployee == true)
                {
                    main.Close();
                    Service s = new Service();
                    AllEmployeeList = s.GetAllEmployee().ToList();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddExecute()
        {
            return true;
        }

        private ICommand edit;
        public ICommand Edit
        {
            get
            {
                if (edit == null)
                {
                    edit = new RelayCommand(param => EditExecute(), param => CanEditExecute());
                }
                return edit;
            }
        }

        /// <summary>
        /// Open a form to edit a reports
        /// </summary>
        private void EditExecute()
        {
            try
            {
                if (AllEmployee != null)
                {
                    AllEmployee = null;
                    MessageBox.Show("This feature is currently under construction");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditExecute()
        {
            if (AllEmployee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(param => DeleteExecute(), param => CanDeleteExecute());
                }
                return delete;
            }
        }

        /// <summary>
        /// Open a form to delete a report
        /// </summary>
        private void DeleteExecute()
        {
            try
            {
                if (AllEmployee != null)
                {
                    MessageBoxResult dialog = MessageBox.Show("Do you want to delete the selected row?", "Delete Reports", MessageBoxButton.YesNo);

                    if (dialog == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("This feature is currently under construction");
                        AllEmployee = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteExecute()
        {
            if (AllEmployee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
