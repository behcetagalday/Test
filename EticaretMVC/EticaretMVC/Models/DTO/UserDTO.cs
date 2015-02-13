using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models.DTO
{
    public class UserDTO
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(15)]
        public string Password { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
    }
}