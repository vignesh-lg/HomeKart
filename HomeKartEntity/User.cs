using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HomeKartEntity
{
    [Table("User")]
    public class User
    {
        public long CellNumber { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string Role { get; set; }
        public string HashCode { get; set; }
    }
    [Table("Orders")]
    public class Orders
    {
        public string CartId { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string UserMail { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
    }
}
