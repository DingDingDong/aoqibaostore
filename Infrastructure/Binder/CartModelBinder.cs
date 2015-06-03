using System.Web.Mvc;
using AoqibaoStore.Models;

namespace AoqibaoStore.Infrastructure.Binder
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        { 
            //get the Cart from the session
            Cart cart = null;

            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            //create the Cart if there was not one in the session data
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            //return the cart
            return cart;
        }
    }
}