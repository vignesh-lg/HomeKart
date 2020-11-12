using AutoMapper;
using HomeKart.Models;
using HomeKartBL;
using HomeKartEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeKart.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        UserBusinessLogic userManager;
        InventoryBusinessLogic inventoryBusinessLogic;
        public AdminController()
        {
            inventoryBusinessLogic = new InventoryBusinessLogic();
            userManager = new UserBusinessLogic();
        }
        // GET: Admin
        public ActionResult AdminHome()
        {
            return View();
        }
        [HttpGet]

        public ActionResult CustomerData()
        {
            return View(userManager.CustomerView());
        }
        [HttpGet]
        [ActionName("Admin_Registration")]
        public ActionResult Registration_Get()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Admin_Registration")]
        public ActionResult Registration_Post(AccountModel userdata)
        {

            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<AccountModel, User>(userdata);
                registration.Role = Role.user.ToString();
                registration.Password = "HKrt" + registration.CellNumber;
                if (userManager.ToRegister(registration) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("CustomerData", "Admin");
            }
            TempData["Message"] = "Try Again";
            return View();
        }

        public ActionResult Details(int id)
        {

            return View(userManager.ToDisplay(id));
        }
        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update_Get(int id)
        {
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update_Post(int id, AccountModel userdata)
        {
           
                User registration = Mapper.Map<AccountModel, User>(userdata);
                registration.UpdatedDate = DateTime.Now;
                if (userManager.ToUpdate(registration) == true)
                    return RedirectToAction("CustomerData");
            return View();
        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id, User userdata)
        {

            if (userManager.ToDelete(id, userdata) == true)
                return RedirectToAction("CustomerData");
            return View();
        }







        public ActionResult ProductCategoryData()
        {
            return View(inventoryBusinessLogic.ProductCategoryView());
        }
        [HttpGet]
        [ActionName("CategoryRegistration")]
        public ActionResult CategoryRegistration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CategoryRegistration")]
        public ActionResult CategoryRegistration(ProductCategoryModel categorydata)
        {
            if (ModelState.IsValid)
            {
                ProductCategory category = Mapper.Map<ProductCategoryModel, ProductCategory>(categorydata);
                if (inventoryBusinessLogic.ToRegisterProductCategory(category) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("ProductCategoryData", "Admin");
            }
            TempData["Message"] = "Try Again";
            return View();
        }

        public ActionResult CategoryDetails(int id)
        {

            return View(inventoryBusinessLogic.ToDisplayProductCategory(id));
        }
        [HttpGet]
        [ActionName("UpdateCategory")]
        public ActionResult UpdateCategory(int id)
        {
            return View(inventoryBusinessLogic.ToDisplayProductCategory(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("UpdateCategory")]
        public ActionResult UpdateCategory(int id, ProductCategoryModel categorydata)
        {

            ProductCategory category = Mapper.Map<ProductCategoryModel, ProductCategory>(categorydata);
            if (inventoryBusinessLogic.ToUpdateProductCategory(category) == true)
                return RedirectToAction("ProductCategoryData");
            return View();
        }
        [HttpGet]
        [ActionName("DeleteCategory")]
        public ActionResult DeleteCategory(int id)
        {
            return View(inventoryBusinessLogic.ToDisplayProductCategory(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCategory")]
        public ActionResult DeleteCategory(int id, ProductCategory productCategory)
        {

            if (inventoryBusinessLogic.ToDeleteProductCategory(id, productCategory) == true)
                return RedirectToAction("ProductCategoryData");
            return View();
        }















        public ActionResult ProductData()
        {
            return View(inventoryBusinessLogic.ProductView());
        }
        [HttpGet]
        [ActionName("ProductRegistration")]
        public ActionResult ProductRegistration()
        {
            ViewBag.State = new SelectList(inventoryBusinessLogic.ProductCategoryView(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductRegistration")]
        public ActionResult ProductRegistration(HttpPostedFileBase fileupload,ProductModel productdata)
        {
            ViewBag.State = new SelectList(inventoryBusinessLogic.ProductCategoryView(), "CategoryId","CategoryName");
            if (ModelState.IsValid && fileupload!=null)
            {
                productdata.ProductImageName = Path.GetFileName(fileupload.FileName);
                fileupload.SaveAs(Server.MapPath("~/Images/" + productdata.ProductImageName));
                productdata.ProductImage = "~/Images/" + productdata.ProductImageName;
                Product product = Mapper.Map<ProductModel, Product>(productdata);
                if (inventoryBusinessLogic.ToRegisterProduct(product) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("ProductData", "Admin");
            }
            TempData["Message"] = "Try Again";
            return View();
        }

        public ActionResult ProductDetails(int id)
        {

            return View(inventoryBusinessLogic.ToDisplayProduct(id));
        }
        [HttpGet]
        [ActionName("UpdateProduct")]
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.State = new SelectList(inventoryBusinessLogic.ProductCategoryView(), "CategoryId", "CategoryName");
            return View(inventoryBusinessLogic.ToDisplayProduct(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("UpdateProduct")]
        public ActionResult UpdateProduct(int id, ProductModel productdata, HttpPostedFileBase fileupload)
        {
            ViewBag.State = new SelectList(inventoryBusinessLogic.ProductCategoryView(), "CategoryId", "CategoryName");
            if (fileupload != null)
            {
                productdata.ProductImageName = Path.GetFileName(fileupload.FileName);
                fileupload.SaveAs(Server.MapPath("~/Images/" + productdata.ProductImageName));
                productdata.ProductImage = "~/Images/" + productdata.ProductImageName;
                Product product = Mapper.Map<ProductModel, Product>(productdata);
                if (inventoryBusinessLogic.ToUpdateProduct(product) == true)
                    return RedirectToAction("ProductData");
            }
            return View();
        }
        [HttpGet]
        [ActionName("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            return View(inventoryBusinessLogic.ToDisplayProduct(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteProduct")]
        public ActionResult DeleteProduct(int id, Product product)
        {
            if (inventoryBusinessLogic.ToDeleteProduct(id, product) == true)
                return RedirectToAction("ProductData");
            return View();
        }
    }
}