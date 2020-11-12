using HomeKartEntity;
using NHibernate.Linq.Functions;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeKart.Models
{
    public class InventoryModel
    {
    }
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name = "ProductName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Price Required")]
        public int Price { get; set; }
        [Display(Name = "CategoryId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category ID Required")]
        public int CategoryId { get; set; }
        [Display(Name = "ProductImageName")]
        public string ProductImageName { get; set; }
        [Display(Name = "ProductImage")]
        public string ProductImage { get; set; }
    }
    public class ProductCategoryModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name Required")]
        public string CategoryName { get; set; }
        [Display(Name = "Product Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Description Required")]
        public string Description { get; set; }
    }
    public class CartModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price{get; set;}
        public int Total { get; set; }
        }
}