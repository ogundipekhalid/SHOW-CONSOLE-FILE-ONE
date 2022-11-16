using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Implimentation
{
    public class CoutomerManger : ICustomerManager
    {
        public string CustomerFilePath = "./File/Customer.txt";
        public static List<Customer> listOfCustomers = new List<Customer>();
        public void AddMoneyToWallet(string email, double amount)
        {
         Customer cms = GetCustomer(email);
            if (cms != null)
            {
                cms.Wallet += amount;
                Console.WriteLine($"{amount} successfully added to wallet and balance is {cms.Wallet}");
                
            }
            else
            {
                Console.WriteLine("customer not found");
            }
        }

        public Customer CheckWallet(string email,int pin)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email && customer.PIN == pin )//customer.Email == email && customer.PhoneNumber == phoneNumber)
                {
                    Console.WriteLine("You have successfully checked your balance");
                }
            }
            return null;
        }

        public void CreateCutomer( string firstName, string lastName, string eMail, int pIn,int phoneNumber)
        {
           Random rand = new Random(); 
           int Id = listOfCustomers.Count + 1;
           double wallet = 0;
           int  ID = rand.Next(100, 999);
            Customer customer = new Customer(Id, firstName,lastName, eMail, pIn,wallet, phoneNumber);
            listOfCustomers.Add(customer);
           Console.WriteLine($"Thank you {customer.FirstName}, your wallat ballance {customer.Wallet}  your id number {ID}");
           using (StreamWriter writer = new StreamWriter(CustomerFilePath, append: true))
            {
                writer.WriteLine(customer.WriteToFileFormat());
            }


            Console.WriteLine("created succesfully");
        }

        public void DeleteCustomer(string email)
        {
             Console.WriteLine("Enter email of Admin to delete: ");
            string emaiel = Console.ReadLine().Trim();
            foreach (var item in listOfCustomers)
            {
                if (item.Email == email)
                {
                    listOfCustomers.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
            Console.WriteLine("deleted succesfully");
        }

        public Customer GetCustomer(string email)
        {
           foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Login(string email, int pIn )
        {
             //   System.Console.WriteLine(listOfCustomers.Count);
            foreach (var item in listOfCustomers)
            {
                Console.WriteLine($"{item.Email}  {item.PIN}");
                if (item.Email == email && item.PIN == pIn)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer RescheduleBooking(int id, int bookingdate, string duration)
        {
            foreach (var item in listOfCustomers)
            {
                if (item.ID == id )
                {
                    return item;
                }
            }
            return null;
        }

      

        public void UpdateCustomer( string firstName, string lastName, string email, int phoneNumber)
        {
             Customer cms = GetCustomer(email);
            if (cms == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                cms.FirstName = firstName;
                cms.LastName = lastName;
                cms.PhoneNumber = phoneNumber;
            }
        }
     public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(CustomerFilePath))
            {
                while (reader.Peek() > -1)
                {
                    string CutomerInfo = reader.ReadLine();
                    listOfCustomers.Add(Customer.ConvertToCutomer(CutomerInfo));
                }
            }
        }

        public void ReWriteFile()
        {
            File.WriteAllText(CustomerFilePath,string.Empty);
            {
                using (StreamWriter writer  = new StreamWriter(CustomerFilePath, append : true))
                {
                    foreach (var cutomer in listOfCustomers)
                    {
                       writer.WriteLine(cutomer.WriteToFileFormat());
                    }
                }
            }
        
        }
    }
            
}