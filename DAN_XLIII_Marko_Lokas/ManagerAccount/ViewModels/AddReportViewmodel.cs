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
    class AddReportViewmodel : ViewModelBase
    {
        readonly AddReport addReport;

        #region Properties
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
        private bool isUpdateReport;
        public bool IsUpdateReport
        {
            get
            {
                return isUpdateReport;
            }
            set
            {
                isUpdateReport = value;
            }
        }
        #endregion

        public AddReportViewmodel(AddReport addReport)
        {
            report = new tblReport();
            DateTime date = DateTime.Now;
            report.CurrentDate = date;

            this.addReport = addReport;
        }

        public AddReportViewmodel(AddReport addReport, tblReport reportEdit)
        {
            report = reportEdit;

            this.addReport = addReport;
        }

        #region Commandes

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// Method for adding new products
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                Service s = new Service();
                int employeeid = LoggedEmployee.ID;
                    report.Employee = employeeid;
                report.Position = LoggedEmployee.position;
                s.AddReport(Report);
                isUpdateReport = true;
                addReport.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
                return true;
            
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// Exit form
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addReport.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
