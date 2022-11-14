using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPP.Models
{
    public class Customer : User
    {
        public double Wallet { get; set; }
        public int PhoneNumber { get; set; }

        public Customer(int id, string firstName, string lastName, string eMail, int pIn, double waLLet, int phoneNumber) : base(id, firstName, lastName, eMail, pIn)
        {

            Wallet = waLLet;
            PhoneNumber = phoneNumber;
        }
        public string WriteToFileFormat()
        {
            return $"{ID}***{FirstName}***{LastName}***{Email}***{PIN}***{Wallet}***{PhoneNumber}";
        }

        public static Customer ConvertToCutomer(string customerAllfromText)
        {
            var cutomerConvert = customerAllfromText.Split("***");
            return new Customer(int.Parse(cutomerConvert[0]), cutomerConvert[1], cutomerConvert[2], cutomerConvert[3], int.Parse(cutomerConvert[4]), double.Parse(cutomerConvert[5]), int.Parse(cutomerConvert[6]));
        }


    }
}