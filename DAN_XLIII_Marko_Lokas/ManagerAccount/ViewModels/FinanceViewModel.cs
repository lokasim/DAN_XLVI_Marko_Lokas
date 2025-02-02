﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerAccount.Models;
using ManagerAccount.Services;
using ManagerAccount.Views;

namespace ManagerAccount.ViewModels
{
    class FinanceViewModel :ViewModelBase
    {
        readonly FinanceView financeView;

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

        public FinanceViewModel(FinanceView financeView)
        {
            this.financeView = financeView;
            Service s = new Service();

            AllReportList = s.GetAllReport().ToList();
        }
    }
}
