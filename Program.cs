using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FUNN
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = GetFirstName();
            string secondName = GetSecondName();
            string date = GetDate();

            string customerID = GetCustomerID(date, firstName, secondName);
            Console.WriteLine($"Your customer ID is: {customerID}");

            
        }
        public static string GetFirstName()
        {
            while(true)
            {
                Console.Write("Please Enter Your First Name: ");
                string firstName = Console.ReadLine().ToUpper();

                if (firstName == "QUIT"){Environment.Exit(-1);}

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$")){return firstName;}
                else {Console.WriteLine("Please enter a valid name containing only alphabetic letters"); continue;}
                
            }
        }
        public static string GetSecondName()
        {
            while(true)
            {
                Console.Write("Please Enter Your Second Name: ");
                string secondName = Console.ReadLine().ToUpper();

                if (secondName == "QUIT"){Environment.Exit(-1);}

                if (Regex.IsMatch(secondName, @"^[a-zA-Z]+$")){return secondName;}
                else{Console.WriteLine("Please enter a valid name containing only alphabetic letters"); continue;}
            }
        }
        public static string GetDate()
        {
            while(true)
            {
                string format = "dd/MM/yyyy";
                DateTime isValid;
                Console.Write("Enter a date in the format dd/MM/yyyy: ");
                string date = Console.ReadLine().ToUpper();

                if (date == "QUIT"){
                    Environment.Exit(0);
                }
                else if (DateTime.TryParseExact(date, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out isValid)){
                    return date;
                }
                else{
                    Console.WriteLine("PLease enter a valid date: ");
                    continue;
                }

            }
        }
        public static string GetCustomerID(string date, string firstName, string secondName)
        {
            string changedDate = date.Substring(6,4) + date.Substring(3,2) + date.Substring(0, 2);
            string changedSurname = secondName.Substring(0, 3);
            char changedFirstname = firstName[0];
            string lengthOfFirstName = Convert.ToString(firstName.Length);

            string customerID = changedDate + changedSurname + changedFirstname + lengthOfFirstName;
            return customerID;
        }


    }
}
