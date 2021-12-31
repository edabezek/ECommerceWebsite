using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal SalesAmount { get; set; }
        [Required]
        public int SalesStatus { get; set; }
        [Required]
        public int BillingAddressId { get; set; }
        [ForeignKey("CargoInformation")]
        public int CargoId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        //relationship
        public CargoInformation CargoInformation { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<User> User { get; set; }
    }
}
