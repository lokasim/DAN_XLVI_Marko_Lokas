﻿using System;
using System.Windows;

namespace ManagerAccount
{
    class ValidationJMBG
    {
        public static bool CheckJMBG(string jmbgUnos)
        {
            //Checking input length...
            if (jmbgUnos.Length == 13)
            {
                int[] danaUmjesecu = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                //Turn into a string of characters
                char[] niz = jmbgUnos.ToCharArray(0, 13);

                //First check the year of birth entry
                //Draw figures relating to the year of birth
                //Make the year of birth
                char[] godinaRodjenja = jmbgUnos.ToCharArray(4, 3);
                int pomGodina = 100 * (Convert.ToInt32(godinaRodjenja[0] - '0')) +
                                 10 * (Convert.ToInt32(godinaRodjenja[1] - '0')) +
                                       Convert.ToInt32(godinaRodjenja[2] - '0');

                //someone who was born in the 21st century...
                if (godinaRodjenja[0] == '0')
                    pomGodina += 2000;
                //who was born in the twentieth century
                else
                    pomGodina += 1000;

                //currently, the year cannot be less than 1900!
                if (pomGodina < 1900)
                {
                    MessageBox.Show("Year of birth entered is less than 1900.", "JMBG");
                    return false;
                }
                else
                {
                    //nor greater than the current year!
                    if (pomGodina > DateTime.Now.Year)
                    {
                        MessageBox.Show("The year of birth entered is greater than the current year.", "JMBG");
                        return false;
                    }
                }

                //check the month of birth entry
                //draw figures relating to the month of birth
                char[] mjesecRodjenja = jmbgUnos.ToCharArray(2, 2);
                int pomMjesec = 10 * (Convert.ToInt32(mjesecRodjenja[0] - '0')) +
                                      Convert.ToInt32(mjesecRodjenja[1] - '0');
                //the month must be <= 12 and> 0
                if (pomMjesec > 12 || pomMjesec < 1)
                {
                    MessageBox.Show("Month of birth incorrectly entered (third and fourth digit).", "JMBG");
                    return false;
                }

                //Check if the year is a leap year (due to the number of days in the month)
                if (((pomGodina % 4) == 0) && (((pomGodina % 100) != 0) || ((pomGodina % 400) == 0))) // prestupna godina
                {
                    //Adjust the number of days for February
                    danaUmjesecu[1] = 29;
                }

                //Checking entry day by month...
                char[] danRodjenja = jmbgUnos.ToCharArray(0, 2);
                int pomDan = 10 * (Convert.ToInt32(danRodjenja[0] - '0')) +
                                   Convert.ToInt32(danRodjenja[1] - '0');

                if (pomDan > danaUmjesecu[pomMjesec - 1] || pomDan < 1)
                {
                    MessageBox.Show("Birthday wrong (first and second digits).", "JMBG");
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("JMBG must be 13 characters long !!! \r \n Enter JMBG again.", "JMBG");
                return false;
            }
        }
    }
}
