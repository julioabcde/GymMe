using GymMe.Factory;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GymMe.Handler
{
    public class CartHandler
    {
        public static string checkOrder(string userId, string supplementName, int quantity)
        {
            // check if supplement by current name exist
            MsSupplement supplementByName = SupplementRepository.getSupplementByName(supplementName);
            int supplementId = 0;
            if (supplementByName != null)
            {
                // if yes, get the id
                supplementId = supplementByName.SupplementID;
            }

            // check if cart with current userId and supplementId exist
            MsCart cartByUserIdAndSupplementId = CartRepository.getCartByUserIdAndSupplementId(userId, supplementId);
            // if no, create and insert a new cart to database
            if (cartByUserIdAndSupplementId == null )
            {
                MsCart newCart = CartFactory.createNewCart(userId, supplementId, quantity);
                return CartRepository.addNewCart(newCart);
            }
            // if yes, update the quantity of the supplement in the cart
            return CartRepository.updateQuantity(cartByUserIdAndSupplementId, quantity);
        }

        public static List<object> getCartDetailsByUserId(string userId)
        {
            return CartRepository.getCartDetailListByUserId(userId);
        }

        public static void removeCarts(string userId)
        {
            CartRepository.deleteCarts(userId);
        }

        public static void checkOutCart(string userId)
        {
            // check if cartList with current id exist
            List<MsCart> CartList = CartRepository.getCartListById(userId);
            if (CartList != null)
            {
                // if yes, create and save a new transaction header into the database
                TransactionHeader newTransactionHeader = TransactionFactory.createNewTransactionHeader(userId);
                TransactionRepository.addNewTransactionHeader(newTransactionHeader);

                // once the header is created, create and save a list of transaction details into the database
                List<TransactionDetail> newTransactionDetailList = TransactionFactory.createTransactionDetailList(newTransactionHeader, CartList);
                TransactionRepository.addNewTransactionDetails(newTransactionDetailList);

                // remove cartList
                removeCarts(userId);
            }
        }
    }
}