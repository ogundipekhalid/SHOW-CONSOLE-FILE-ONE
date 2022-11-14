using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPP.Models
{
    public class Admin:User
    {
        public  string AdminId{get;set;}
        
        
          public Admin(int id, string firstName, string lastName, string eMail, int pIn,string adminId) : base(id, firstName, lastName, eMail, pIn)
        {
           AdminId = adminId;
            PIN = pIn;
        }
      
        public string ConvertToFileFormat()
        {
            return $"{ID}***{FirstName}***{LastName}***{Email}***{PIN}***{AdminId}";
        }

        public static Admin ConvertToAdmin(string adminInfo)
        {
            string[] info = adminInfo.Split("***");
            return new Admin (int.Parse(info[0]),info[1],info[2], info[3],int.Parse(info[4]),info[5]);

        }
                       

    }
}