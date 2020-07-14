using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerAccount.Views;

namespace ManagerAccount.ViewModels
{
    class AddReportViewmodel : ViewModelBase
    {
        readonly AddReport addReport;

        public AddReportViewmodel(AddReport addReport)
        {
            this.addReport = addReport;
        }
    }
}
