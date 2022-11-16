using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Models;

namespace SCAPP.Interface
{
    public interface ICustomerManager
    {
        public void CreateCutomer(string firstName,string lastName, string eMail, int pIn,int phoneNumber);
        public void UpdateCustomer ( string firstName, string lastName, string email, int phoneNumber);
        public void DeleteCustomer (string email);
        public Customer GetCustomer (string email);
        public Customer Login (string email, int pIn);
        public void AddMoneyToWallet (string email, double amount);
        public Customer CheckWallet (string email,int pin);
        public Customer RescheduleBooking(int id, int bookingdate, string duration);
         public void ReadFromFile();
          public void ReWriteFile();
    }
}
