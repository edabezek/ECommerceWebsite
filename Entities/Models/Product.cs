using ECommerceEntities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class Product : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public int ProductCode { get; set; }
        [Required]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [Required]
        [ForeignKey("ProductFeature")]
        public int ProductFeatureId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        //relationship
        public ProductFeature ProductFeature  { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
