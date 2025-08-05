using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.Entites.Models;
using myShop.Entites.Resources;

namespace myShop.Infurastructure.ViewModel
{
    public class ProductsViewModel
    {
        public List<Products> Products { get; set; }

        public NewProducts NewProduct { get; set; }

    }
    public class NewProducts
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "ProductNameReq")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "PriceReq")]
        [Range(0.01, double.MaxValue, ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MinPrice")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int CurrentStatue { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
