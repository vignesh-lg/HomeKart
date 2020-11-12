using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartEntity
{
    class Inventory
    {
    }
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [MaxLength(20)]
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
    }
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [MaxLength(20)]
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [MaxLength(200)]
        [Required]
        public string ProductImageName { get; set; }
        [MaxLength(200)]
        [Required]
        public string ProductImage { get; set; }
    }
}

