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
    class ReportsViewModel :ViewModelBase
    {
        readonly Reports reports;

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

        public ReportsViewModel(Reports reports)
        {
            this.reports = reports;

            Service s = new Service();

            AllReportList = s.GetAllReport().ToList();
        }
    }
}
