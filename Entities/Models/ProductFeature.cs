using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class ProductFeature 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int ProductFeatureId { get; set; }
        public string ProductName { get; set; }
        public string ProductExplanation { get; set; }
        public int ProductStatus { get; set; }
        //relationship
        public Product Product { get; set; }

    }
}
