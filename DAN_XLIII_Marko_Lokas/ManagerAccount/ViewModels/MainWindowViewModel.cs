using ManagerAccount.Commands;
using ManagerAccount.Models;
using ManagerAccount.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagerAccount.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        
        readonly MainWindow main;
        public static bool loggedBool = false;
        #region Properties
        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private tblEmployee employee;
        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }

        private tblSector sector;
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("SectorID");
            }
        }
        private bool isUpdateSector;
        public bool IsUpdateSector
        {
            get
            {
                return isUpdateSector;
            }
            set
            {
                isUpdateSector = value;
            }
        }

        private tblAccessLevel accessLevel;
        public tblAccessLevel AccessLevel
        {
            get
            {
                return accessLevel;
            }
            set
            {
                accessLevel = value;
                OnPropertyChanged("AccessLevelID");
            }
        }
        private bool isUpdateAccessLevel;
        public bool IsUpdateAccessLevel
        {
            get
            {
                return isUpdateAccessLevel;
            }
            set
            {
                isUpdateAccessLevel = value;
            }
        }
        private List<tblSector> sectorList;
        public List<tblSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }
        private List<tblAccessLevel> accessLevelList;
        public List<tblAccessLevel> AccessLevelList
        {
            get
            {
                return accessLevelList;
            }
            set
            {
                accessLevelList = value;
                OnPropertyChanged("AccessLevelList");
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            employee = new tblEmployee();

            Service s = new Service();
            SectorList = s.GetAllSector().ToList();
            AccessLevelList = s.GetAllAccessLevel().ToList();
            
        }
        
        #endregion

        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return login;
            }
        }
        
        private void LoginExecute()
        {
            try
            {
                if (main.NameTextBox.Text == "WPFadmin" && (main.passwordBox.Password == "WPFadmin" || main.txtPasswordBox.Text == "WPFadmin"))
                {
                    main.txtIme.Focus();
                    main.login.Visibility = Visibility.Collapsed;
                    main.Images0.Visibility = Visibility.Visible;
                    main.Images1.Visibility = Visibility.Collapsed;
                    main.SignUp.Visibility = Visibility.Visible;
                    main.dpDatumRodjenja.Text = "1.1.1990";
                    main.tbCapsLock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Service s = new Service();

                    string username = main.NameTextBox.Text;

                    string password = main.passwordBox.Password;

                    tblEmployee employeeLogin = s.GetUsernamePassword(username, password);

                    if (employeeLogin != null)
                    {

                        LoggedEmployee.ID = employeeLogin.EmployeeID;
                        LoggedEmployee.name = employeeLogin.EmployeeName;
                        LoggedEmployee.surname = employeeLogin.EmployeeSurname;
                        LoggedEmployee.position = employeeLogin.Position;
                        if(Convert.ToString(employeeLogin.SectorName) != null)
                        {
                            if(employeeLogin.SectorName  == 1)
                            {
                                LoggedEmployee.sector = "HR";
                            }
                            else if (employeeLogin.SectorName == 2)
                            {
                                LoggedEmployee.sector = "Finance";
                            }
                            else if (employeeLogin.SectorName == 3)
                            {
                                LoggedEmployee.sector = "R&D";
                            }
                        }
                        else
                        {
                            LoggedEmployee.sector = "";
                        }

                        if (Convert.ToString(employeeLogin.AccessLevel) != null)
                        {
                            if (employeeLogin.AccessLevel == 1)
                            {
                                LoggedEmployee.accessLevel = "modify";
                            }
                            else if (employeeLogin.AccessLevel == 2)
                            {
                                LoggedEmployee.accessLevel = "read-only";
                            }
                        }
                        else
                        {
                            LoggedEmployee.accessLevel = "";
                        }
                        

                        loggedBool = true;
                        EmployeeMenu employeeMenu = new EmployeeMenu
                        {
                            Owner = main
                        };
                        main.Hide();
                        employeeMenu.ShowDialog();

                    }
                    loggedBool = false;
                    main.tbCapsLock.Visibility = Visibility.Visible;
                    main.tbCapsLock.Text = "Username or Password is incorect.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private bool CanLoginExecute()
        {
            return true;
        }

        private ICommand backToLogin;
        public ICommand BackToLogin
        {
            get
            {
                if (backToLogin == null)
                {
                    backToLogin = new RelayCommand(param => BackLoginExecute(), param => CanBackLoginExecute());
                }
                return backToLogin;
            }
        }
        
        private void BackLoginExecute()
        {
            
            main.NameTextBox.Text = "";
            main.passwordBox.Password = "";
            main.txtPasswordBox.Text = "";
            main.login.Visibility = Visibility.Visible;
            main.Images0.Visibility = Visibility.Collapsed;
            main.Images1.Visibility = Visibility.Visible;
            main.SignUp.Visibility = Visibility.Collapsed;
            main.NameTextBox.Focus();
            main.txtIme.Text = "";
            main.txtPrezime.Text = "";
            main.txtJMBG.Text = "";
            main.dpDatumRodjenja.Text = "";
            main.txtAccountNumber.Text = "";
            main.txtEmail.Text = "";
            main.txtKorisnickoIme.Text = "";
            main.txtLozinkaRegistracija.Text = "";
            main.txtReLozinkaRegistracija.Text = "";
            main.txtSalary.Text = "";
            main.txtPosition.Text = "";
            main.cbxSector.Text = "";
            main.cbxAccessLevel.Text = "";

            return;
        }
        private bool CanBackLoginExecute()
        {
            return true;
        }

        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }
        private void SignUpExecute()
        {
            try
            {
                Service s = new Service();

                string jmbg = Employee.JMBG;
                string AN = Employee.AccountNumber;
                string user = Employee.UsernameLogin;
                string email = Employee.EMail;

                if (!ValidationJMBG.CheckJMBG(jmbg))
                {
                    return;
                }

                tblEmployee employee = s.GetEmployeeJMBG(jmbg);

                if (employee != null)
                {
                    MessageBox.Show("JMBG already exists in the database, try another.", "JMBG");
                    return;
                }


                
                tblEmployee employeeAN = s.GetEmployeeAccountNumber(AN);

                if (employeeAN != null)
                {
                    MessageBox.Show("Account Number already exists in the database, try another.", "Account Number");
                    return;
                }

                
                tblEmployee employeeUser = s.GetEmployeeUsername(user);

                if (employeeUser != null)
                {
                    MessageBox.Show("Username already exists in the database, try another.", "Username");
                    return;
                }

                
                tblEmployee employeeEmail = s.GetEmployeeEmail(email);

                if (employeeEmail != null)
                {
                    MessageBox.Show("E-mail already exists in the database, try another.", "E-mail");
                    return;
                }


                if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text != "")
                {
                    Employee.SectorName = Convert.ToInt32(Sector.SectorID);
                    Employee.AccessLevel = Convert.ToInt32(AccessLevel.AccessLevelID);


                }
                CreateManager.logName = main.txtIme.Text.ToString();
                CreateManager.logSurname = main.txtPrezime.Text.ToString();
                CreateManager.logJMBG = main.txtJMBG.Text.ToString();
                CreateManager.logEmail = main.txtEmail.Text.ToString();
                CreateManager.logUsername = main.txtKorisnickoIme.Text.ToString();
                CreateManager.logPassword = main.txtLozinkaRegistracija.Text.ToString();
                CreateManager.logSector = main.cbxSector.Text.ToString();
                CreateManager.logAccess = main.cbxAccessLevel.Text.ToString();
                CreateManager.logPosition = main.txtPosition.Text.ToString();

                string logMessage = $"Manager: [{CreateManager.logName} {CreateManager.logSurname }] Position: [{CreateManager.logPosition}] Sector: [{ CreateManager.logSector}] " +
                    $"Access Level: [{ CreateManager.logAccess}] Username: [{CreateManager.logUsername }] Password: [{CreateManager.logPassword }] Email: [{ CreateManager.logEmail}] JMBG: [{CreateManager.logJMBG }] ";

                if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text != "")
                {
                    Thread logThread = new Thread(() => LogMethod(logMessage));
                    logThread.Start();
                }

                s.AddEmployee(Employee);
                IsUpdateEmployee = true;
                //main.Close();
                main.NameTextBox.Text = "";
                main.passwordBox.Password = "";
                main.txtPasswordBox.Text = "";
                main.login.Visibility = Visibility.Visible;
                main.Images0.Visibility = Visibility.Collapsed;
                main.Images1.Visibility = Visibility.Visible;
                main.SignUp.Visibility = Visibility.Collapsed;

                string poruka = "Add Employee: " + Employee.EmployeeName + " " + Employee.EmployeeSurname;
                MessageBox.Show(poruka, "successfully added employee", MessageBoxButton.OK);
                main.txtIme.Text = "";
                main.txtPrezime.Text = "";
                main.txtJMBG.Text = "";
                main.dpDatumRodjenja.Text = "";
                main.txtAccountNumber.Text = "";
                main.txtEmail.Text = "";
                main.txtKorisnickoIme.Text = "";
                main.txtLozinkaRegistracija.Text = "";
                main.txtReLozinkaRegistracija.Text = "";
                main.txtSalary.Text = "";
                main.txtPosition.Text = "";
                main.cbxSector.Text = "";
                main.cbxAccessLevel.Text = "";
                main.NameTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LogMethod(string message)
        {
                LogFIleTxt.AddLogFile(message);
            
        }

        private bool CanSignUpExecute()
        {
            if (String.IsNullOrEmpty(employee.EmployeeName) ||
                String.IsNullOrEmpty(employee.EmployeeSurname) ||
                String.IsNullOrEmpty(employee.JMBG) ||
                String.IsNullOrEmpty(employee.AccountNumber) ||
                String.IsNullOrEmpty(employee.EMail) ||
                String.IsNullOrEmpty(employee.UsernameLogin) ||
                String.IsNullOrEmpty(employee.PasswordLogin) ||
                String.IsNullOrEmpty(employee.Salary) ||
                String.IsNullOrEmpty(employee.Position))
            {
                return false;
            }
            else if (main.cbxSector.Text == "" && main.cbxAccessLevel.Text != "")
            {
                return false;
            }
            else if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text == "")
            {
                return false;
            }
            else if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text != "")
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        private ICommand refreshSector;
        public ICommand RefreshSector
        {
            get
            {
                if (refreshSector == null)
                {
                    refreshSector = new RelayCommand(param => SectorExecute(), param => CanSectorExecute());
                }
                return refreshSector;
            }
        }
        private void SectorExecute()
        {
            main.cbxSector.Text = "";
        }
        
        private bool CanSectorExecute()
        {
            if(main.cbxSector.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand refreshAccessLevel;
        public ICommand RefreshAccessLevel
        {
            get
            {
                if (refreshAccessLevel == null)
                {
                    refreshAccessLevel = new RelayCommand(param => AccessLevelExecute(), param => CanAccessLevelExecute());
                }
                return refreshAccessLevel;
            }
        }
        private void AccessLevelExecute()
        {
            main.cbxAccessLevel.Text = "";
        }

        private bool CanAccessLevelExecute()
        {
            if(main.cbxAccessLevel.Text == "")
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
