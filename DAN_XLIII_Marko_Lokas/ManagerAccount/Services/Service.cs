using ManagerAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAccount.Services
{
    class Service
    {
        public List<tblEmployee> GetAllEmployee()
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblEmployee AddEmployee(tblEmployee employee)
        {
            try
            {

                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    if (employee.EmployeeID == 0)
                    {
                        tblEmployee newEmployee = new tblEmployee
                        {
                            EmployeeID = employee.EmployeeID,
                            EmployeeName = employee.EmployeeName,
                            EmployeeSurname = employee.EmployeeSurname,
                            EMail = employee.EMail,
                            JMBG = employee.JMBG,
                            DateOfBirthday = employee.DateOfBirthday,
                            AccountNumber = employee.AccountNumber,
                            UsernameLogin = employee.UsernameLogin,
                            PasswordLogin = employee.PasswordLogin,
                            Position = employee.Position,
                            Salary = employee.Salary,
                            AccessLevel = employee.AccessLevel,
                            SectorName = employee.SectorName
                        };

                        context.tblEmployees.Add(newEmployee);
                        context.SaveChanges();
                        employee.EmployeeID = newEmployee.EmployeeID;
                        return employee;
                    }
                    else
                    {
                        tblEmployee employeeToEdit = (from r in context.tblEmployees where r.EmployeeID == employee.EmployeeID select r).First();

                        employeeToEdit.EmployeeName = employee.EmployeeName;
                        employeeToEdit.EmployeeSurname = employee.EmployeeSurname;
                        employeeToEdit.EMail = employee.EMail;
                        employeeToEdit.JMBG = employee.JMBG;
                        employeeToEdit.DateOfBirthday = employee.DateOfBirthday;
                        employeeToEdit.AccountNumber = employee.AccountNumber;
                        employeeToEdit.UsernameLogin = employee.UsernameLogin;
                        employeeToEdit.PasswordLogin = employee.PasswordLogin;
                        employeeToEdit.Position = employee.Position;
                        employeeToEdit.Salary = employee.Salary;
                        employeeToEdit.AccessLevel = employee.AccessLevel;
                        employeeToEdit.SectorName = employee.SectorName;
                        employeeToEdit.EmployeeID = employee.EmployeeID;
                        context.SaveChanges();
                        return employee;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteResult(int employeeID)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee employeeToDelete = (from r in context.tblEmployees where r.EmployeeID == employeeID select r).First();
                    context.tblEmployees.Remove(employeeToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
            }
        }

        public List<tblEmployee> GetResultsDetail(string jmbg)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees where x.JMBG == jmbg select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }


        public List<tblSector> GetAllSector()
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<tblSector> list = new List<tblSector>();
                    list = (from x in context.tblSectors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<tblAccessLevel> GetAllAccessLevel()
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<tblAccessLevel> list = new List<tblAccessLevel>();
                    list = (from x in context.tblAccessLevels select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwReportEmployee> GetAllReport()
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<vwReportEmployee> list = new List<vwReportEmployee>();
                    list = (from x in context.vwReportEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwReportEmployee> GetAllReportID(int ID)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    List<vwReportEmployee> list = new List<vwReportEmployee>();
                    list = (from x in context.vwReportEmployees where x.EmployeeID==ID select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        //Validation
        public tblEmployee GetEmployeeJMBG(string JMBG)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee emoloyee = (from e in context.tblEmployees where e.JMBG.Equals(JMBG) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblEmployee GetEmployeeAccountNumber(string accountNumber)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee emoloyee = (from e in context.tblEmployees where e.AccountNumber.Equals(accountNumber) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblEmployee GetEmployeeEmail(string email)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee emoloyee = (from e in context.tblEmployees where e.EMail.Equals(email) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblEmployee GetEmployeeUsername(string username)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee emoloyee = (from e in context.tblEmployees where e.UsernameLogin.Equals(username) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public tblEmployee GetUsernamePassword(string username, string password)
        {
            try
            {
                using (ManagerAppEntities context = new ManagerAppEntities())
                {
                    tblEmployee emoloyee = (from e in context.tblEmployees where e.UsernameLogin.Equals(username) where e.PasswordLogin.Equals(password) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
