using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class CartRepository
    {
        private static GymMeEntities db = DBInstance.getInstance();

        public static MsCart getCartByUserIdAndSupplementId(string userId, int supplementId)
        {
            int userID = Convert.ToInt32(userId);
            return db.MsCarts.Where(u => u.UserID == userID && u.SupplementID == supplementId).FirstOrDefault();
        }

        public static string addNewCart(MsCart newCart)
        {
            db.MsCarts.Add(newCart);
            db.SaveChanges();
            return "New cart has been added successfully!";
        }

        public static string updateQuantity(MsCart toUpdate, int quantity)
        {
            toUpdate.Quantity += quantity;
            db.SaveChanges();
            return "Cart has been updated successfully!";
        }

        public static List<object> getCartDetailListByUserId(string userId)
        {
            int userID = Convert.ToInt32(userId);
            // use LINQ query to join MsCart and MsSupplement table
            // to get supplement name and quantity of the ordered supplement
            var queryCartList = (
                from mc in db.MsCarts
                join ms in db.MsSupplements
                on mc.SupplementID equals ms.SupplementID
                where mc.UserID == userID
                select new
                {
                    ms.SupplementName,
                    mc.Quantity,
                    ms.SupplementPrice,
                    Subtotal = (ms.SupplementPrice * mc.Quantity)
                }
            ).ToList();

            // create a list of objects from the query result
            List<object> CartList = queryCartList.Select(x => (object)new
            {
                SupplementName = x.SupplementName,
                Quantity = x.Quantity,
                SupplementPrice = x.SupplementPrice,
                SubTotal = x.Subtotal
            }
            ).ToList();
            return CartList;
        }

        public static void deleteCarts(string userId)
        {
            int userID = Convert.ToInt32(userId);
            // use LINQ query to select all of the user's (based on the userId) carts into a list
            var toDelete = (
                from x in db.MsCarts
                where x.UserID == userID
                select x
            ).ToList();

            // iterate over each cart in the list from the query to be deleted
            foreach (var cart in toDelete)
            {
                db.MsCarts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static List<MsCart> getCartListById(string userId)
        {
            int userID = Convert.ToInt32(userId);
            return db.MsCarts.Where(u => u.UserID == userID).ToList();
        }
    }
}