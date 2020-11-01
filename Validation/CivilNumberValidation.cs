using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Validation
{
    class CivilNumberValidation
    {
        static int[] egn_weights =new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        
        public static bool isCivilNumberValid(string EGN)
        {


            if (EGN==null || EGN.Length != 10)
            {
                return false;
            }
            string Year = EGN.Substring(0, 2);
            string Month = EGN.Substring(2, 2);
            string Day = EGN.Substring(4, 2);

            string date = Year+" " + Month + " " + Day;

            int year = Int32.Parse(EGN.Substring(0, 2));
            int month= Int32.Parse(EGN.Substring(2, 2));
            int day= Int32.Parse(EGN.Substring(4, 2));
            
                if (month>40)
                {
                    year += 2000;
                    month -= 40;
                    Year = year.ToString();
                    Month = month.ToString();
                    date = Year + " " + Month + " " + Day;
                    if (!CheckDate(date))
                    {
                        return false;
                    }

                }
                else if (month > 20)
                {
                    year += 1800;
                    month -= 20;
                    Year = year.ToString();
                    Month = month.ToString();
                    date = Year + " " + Month + " " + Day;
                    if (!CheckDate(date))
                    {
                        return false;
                    }
                }
                else
                {
                    year += 1900;
                    Year = year.ToString();
                    Month = month.ToString();
                    date = Year + " " + Month + " " + Day;
                    if (!CheckDate(date))
                    {
                        return false;
                    }
                }


                int checkSum = Int32.Parse(EGN.Substring(9, 1));
                int egnSum = 0;
                for(int i = 0; i < 9; i++)
                {
                    egnSum += (Int32.Parse(EGN.Substring(i, 1))) * egn_weights[i];
                }
                int valid_checkSum = egnSum % 11;
                if (valid_checkSum == 10)
                    valid_checkSum = 0;
                if (checkSum == valid_checkSum)
                {
                    return true;
                }
            
            return false;
        }

        static bool CheckDate(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
