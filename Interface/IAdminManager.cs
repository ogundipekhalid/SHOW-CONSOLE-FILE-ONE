using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAPP.Models;

namespace SCAPP.Interface
{
    public  interface IAdminManager
    {
       public void CreateAdmin(string firstName, string lastName, string eMail, int pIn,string phonenumber);
       public void UpdateAdmin (string firstName,string lastName);
       public void DeleteAdmin(string eMail);
       public Admin GetAdmin(string eMail);
       public Admin Login(string email,int pIn);
        public void ReadFromFile();
        public void ReWriteFile();
    }
}