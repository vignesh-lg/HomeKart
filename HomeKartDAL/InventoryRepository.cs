using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HomeKartEntity;

namespace HomeKartDAL
{
    public interface I_ProductManipulation
    {
        bool ToRegisterProduct(Product product);
        List<Product> ProductView();
        object ToDisplayProduct(int ProductId);
        bool ToUpdateProduct(Product product);
        bool ToDeleteProduct(int ProductId, Product product);
    }
    public interface I_ProductCategoryManipulation
    {
        bool ToRegisterProductCategory(ProductCategory productCategory);
        List<ProductCategory> ProductCategoryView();
        object ToDisplayProductCategory(int CategoryId);
        bool ToUpdateProductCategory(ProductCategory productCategory);
        bool ToDeleteProductCategory(int CategoryId, ProductCategory productCategory);
    }
    public class InventoryRepository : I_ProductManipulation, I_ProductCategoryManipulation
    {
        public bool ToRegisterProduct(Product product)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.product.Add(product);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<Product> ProductView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.product.ToList();
            }

        }
        public object ToDisplayProduct(int ProductId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.product.Where(model => model.ProductId == ProductId).FirstOrDefault();
            }
        }
        public bool ToUpdateProduct(Product product)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(product).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }

        }
        public bool ToDeleteProduct(int ProductId, Product product)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                product = userDataBase.product.Where(model => model.ProductId == ProductId).FirstOrDefault();
                userDataBase.product.Remove(product);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public bool ToRegisterProductCategory(ProductCategory productCategory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.productcategory.Add(productCategory);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<ProductCategory> ProductCategoryView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.productcategory.ToList();
            }

        }
        public object ToDisplayProductCategory(int CategoryId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.productcategory.Where(model => model.CategoryId == CategoryId).FirstOrDefault();
            }
        }
        public bool ToUpdateProductCategory(ProductCategory productCategory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(productCategory).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }

        }
        public bool ToDeleteProductCategory(int CategoryId, ProductCategory productCategory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                productCategory = userDataBase.productcategory.Where(model => model.CategoryId == CategoryId).FirstOrDefault();
                userDataBase.productcategory.Remove(productCategory);
                userDataBase.SaveChanges();
                return true;
            }
        }
 
    }
}
