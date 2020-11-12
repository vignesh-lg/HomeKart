using HomeKartDAL;
using HomeKartEntity;
using System.Collections.Generic;
using System.Linq;

namespace HomeKartBL
{
    public class InventoryBusinessLogic
    {
        I_ProductCategoryManipulation categoryManipulation = new InventoryRepository();
        I_ProductManipulation productManipulation = new InventoryRepository();
        public bool ToRegisterProduct(Product product)
        {
            return productManipulation.ToRegisterProduct(product);

        }
        public List<Product> ProductView()
        {
            return productManipulation.ProductView();
        }
        public object ToDisplayProduct(int ProductId)
        {
            return productManipulation.ToDisplayProduct(ProductId);
        }
        public bool ToUpdateProduct(Product product)
        {
            return productManipulation.ToUpdateProduct(product);
        }
        public bool ToDeleteProduct(int ProductId, Product product)
        {
            return productManipulation.ToDeleteProduct(ProductId, product);
        }
        public bool ToRegisterProductCategory(ProductCategory productCategory)
        {
            return categoryManipulation.ToRegisterProductCategory(productCategory);

        }
        public List<ProductCategory> ProductCategoryView()
        {
            return categoryManipulation.ProductCategoryView();
        }
        public object ToDisplayProductCategory(int CategoryId)
        {
            return categoryManipulation.ToDisplayProductCategory(CategoryId);
        }
        public bool ToUpdateProductCategory(ProductCategory productCategory)
        {
            return categoryManipulation.ToUpdateProductCategory(productCategory);
        }
        public bool ToDeleteProductCategory(int CategoryId, ProductCategory productCategory)
        {
            return categoryManipulation.ToDeleteProductCategory(CategoryId, productCategory);
        }
    }
}
