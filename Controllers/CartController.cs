using System.Linq;
using System.Web.Mvc;
using AoqibaoStore.Abstract;
using AoqibaoStore.Models;
using System;
using System.Collections.Generic;
using AoqibaoStore.Concrete;

namespace AoqibaoStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        private IOrderRepository orderRepository;
     

        public CartController(IProductRepository repo,IOrderProcessor proc,IOrderRepository repoOrder)
        {
            repository = repo;
            orderProcessor = proc;
            orderRepository = repoOrder;
        }


        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel { 
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart,int productId, string returnUrl)
        {
           // Product product = repository.Products
            //                  .FirstOrDefault(p=> p.Id == productId);

           //Save to order, make sure only one context
            using (EFDbContext db = new EFDbContext())
            {
                Product product = db.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    cart.AddItem(product, 1);
                }
            }
            
           
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = repository.Products
                              .FirstOrDefault(p=>p.Id == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Checkout() {

            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("","Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                int latestOrderId = 0;
                if (orderRepository.Orders.Count() > 0)
                {
                   latestOrderId = orderRepository.Orders.Last().Id;
                }
             

                string orderIdString = String.Format("AU{0}{1}",DateTime.Now.ToString("YYYYMMDD"),latestOrderId+1);

                //Create an order using cart, shipping Details, return an order
                Order order = new Order();
                order.OrderNumber = orderIdString;
                order.OrderDate = DateTime.Now.ToString() ;
                order.shippingDetails = shippingDetails;

                foreach (var line in cart.Lines)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.product = line.Product;
                    orderDetail.Quantity = line.Quantity;
                    orderDetail.SalePrice = line.Product.unitPrice;
                   // orderDetail.OrderId = order.Id;
                    orderDetail.Status = 1;
                    order.OrderDetails.Add(orderDetail);
                }
             
               orderRepository.SaveOrder(order);
               orderProcessor.ProcessOrder(cart, shippingDetails);

                cart.Clear();
                return View("Completed");
            }
            else {
                return View(shippingDetails);
            }

        
        }

        //private Cart GetCart() {        
        //    Cart cart= (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}