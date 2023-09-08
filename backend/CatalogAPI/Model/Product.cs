using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Model
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Brand { get; set; } = string.Empty;

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(10)]
        public string Size { get; set; } = string.Empty;

        [Column(TypeName = "numeric(10,2)")]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Image { get; set; } = string.Empty;
        public bool Feminine { get; set; }
    }
}
