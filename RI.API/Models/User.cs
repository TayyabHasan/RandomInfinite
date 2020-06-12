using System;

namespace RI.api.Models
{
    public class User
    {
        public int id { get; set; } 
        public string email { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public byte[] passwordHash { get; set; }    
        public byte[] passwordSalt { get; set; } 
        public DateTime dateOfBirth { get; set; }
        public DateTime accountCreatedOn {get;set;} = DateTime.Now;
    }
}