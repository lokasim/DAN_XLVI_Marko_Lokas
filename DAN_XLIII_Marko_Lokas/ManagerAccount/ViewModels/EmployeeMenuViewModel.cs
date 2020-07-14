using ManagerAccount.Models;
using ManagerAccount.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAccount.ViewModels
{
    class EmployeeMenuViewModel : ViewModelBase
    {
        readonly EmployeeMenu employeeMenu;

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
    }
}
