using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class CartController
    {
        public static string validateOrder(string userId, string supplementName, string quantity)
        {
            // check if quantity is not filled
            if(quantity == "")
            {
                return "Quantity can't be empty";
            }
            int qty = Convert.ToInt32(quantity);
            // check if quantity <= 0
            if (qty <= 0)
            {
                return "Quantity must be more than 0!";
            }
            return CartHandler.checkOrder(userId, supplementName, qty);
        }

        public static List<object> showCartDetailsByUserId(string userId)
        {
            return CartHandler.getCartDetailsByUserId(userId);
        }

        public static void clearCarts(string userId)
        {
            CartHandler.removeCarts(userId);
        }

        public static void validateCheckOut(string userId)
        {
            CartHandler.checkOutCart(userId);
        }
    }
}