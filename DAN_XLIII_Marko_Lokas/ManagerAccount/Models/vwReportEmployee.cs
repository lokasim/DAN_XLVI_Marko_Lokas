//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagerAccount.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwReportEmployee
    {
        public int ReportID { get; set; }
        public System.DateTime CurrentDate { get; set; }
        public string ProjectName { get; set; }
        public string WorkHour { get; set; }
        public int Employee { get; set; }
        public string Position { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int EmployeeID { get; set; }
        public string Expr1 { get; set; }
        public string FullEmployee
        {
            get
            {
                return $"{EmployeeName} {EmployeeSurname}";
            }
        }
    }
}
