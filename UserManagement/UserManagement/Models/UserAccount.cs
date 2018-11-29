using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "EmailId is invalied")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConformPassword { get; set; }


    }
}