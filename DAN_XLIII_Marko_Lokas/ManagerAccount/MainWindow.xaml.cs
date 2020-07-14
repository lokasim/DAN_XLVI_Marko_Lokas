﻿using ManagerAccount.ViewModels;
using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace ManagerAccount
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool imeBool;
        public bool prezimeBool;
        public bool korisnickoBool;
        public bool datumBool;
        public bool emailBool;
        public bool lozinkaBool;
        public bool reLozinkaBool;
        public bool jmbgBool;
        public bool accountNumberBool;
        public bool positionBool;
        public bool salaryBool;
        public static bool napravljenaIzmena = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
            NameTextBox.Focus();
            SignUp.Visibility = Visibility.Collapsed;
            Images1.Visibility = Visibility.Visible;
            title.Text = "  Sign Up\nEmployee";
        }

        public bool korisnik;
        public bool lozinka;

        private void KorekcijaImena(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text.Length <= 5)
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Red);
                korisnik = false;
            }
            else
            {

                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Black);
                korisnik = true;
            }
            Prijavi();
        }

        private void KorekcijaLozinke(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length <= 5)
            {

                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
                lozinka = false;
            }
            else
            {

                passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
                passwordBox.Foreground = new SolidColorBrush(Colors.Black);
                lozinka = true;
            }
            Prijavi();
        }

        private void KorekcijaLozinkeTxt(object sender, RoutedEventArgs e)
        {
            if (txtPasswordBox.Text.Length <= 5)
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
                lozinka = false;
            }
            else
            {

                passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
                passwordBox.Foreground = new SolidColorBrush(Colors.Black);
                lozinka = true;
            }
            Prijavi();
        }


        private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
            }
        }

        private Boolean TextAllowedVelikaSlova(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLower(c) || Char.IsUpper(c) || Char.IsDigit(c) || Char.IsControl(c))
                {
                    loginFail.Visibility = Visibility.Collapsed;
                    //tbCapsLock.Visibility = Visibility.Collapsed;
                    continue;
                }
                else
                {
                    tbCapsLock.Visibility = Visibility.Visible;
                    //loginFail.Visibility = Visibility.Collapsed;
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        //samo mala slova i brojevi
        private void PreviewTextInputHandlerVelika(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowedVelikaSlova(e.Text);
        }
        private void Prijavi()
        {
            if (lozinka == true && korisnik == true)
            {
                btnPrijavi.IsEnabled = true;
            }
            else
            {
                btnPrijavi.IsEnabled = false;
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Application.Current.Shutdown();
        }

        private void BtnNotVisible_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Password.ToString();
            btnNotVisible.Visibility = Visibility.Collapsed;
            btnVisible.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            txtPasswordBox.Visibility = Visibility.Visible;
            txtPasswordBox.Text = password;
        }

        private void BtnVisible_Click(object sender, RoutedEventArgs e)
        {
            string password = txtPasswordBox.Text.ToString();
            btnVisible.Visibility = Visibility.Collapsed;
            btnNotVisible.Visibility = Visibility.Visible;
            txtPasswordBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
            passwordBox.Password = password;
        }


        //Registracija

        private void Ime(object sender, TextChangedEventArgs e)
        {
            if (txtIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "At least three characters";
            }
            if (txtIme.Text.Length <= 2)
            {
                //lbIme.Visibility = Visibility.Visible;
                txtIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtIme.Foreground = new SolidColorBrush(Colors.Red);
                imeBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                //lbIme.Visibility = Visibility.Collapsed;
                txtIme.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtIme.Foreground = new SolidColorBrush(Colors.Blue);
                imeBool = true;
            }
            txtIme.MaxLength = 30;
            if (txtIme.Text.Length >= txtIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }




        private void Prezime(object sender, TextChangedEventArgs e)
        {
            if (txtPrezime.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "At least three characters";
            }

            if (txtPrezime.Text.Length <= 2)
            {
                //lblPrezime.Visibility = Visibility.Visible;
                txtPrezime.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPrezime.Foreground = new SolidColorBrush(Colors.Red);
                prezimeBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                //lblPrezime.Visibility = Visibility.Collapsed;
                txtPrezime.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtPrezime.Foreground = new SolidColorBrush(Colors.Blue);
                prezimeBool = true;
            }
            txtPrezime.MaxLength = 30;
            if (txtPrezime.Text.Length >= txtPrezime.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Korisnicko(object sender, TextChangedEventArgs e)
        {
            if (txtKorisnickoIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "At least six characters";
            }
            if (txtKorisnickoIme.Text.Length <= 5)
            {

                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.Red);
                korisnickoBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.Blue);
                korisnickoBool = true;
            }
            txtKorisnickoIme.MaxLength = 30;
            if (txtKorisnickoIme.Text.Length >= txtKorisnickoIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Datum(object sender, RoutedEventArgs e)
        {
            datumBool = true;
            //dpDatumRodjenja.BorderBrush = new SolidColorBrush(Color.FromArgb(255, (139), (195), (74)));
            if (dpDatumRodjenja.Text.Length < 7)
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.Red);

            }
            else
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.Blue);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Email(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "Make sure you have entered the\ncorrect email address";
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {

                txtEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                txtEmail.Foreground = new SolidColorBrush(Colors.Red);
                emailBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;

                txtEmail.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtEmail.Foreground = new SolidColorBrush(Colors.Blue);
                emailBool = true;
                //txtEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#89000000"));
                //txtEmail.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#89000000"));
            }
            Registruj();
        }

        private void Lozinka(object sender, TextChangedEventArgs e)
        {
            if (txtLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "At least six characters";
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            if (txtLozinkaRegistracija.Text.Length <= 5)
            {
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                lozinkaBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                lozinkaBool = true;
            }

            if (reLozinka != lozinka)
            {

                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                reLozinkaBool = true;
                Registruj();
            }

            Registruj();
        }
        private void LozinkaRe(object sender, TextChangedEventArgs e)
        {

            if (txtReLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "Passwords must match";
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            //if(reLozinka == lozinka)

            if (reLozinka != lozinka)
            {

                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                reLozinkaBool = true;
                Registruj();
            }
            Registruj();
        }

        private void JMBG(object sender, TextChangedEventArgs e)
        {
            if (txtJMBG.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "The JMBG must contain 13 digits";
            }

            if (txtJMBG.Text.Length != 13)
            {

                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Red);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Red);
                jmbgBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;

                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Blue);
                jmbgBool = true;
            }
            txtJMBG.MaxLength = 13;
            if (txtJMBG.Text.Length >= txtJMBG.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void AccountNumber(object sender, TextChangedEventArgs e)
        {
            if (txtAccountNumber.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
                tbCapsLock.Text = "The Account NUmber must contain 18 digits";
            }
            if (txtAccountNumber.Text.Length != 18)
            {

                txtAccountNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAccountNumber.Foreground = new SolidColorBrush(Colors.Red);
                accountNumberBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtAccountNumber.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAccountNumber.Foreground = new SolidColorBrush(Colors.Blue);
                accountNumberBool = true;
            }
            txtAccountNumber.MaxLength = 18;
            if (txtAccountNumber.Text.Length >= txtAccountNumber.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Salary(object sender, TextChangedEventArgs e)
        {

            if (txtSalary.Text.Trim().Length < 1)
            {

                txtSalary.BorderBrush = new SolidColorBrush(Colors.Red);
                txtSalary.Foreground = new SolidColorBrush(Colors.Red);
                salaryBool = false;
            }
            else
            {

                txtSalary.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtSalary.Foreground = new SolidColorBrush(Colors.Blue);
                salaryBool = true;
            }
            txtSalary.MaxLength = 10;
            if (txtSalary.Text.Trim().Length >= txtSalary.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Position(object sender, TextChangedEventArgs e)
        {

            if (txtPosition.Text.Trim().Length < 1)
            {

                txtPosition.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPosition.Foreground = new SolidColorBrush(Colors.Red);
                positionBool = false;
            }
            else
            {

                txtPosition.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtPosition.Foreground = new SolidColorBrush(Colors.Blue);
                positionBool = true;
            }
            txtPosition.MaxLength = 30;
            if (txtPosition.Text.Length >= txtPosition.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Registruj()
        {
            if (imeBool == true &&
                prezimeBool == true &&
                korisnickoBool == true &&
                datumBool == true &&
                emailBool == true &&
                lozinkaBool == true &&
                reLozinkaBool == true &&
                jmbgBool == true &&
                accountNumberBool == true &&
                salaryBool == true &&
                positionBool == true &&
                txtLozinkaRegistracija.Text.ToString().Equals(txtReLozinkaRegistracija.Text.ToString()))
            {
                btnRegistracija.IsEnabled = true;
            }
            else
            {
                btnRegistracija.IsEnabled = false;
            }

        }
        private Boolean TextAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLetter(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        // zabranjuje da se kopiraju brojevi u polje
        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            String s = (String)e.DataObject.GetData(typeof(String));
            if (!TextAllowed(s)) e.CancelCommand();
        }

        private Boolean NumberAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }
        //samo slova
        private void PreviewNumberInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumberAllowed(e.Text);
        }



        private void BtnVratiPrijavu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Napusti(object sender, RoutedEventArgs e)
        {
            //porukaError.Visibility = Visibility.Collapsed;
        }
    }
}
