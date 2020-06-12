using System;
using System.ComponentModel.DataAnnotations;

namespace RI.api.DTO
{
    //Data Transfer objects 
    public class UserForRegisterDto
    {

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        public string gender { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [StringLength(128,MinimumLength=12,ErrorMessage="You must Specify password between 12 and 128 chracters")]
        public string password { get; set; }
    }
}