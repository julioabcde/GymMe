using GymMe.DataSet;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class TransactionRepository
    {
        private static GymMeEntities db = DBInstance.getInstance();
        
        public static void addNewTransactionHeader(TransactionHeader newTransactionHeader)
        {
            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();
        }

        public static void addNewTransactionDetails(List<TransactionDetail> newTransactionDetailsList)
        {
            // iterate each newTransactionDetail and add it to the database
            foreach (var newTransactionDetail in newTransactionDetailsList)
            {
                db.TransactionDetails.Add(newTransactionDetail);
            }
            db.SaveChanges();
        }

        public static TransactionDetail getTransactionBySupplementId(string supplementId)
        {
            int supplementID = Convert.ToInt32(supplementId);
            return db.TransactionDetails.Where(u => u.SupplementID == supplementID).FirstOrDefault();
        }

        public static List<TransactionHeader> getTransactionHeaderList()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader getTransactionById(string transactionId)
        {
            int transactionID = Convert.ToInt32(transactionId);
            return db.TransactionHeaders.Where(u => u.TransactionID == transactionID).FirstOrDefault();
        }

        public static void updateTransactionStatus(TransactionHeader toUpdate)
        {
            toUpdate.Status = "Handled";
            db.SaveChanges();
        }

        public static List<object> getHandledTransactionListByUserId(string userId)
        {
            int userID = Convert.ToInt32(userId);
            // use LINQ query to select transaction with "Handled" status based on the user id into a list
            var queryTransactionHistoryList = (
                from th in db.TransactionHeaders
                where ((th.UserID == userID) && (th.Status == "Handled"))
                select new
                {
                    th.TransactionID,
                    th.TransactionDate,
                    th.Status
                }
            ).ToList();

            // create a list of objects from the query result
            List<object> transactionHistoryList = queryTransactionHistoryList.Select(x => (object)new
                {
                    TransactionID = x.TransactionID,
                    TransactionDate = x.TransactionDate,
                    Status = x.Status
                }
            ).ToList();
            return transactionHistoryList;
        }

        public static List<TransactionHeader> getHandledTransactionList()
        {
            return db.TransactionHeaders.Where(u => u.Status == "Handled").ToList();
        }

        public static List<object> getTransactionDetailList(string transactionId)
        {
            int transsactionID = Convert.ToInt32(transactionId);
            // use LINQ query to join TransactionDetails and MsSupplement
            // to get supplement name, price, quantity, and calculate the subtotal of each supplement
            var queryTransactionDetailList = (
                from td in db.TransactionDetails
                join ms in db.MsSupplements
                on td.SupplementID equals ms.SupplementID
                where td.TransactionID == transsactionID
                select new
                {
                    ms.SupplementName,
                    ms.SupplementPrice,
                    td.Quantity,
                    subtotal = (ms.SupplementPrice * td.Quantity),
                }
            ).ToList();

            // create a list of objects from the query result
            List<object> transactionDetailList = queryTransactionDetailList.Select(x => (object)new
                {
                    SupplementName = x.SupplementName,
                    SupplementPrice = x.SupplementPrice,
                    Quantity = x.Quantity,
                    SubTotal = x.subtotal
                }
            ).ToList();

            return transactionDetailList;
        }

        public static string getGrandTotal(string transactionId)
        {
            int transsactionID = Convert.ToInt32(transactionId);
            // use LINQ query to join TransactionDetails and MsSupplement
            // to get supplement name, price, quantity, and calculate the subtotal of each supplement
            var queryTransactionDetailList = (
                from th in db.TransactionHeaders
                join td in db.TransactionDetails
                on th.TransactionID equals td.TransactionID
                join ms in db.MsSupplements
                on td.SupplementID equals ms.SupplementID
                where td.TransactionID == transsactionID
                select new
                {
                    ms.SupplementName,
                    ms.SupplementPrice,
                    td.Quantity,
                    subtotal = (ms.SupplementPrice * td.Quantity),
                }
            ).ToList();

            // calculate the grand total from each subtotal and convert to string
            string grandTotal = queryTransactionDetailList.Sum(x => x.subtotal).ToString();

            return grandTotal;
        }

        public static GymMeDataSet getGymMeDataSet(List<TransactionHeader> transactionHeaderList)
        {
            GymMeDataSet gymMeDataSet = new GymMeDataSet();
            var headerTable = gymMeDataSet.TransactionHeader;
            var detailTable = gymMeDataSet.TransactionDetail;
            var grandTotalTable = gymMeDataSet.GrandTotal;
            var grandTotalRow = grandTotalTable.NewRow();
            int total, subTotal, grandTotal = 0;
           
            foreach (TransactionHeader th in transactionHeaderList)
            {
                // setiap ada transaction header baru, bikin new row
                subTotal = 0;
                var headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = th.TransactionID;
                headerRow["Date"] = th.TransactionDate;
                headerTable.Rows.Add(headerRow);
                foreach (TransactionDetail td in th.TransactionDetails)
                {
                    total = 0;
                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = th.TransactionID;
                    detailRow["Supplement"] = td.MsSupplement.SupplementName;
                    detailRow["Price"] = td.MsSupplement.SupplementPrice;
                    detailRow["Quantity"] = td.Quantity;
                    total = (td.MsSupplement.SupplementPrice * td.Quantity);
                    detailRow["Total"] = total;
                    detailTable.Rows.Add(detailRow);

                    subTotal += total;
                }
                headerRow["SubTotal"] = subTotal;
                grandTotal += subTotal;
            }
            grandTotalRow["Grand Total"] = grandTotal;
            grandTotalTable.Rows.Add(grandTotalRow);
            
            return gymMeDataSet;
        }
    }
}