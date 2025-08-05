using System.ComponentModel.DataAnnotations.Schema;

namespace myShop.Entites.Models
{
    public class LogCategory
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
