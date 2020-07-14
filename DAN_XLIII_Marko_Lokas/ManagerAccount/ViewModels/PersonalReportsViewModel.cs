using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerAccount.Models;
using ManagerAccount.Services;
using ManagerAccount.Views;

namespace ManagerAccount.ViewModels
{
    class PersonalReportsViewModel : ViewModelBase
    {
        readonly PersonalReports personalReports;

        private vwReportEmployee allReport;
        public vwReportEmployee AllReport
        {
            get
            {
                return allReport;
            }
            set
            {
                allReport = value;
                OnPropertyChanged("AllReport");
            }
        }

        private List<vwReportEmployee> allReportList;
        public List<vwReportEmployee> AllReportList
        {
            get
            {
                return allReportList;
            }
            set
            {
                allReportList = value;
                OnPropertyChanged("AllReportList");
            }
        }
        

        public PersonalReportsViewModel(PersonalReports personalReports)
        {
            this.personalReports = personalReports;

            Service s = new Service();

            AllReportList = s.GetAllReportID(LoggedEmployee.ID).ToList();
        }
    }
}
