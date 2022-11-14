using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Interface;
using SCAPP.Models;

namespace SCAPP.Implimentation
{
    public class AdminManager : IAdminManager
    {
        public string FilePath = "./File/Admin.txt";
        public static List<Admin> listOfAdmin = new List<Admin>();

        public void CreateAdmin(string firstName, string lastName, string eMail, int pIn, string adminId)
        {
            Random rand = new Random();
            int id  =  rand.Next(100, 999);
            Admin adm = new Admin(id , firstName, lastName, eMail, pIn, adminId);
            int movePrice = 2000;
            Console.WriteLine($"thank you  {adm.FirstName}, {adm.LastName}  your identity number is {adminId} the movie price is {movePrice}  ");
            listOfAdmin.Add(adm);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(adm.ConvertToFileFormat());
            }
            Console.WriteLine("created succesfully");
        }

        public void DeleteAdmin(string eMail)
        {
            Console.WriteLine("Enter email of Admin to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in listOfAdmin)
            {
                if (item.Email == email)
                {
                    listOfAdmin.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
            Console.WriteLine("deleted succesfully");
        }

        public Admin GetAdmin(string eMail)
        {
            foreach (var item in listOfAdmin)
            {
                if (item.Email == eMail)
                {
                    return item;
                }
            }
            return null;
        }

        public Admin Login(string email, int pin)
        {
            // System.Console.WriteLine(listOfAdmin.Count);
            foreach (var item in listOfAdmin)
            {
                //System.Console.WriteLine($"{item.Email}  {item.PIN}");
                if (item.Email == email && item.PIN == pin)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateAdmin(string firstName, string lastName)
        {
            Console.WriteLine("Enter email of Admin to Update: ");
            string email = Console.ReadLine().Trim();
            Admin adminToUpdate = GetAdmin(email);
            if (adminToUpdate != null)
            {
                Console.WriteLine("Update First Name: ");
                string firstname = Console.ReadLine().Trim();
                adminToUpdate.FirstName = firstName;

                Console.WriteLine("Update Last Name: ");
                string lastname = Console.ReadLine().Trim();
                adminToUpdate.LastName = lastName;

                Console.WriteLine("Update Phonenumber: ");
                string phonenumber = Console.ReadLine().Trim();
                adminToUpdate.AdminId = phonenumber;

                ReWriteFile();
                Console.WriteLine("admin updated successfully");
            }
            else
            {
                Console.WriteLine("admin not found");
            }
        }

        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string adminInfo = reader.ReadLine();
                    listOfAdmin.Add(Admin.ConvertToAdmin(adminInfo));
                }
            }
        }

        public void ReWriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var admin in listOfAdmin)
                {
                    writer.WriteLine(admin.ConvertToFileFormat());
                }
            }
        }
    }
}