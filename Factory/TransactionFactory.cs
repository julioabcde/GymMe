using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader createNewTransactionHeader(string userId)
        {
            int userID = Convert.ToInt32(userId);
            TransactionHeader newTransactionHeader = new TransactionHeader();
            newTransactionHeader.UserID = userID;
            newTransactionHeader.TransactionDate = DateTime.Now;
            newTransactionHeader.Status = "Unhandled";
            return newTransactionHeader;
        }

        public static List<TransactionDetail> createTransactionDetailList(TransactionHeader newTransactionHeader, List<MsCart> CartList)
        {
            List<TransactionDetail> transactionDetailList = new List<TransactionDetail>();
            foreach (var cart in CartList)
            {
                TransactionDetail newTransactionDetail = new TransactionDetail();
                newTransactionDetail.TransactionID = newTransactionHeader.TransactionID;
                newTransactionDetail.SupplementID = cart.SupplementID;
                newTransactionDetail.Quantity = cart.Quantity;
                transactionDetailList.Add(newTransactionDetail);
            }
            return transactionDetailList;
        }
    }
}