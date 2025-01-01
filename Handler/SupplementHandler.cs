using GymMe.Factory;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class SupplementHandler
    {
        public static string insertNewSupplement(string name, string expiryDate, string price, string typeID)
        {
            // check if supplement with current name exist
            MsSupplement supplementByName = SupplementRepository.getSupplementByName(name);
            if (supplementByName != null)
            {
                if (supplementByName.SupplementName == name)
                {
                    return "This supplement is already exist!";
                }
            }
            MsSupplement newSupplement = SupplementFactory.createSupplement(name, expiryDate, price, typeID);
            return SupplementRepository.addNewSupplement(newSupplement);
        }

        public static List<MsSupplement> getAllSupplements()
        {
            return SupplementRepository.getSupplementList();
        }

        public static string removeSupplement(string id)
        {
            // check if supplement with current id has been checked out
            TransactionDetail transactionBySupplementId = TransactionRepository.getTransactionBySupplementId(id);
            if (transactionBySupplementId == null)
            {
                MsSupplement toDelete = SupplementRepository.getSupplementById(id);
                return SupplementRepository.deleteSupplement(toDelete);
            }
            return "Supplement data exist in another table!";
        }

        public static string getSupplementName(string id)
        {
            // check if supplement with current id exist
            MsSupplement supplementById = SupplementRepository.getSupplementById(id);
            if (supplementById != null)
            {
                return supplementById.SupplementName;
            }
            return "";
        }

        public static string getSupplementExpiryDate(string id)
        {
            // check if supplement with current id exist
            MsSupplement supplementById = SupplementRepository.getSupplementById(id);
            if (supplementById != null)
            {
                return supplementById.SupplementExpiryDate.ToString("dd-MM-yyyy");
            }
            return "";
        }

        public static string getSupplementPrice(string id)
        {
            // check if supplement with current id exist
            MsSupplement supplementById = SupplementRepository.getSupplementById(id);
            if (supplementById != null)
            {
                return supplementById.SupplementPrice.ToString();
            }
            return "";
        }

        public static string getSupplementTypeName(string typeId)
        {
            // check if supplement type with current id exist
            MsSupplementType supplementTypeById = SupplementRepository.getSupplementTypeById(typeId);
            if (supplementTypeById != null)
            {
                return supplementTypeById.SupplementTypeName;
            }
            return "Not available!";
        }

        public static string changeSupplement(string id, string newName, string newExpiryDate, string newPrice, string newTypeID)
        {
            MsSupplement toUpdate = SupplementRepository.getSupplementById(id);
            if (toUpdate != null)
            {
                return SupplementRepository.updateSupplement(toUpdate, id, newName, newExpiryDate, newPrice, newTypeID);
            }
            return "Supplement is not found!";

        }

        public static List<object> getAllSupplementDetails()
        {
            return SupplementRepository.getSupplementDetailList();
        }
    }
}