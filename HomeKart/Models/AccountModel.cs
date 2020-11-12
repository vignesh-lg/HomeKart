using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeKart.Models
{
    public enum Role
    {
        admin,
        user
    }
    [MetadataType(typeof(AccountModel))]

    public class AccountModel
    { 
        [Display(Name = "Cell Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cell Number Required")]
        [RegularExpression(@"[6789]\d{9}", ErrorMessage = "Enter a valid cellnumber")]
        public long CellNumber { get; set; }
        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
      //  [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Min 8 Digits allowed")]
        [MaxLength(15, ErrorMessage = "Max 15 Digits allowed")]
        //[RegularExpression(@"^.*(?=.*\d)(?=.*[a - z])(?=.*[A - Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Enter uppercase,symbol,number")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Dont Match")]
        public string ConfirmPassword { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
        //[Required]
        public string Role { get; set; }
        public string HashCode { get; set; }
    }
    public class OrderModel
    {

        public DateTime OrderDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "PinCode Required")]
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }
    }
    
}