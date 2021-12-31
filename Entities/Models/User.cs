using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(20,MinimumLength =2,ErrorMessage = "Name must be in the range of 2-20 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname must be in the range of 2-20 characters.")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]//automatically makes the input value email
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UserDateOfUpdate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Status { get; set; }
        public DateTime LastLoginTime { get; set; }
        //relationship
        public Sale Sale { get; set; }
        //Token 
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndTime { get; set; }//Token bitiş süresi - ilk seferinde boş gelebileceğinden boş geçilebilir yapıyoruz
    }
}
