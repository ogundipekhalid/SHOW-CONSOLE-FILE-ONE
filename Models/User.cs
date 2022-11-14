using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPP.Models
{
    public class User
    {
   
      public int ID {get; set;}
      public string FirstName{get;set;}
      public string LastName { get; set; }
      public string Email { get; set; }
      public int PIN { get; set; }

     

    public User(int id,string firstName,string lastName, string eMail,int pIn)
    { 
        ID = id;
        FirstName =firstName;
        LastName =lastName;
        Email =eMail;
        PIN = pIn;
        
    }

    }
}