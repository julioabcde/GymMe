using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class CartFactory
    {
        public static MsCart createNewCart(string userId, int supplementId, int quantity)
        {
            MsCart newCart = new MsCart();
            int userID = Convert.ToInt32(userId);
            int supplementID = supplementId;
            newCart.UserID = userID;
            newCart.SupplementID = supplementID;
            newCart.Quantity = quantity;
            return newCart;
        }
    }
}