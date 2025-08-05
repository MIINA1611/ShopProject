using System.ComponentModel.DataAnnotations;
using myShop.Entites.Models;
using myShop.Entites.Resources;

namespace myShop.Infurastructure.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category>? Categories { get; set; }
        public NewCategory NewCategory { get; set; }
    }
    public class  NewCategory
    {
        public string? Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "CategoryNameReq")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
