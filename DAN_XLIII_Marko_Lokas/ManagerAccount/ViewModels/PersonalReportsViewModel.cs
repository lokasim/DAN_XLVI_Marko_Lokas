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
    class PersonalReportsViewModel : ViewModelBase
    {
        readonly PersonalReports personalReports;

        private tblReport report;
        public tblReport Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
                OnPropertyChanged("Report");
            }
        }

        private List<tblReport> reportList;
        public List<tblReport> ReportList
        {
            get
            {
                return reportList;
            }
            set
            {
                reportList = value;
                OnPropertyChanged("ReportList");
            }
        }

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

            ReportList = s.GetAllReportIDtbl(LoggedEmployee.ID).ToList();
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
                AddReport addReport = new AddReport();
                addReport.ShowDialog();

                if ((addReport.DataContext as AddReportViewmodel).IsUpdateReport == true)
                {
                    Service s = new Service();
                    ReportList = s.GetAllReportIDtbl(LoggedEmployee.ID).ToList();
                    

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
                if (Report != null)
                {
                    AddReport addReport = new AddReport(Report);
                    addReport.ShowDialog();

                    if ((addReport.DataContext as AddReportViewmodel).IsUpdateReport == false)
                    {
                        Service s = new Service();
                        ReportList = s.GetAllReportIDtbl(LoggedEmployee.ID).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditExecute()
        {
            if (Report == null)
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
                if (Report != null)
                {
                    MessageBoxResult dialog = MessageBox.Show("Do you want to delete the selected row?", "Delete Reports", MessageBoxButton.YesNo);

                    if (dialog == MessageBoxResult.Yes)
                    {
                        Service s = new Service();

                        int reportID = Report.ReportID;
                        bool isReport = s.IsReportID(reportID);
                        if (isReport == true)
                        {
                            s.DeleteReport(reportID);
                            ReportList = s.GetAllReportIDtbl(LoggedEmployee.ID).ToList();
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
            if (Report == null)
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
