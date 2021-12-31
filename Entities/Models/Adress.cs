using ECommerceEntities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class Adress : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdressId { get; set; }
        public string AdressName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2,ErrorMessage = "Address must be between 2 and 200 characters.")]
        public string Explanation { get; set; }
        //relationship
        public District District { get; set; }
        public City City { get; set; }
        public User User { get; set; }
    }
}
