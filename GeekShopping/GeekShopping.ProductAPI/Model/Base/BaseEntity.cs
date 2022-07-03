using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Models.Base
{
    public class BaseEntity
    {
        [Key]      
        public long Id { get; set; }
    }
}
