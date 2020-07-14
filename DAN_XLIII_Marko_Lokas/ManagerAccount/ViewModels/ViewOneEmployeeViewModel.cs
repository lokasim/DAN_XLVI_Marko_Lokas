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
    class ViewOneEmployeeViewModel : ViewModelBase
    {
        private ViewOneEmployee viewOneEmployee;

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

        public ViewOneEmployeeViewModel(ViewOneEmployee viewOneEmployee)
        {
            this.viewOneEmployee = viewOneEmployee;
        }

        private ICommand search;
        public ICommand Search
        {
            get
            {
                if (search == null)
                {
                    search = new RelayCommand(param => SearchExecute(), param => CanSearchExecute());
                }
                return search;
            }
        }

        private void SearchExecute()
        {
            Service s = new Service();

            string jmbg = viewOneEmployee.txtJMBG.Text.Trim();

            AllEmployeeList = s.GetResultsDetail(jmbg);



            if (AllEmployeeList.Count() < 1)
            {
                viewOneEmployee.lblMessageSearch.Visibility = Visibility.Visible;
                viewOneEmployee.DataGridOneEmployee.Visibility = Visibility.Collapsed;
            }
            else
            {
                viewOneEmployee.lblMessageSearch.Visibility = Visibility.Collapsed;
                viewOneEmployee.DataGridOneEmployee.Visibility = Visibility.Visible;
            }
        }

        private bool CanSearchExecute()
        {
            if(viewOneEmployee.txtJMBG.Text.Length != 13)
            {
                viewOneEmployee.txtJMBG.ToolTip = "JMBG must 13 digits";
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}
