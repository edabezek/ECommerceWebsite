using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceEntities
{
    public class CargoInformation 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CargoId { get; set; }
        [StringLength(50,MinimumLength =2)]
        public string CompanyName { get; set; }
        public int CompanyStatus { get; set; }     
        public int CompanyAddressId { get; set; }
        public int CargoTrackingNumber { get; set; }
        //relationship
        public Sale Sale { get; set; }
    }
}
