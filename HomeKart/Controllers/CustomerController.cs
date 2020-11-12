using AutoMapper;
using HomeKart.Models;
using HomeKartBL;
using HomeKartDAL;
using HomeKartEntity;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeKart.Controllers
{
    [Authorize(Roles = "user")]
    public class CustomerController : Controller
    {
        InventoryBusinessLogic inventoryBusinessLogic;
        UserBusinessLogic userManager;
        public CustomerController()
        {
            inventoryBusinessLogic = new InventoryBusinessLogic();
            userManager = new UserBusinessLogic();
        }
        // GET: Customer
        public ActionResult CustomerHome()
        {
            return View();
        }
        public ActionResult CustomerDetails(int id)
        {

            return View(userManager.ToDisplay(id));
        }
        [HttpGet]
        [ActionName("SelfCustomerUpdate")]
        public ActionResult Update_Get(int id)
        {
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SelfCustomerUpdate")]
        public ActionResult Update_Post(int id, AccountModel userdata)
        {

            User registration = Mapper.Map<AccountModel, User>(userdata);
            registration.UpdatedDate = DateTime.Now;
            if (userManager.ToUpdate(registration) == true)
                return RedirectToAction("CustomerHome");
            return View();
        }
        public ActionResult CustomerProductCategoryData()
        {
            return View(inventoryBusinessLogic.ProductCategoryView());
        }
        public ActionResult CustomerCategoryDetails(int id)
        {

            return View(inventoryBusinessLogic.ToDisplayProductCategory(id));
        }

        public ActionResult CustomerProductData()
        {
            return View(inventoryBusinessLogic.ProductView());
        }
        public ActionResult CustomerProductDetails(int id)
        {
            return View(inventoryBusinessLogic.ToDisplayProduct(id));
        }
        public ActionResult AddToCartCustomer(int id)
        {
            using (UserDataBase userContext = new UserDataBase())
            {
                if (Session["cart"] == null)
                {
                    List<CartModel> cart = new List<CartModel>();
                    var product = userContext.product.Find(id);
                    cart.Add(new CartModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        Price = product.Price
                    }) ;
                    Session["cart"] = cart;
                }
                else
                {
                    List<CartModel> cart = (List<CartModel>)Session["cart"];
                    var product = userContext.product.Find(id);
                  
                    foreach(var item in cart)
                    {
                        if (item.ProductId == id)
                        {
                            int tempquantity = item.Quantity;
                            cart.Remove(item);
                            cart.Add(new CartModel()
                            {
                                ProductName = product.ProductName,
                                Quantity =tempquantity + 1,
                                ProductId = product.ProductId,
                                Price = product.Price
                            });
                            break;
                        }
                        else
                        {
                            cart.Add(new CartModel()
                            {
                                ProductName = product.ProductName,
                                Quantity = 1,
                                ProductId = product.ProductId,
                                Price = product.Price
                            });
                        }
                    }
                    if (cart.Count == 0)
                    {
                        cart.Add(new CartModel()
                        {
                            ProductName = product.ProductName,
                            Quantity = 1,
                            ProductId = product.ProductId,
                            Price = product.Price

                        });
                    }
                    Session["cart"] = cart;
                }
                return RedirectToAction("AddToCartCustomerDisplay");
            }
        }
        public ActionResult RemoveFromCartCustomer(int id)
        {
            using (UserDataBase userContext = new UserDataBase())
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                foreach (var item in cart)
                {
                    if(item.ProductId==id)
                    {
                        cart.Remove(item);
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("CustomerProductData");
        }
        public ActionResult AddToCartCustomerDisplay()
        {
            return View();
        }
        public ActionResult DecreaseQuantity(int id)
        {
            using (UserDataBase userContext = new UserDataBase())
            {
                if (Session["cart"] != null)
                {
                    List<CartModel> cart = (List<CartModel>)Session["cart"];
                    var product = userContext.product.Find(id);

                    foreach (var item in cart)
                    {
                        if (item.ProductId == id)
                        {
                            int tempquantity = item.Quantity;
                            if (tempquantity > 0)
                            {
                                cart.Remove(item);
                                cart.Add(new CartModel()
                                {
                                    ProductName = product.ProductName,
                                    Quantity = tempquantity - 1,
                                    ProductId = product.ProductId,
                                    Price = product.Price
                                });
                            }
                            break;
                        }
                    }
                    Session["cart"] = cart;
                }
            }
            return RedirectToAction("AddToCartCustomerDisplay");
        }
        [HttpGet]
        public ActionResult RegisterOrder()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterOrder(OrderModel ordermodel)
        {
            using (UserDataBase userContext = new UserDataBase())
            {
                if (ModelState.IsValid)
                {
                    int total = 0;
                    var user = userContext.user.Find((int)Session["UserId"]);
                    Orders registration = Mapper.Map<OrderModel, Orders>(ordermodel);
                    
                    foreach (var Item in (List<CartModel>)Session["cart"])
                    {
                        registration.CartId = user.UserId + "/" + user.CellNumber;
                        registration.UserMail = user.Email;
                        registration.UserId = user.UserId;
                        int lineTotal = Convert.ToInt32(Item.Quantity * Item.Price);
                        int Price = Convert.ToInt32(total + lineTotal);
                        registration.ProductName = Item.ProductName;
                        registration.Quantity = Item.Quantity;
                        registration.ProductId = Item.ProductId;
                        registration.Price = lineTotal;
                        if (userManager.ToRegisterOrder(registration) == true)
                            TempData["Message"] = "Registered Sucessfully";
                    }
                    return RedirectToAction("CustomerHome", "Customer");
                }
            }
            TempData["Message"] = "Try Again";
            return View();
        }
        public ActionResult ViewCustomerOrder()
        {
            return View(userManager.OrdersView());  
        }
    }
}
