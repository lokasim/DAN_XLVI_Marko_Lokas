using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ManagerAccount.Commands;
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
                if (AllReport != null)
                {
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
            if (AllReport == null)
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
        /// Open a form to delete a new report
        /// </summary>
        private void DeleteExecute()
        {
            try
            {
                if (AllReport != null)
                {
                    MessageBoxResult dialog = MessageBox.Show("Do you want to delete the selected row?", "Delete Reports", MessageBoxButton.YesNo);

                    if (dialog == MessageBoxResult.Yes)
                    {
                        Service s = new Service();

                        int reportID = AllReport.ReportID;
                        bool isReport = s.IsReportID(reportID);
                        if (isReport == true)
                        {
                            s.DeleteReport(reportID);
                            AllReportList = s.GetAllReport().ToList();
                            PersonalReports personalReports = new PersonalReports();
                            personalReports.RefreshPersonal();
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete selected row.");
                        }
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
            if (AllReport == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
