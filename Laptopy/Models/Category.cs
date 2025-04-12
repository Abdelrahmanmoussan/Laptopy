using System.ComponentModel.DataAnnotations;

namespace Laptopy.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
