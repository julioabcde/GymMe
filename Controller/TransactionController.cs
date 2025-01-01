using GymMe.DataSet;
using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> showTransactionQueue()
        {
            return TransactionsHandler.getTransactionQueue();
        }

        public static void validateHandleTransaction(string transactionId)
        {
            TransactionsHandler.handleTransaction(transactionId);
        }

        public static List<object> showHandledTransactionsByUserId(string userId)
        {
            return TransactionsHandler.getHandledTransactionsByUserId(userId);
        }

        public static List<TransactionHeader> showHandledTransactions()
        {
            return TransactionsHandler.getHandledTransactions();
        }

        public static string showTransactionDate(string transactionId)
        {
            return TransactionsHandler.getTransactionDate(transactionId);
        }

        public static string showTransactionStatus(string transactionId)
        {
            return TransactionsHandler.getTransactionStatus(transactionId);
        }

        public static List<object> showTransactionDetails(string transactionId)
        {
            return TransactionsHandler.getTransactionDetails(transactionId);
        }

        public static string showTotalPrice(string transactionId)
        {
            return TransactionsHandler.getTotalPrice(transactionId);
        }

        public static GymMeDataSet showDataSet()
        {
            return TransactionsHandler.getDataSet();
        }
    }
}