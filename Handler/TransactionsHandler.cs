using GymMe.DataSet;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class TransactionsHandler
    {
        public static List<TransactionHeader> getTransactionQueue()
        {
            return TransactionRepository.getTransactionHeaderList();
        }

        public static void handleTransaction(string transactionId)
        {
            // check if transaction with current transaction id exist
            TransactionHeader toUpdate = TransactionRepository.getTransactionById(transactionId);
            if (toUpdate != null)
            {
                TransactionRepository.updateTransactionStatus(toUpdate);
            }
        }

        public static List<object> getHandledTransactionsByUserId(string userId)
        {
            return TransactionRepository.getHandledTransactionListByUserId(userId);
        }

        public static List<TransactionHeader> getHandledTransactions()
        {
            return TransactionRepository.getHandledTransactionList();
        }

        public static string getTransactionDate(string transactionId)
        {
            // check if transaction with current transaction id exist
            TransactionHeader transactionById = TransactionRepository.getTransactionById(transactionId);
            if(transactionById != null)
            {
                return transactionById.TransactionDate.ToString("dd-MM-yyyy");
            }
            return "";
        }

        public static string getTransactionStatus(string transactionId)
        {
            // check if transaction with current transaction id exist
            TransactionHeader transactionById = TransactionRepository.getTransactionById(transactionId);
            if (transactionById != null)
            {
                return transactionById.Status;
            }
            return "";
        }

        public static List<object> getTransactionDetails(string transactionId)
        {
            return TransactionRepository.getTransactionDetailList(transactionId);
        }

        public static string getTotalPrice(string transactionId)
        {
            return TransactionRepository.getGrandTotal(transactionId);
        }

        public static GymMeDataSet getDataSet()
        {
            List<TransactionHeader> transactionHeaderList = TransactionRepository.getTransactionHeaderList();
            return TransactionRepository.getGymMeDataSet(transactionHeaderList);
        }
    }
}