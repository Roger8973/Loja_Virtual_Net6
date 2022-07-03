using GeekShopping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Models
{
    [Table("product")]
    public class Product 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)") ]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
    
        [StringLength(500)]
        public string Description { get; set; }
    
        [StringLength(50)]
        public string CategoryName { get; set; }
       
        [StringLength(300)]
        public string ImageURL { get; set; }
    }
}
