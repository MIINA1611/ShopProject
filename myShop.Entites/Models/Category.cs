using System.ComponentModel.DataAnnotations;
using myShop.Entites.Resources;
namespace myShop.Entites.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required(ErrorMessageResourceType =typeof(Resource_en_Models),ErrorMessageResourceName = "CategoryNameReq")]
        [MaxLength(20,ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3,ErrorMessageResourceType = typeof(Resource_en_Models), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CurrentStatue { get; set; }
    }
}
