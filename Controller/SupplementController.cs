using GymMe.Handler;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class SupplementController
    {
        public static string validateInsertSupplement(string name, string expiryDate, string price, string typeId, string typeName)
        {
            // validate name
            // check if name is empty
            if (name == "")
            {
                return "Name is required!";
            }
            // check if name contains "Supplement"
            if (name.Contains("Supplement") == false)
            {
                return "Name must contain \"Supplement\"";
            }

            // validate expiry date
            // check if expiry date is empty
            if (expiryDate == "")
            {
                return "Expiry date is required!";
            }
            // check if expiry date is > current date
            //DateTime expiry = DateTime.ParseExact(expiryDate, "dd-MM-yyyy", null);
            int isEarly = DateTime.Compare(DateTime.ParseExact(expiryDate, "dd-MM-yyyy", null), DateTime.Today);
            if (isEarly <= 0)
            {
                return "Expiry date must be greater than current date!";
            }

            // validate price
            // check if price is empty
            if (price == "")
            {
                return "Price is required!";
            }
            // check if price is < 3000
            if (Convert.ToInt32(price) < 3000)
            {
                return "Price must be at least 3000";
            }

            // validate type
            // check if type id is empty
            if (typeId == "")
            {
                return "Supplement type ID is required!";
            }
            // check if type name is not exist
            if (typeName == "Not available!")
            {
                return "Choose an available supplement type ID!";
            }

            return SupplementHandler.insertNewSupplement(name, expiryDate, price, typeId);
        }

        public static List<MsSupplement> showAllSupplements()
        {
            return SupplementHandler.getAllSupplements();
        }

        public static string validateDeleteSupplement(string id)
        {
            return SupplementHandler.removeSupplement(id);
        }

        public static string showSupplementName(string id)
        {
            return SupplementHandler.getSupplementName(id);
        }

        public static string showSupplementExpiryDate(string id)
        {
            return SupplementHandler.getSupplementExpiryDate(id);
        }

        public static string showSupplementPrice(string id)
        {
            return SupplementHandler.getSupplementPrice(id);
        }

        public static string showSupplementTypeName(string typeId)
        {
            return SupplementHandler.getSupplementTypeName(typeId);
        }

        public static string validateUpdateSupplement(string id, string newName, string newExpiryDate, string newPrice, string newTypeId, string newTypeName)
        {
            // validate name
            // check if name is empty
            if (newName == "")
            {
                return "Name is required!";
            }
            // check if name contains "Supplement"
            if (newName.Contains("Supplement") == false)
            {
                return "Name must contain \"Supplement\"";
            }

            // validate expiry date
            // check if expiry date is empty
            if (newExpiryDate == "")
            {
                return "Expiry date is required!";
            }
            // check if expiry date is > current date
            DateTime expiry = DateTime.ParseExact(newExpiryDate, "dd-MM-yyyy", null);
            //DateTime expiry = DateTime.Parse(expiryDate);
            int isEarly = DateTime.Compare(expiry, DateTime.Now.Date);
            if (isEarly <= 0)
            {
                return "Expiry date must be greater than current date!";
            }

            // validate price
            // check if price is empty
            if (newPrice == "")
            {
                return "Price is required!";
            }
            // check if price is < 3000
            if (Convert.ToInt32(newPrice) < 3000)
            {
                return "Price must be at least 3000";
            }

            // validate type
            // check if type id is empty
            if (newTypeId == "")
            {
                return "Supplement type ID is required!";
            }
            // check if type name is not exist
            if (newTypeName == "Not available!")
            {
                return "Choose an available supplement type ID!";
            }

            return SupplementHandler.changeSupplement(id, newName, newExpiryDate, newPrice, newTypeId);
        }

        public static List<object> showAllSupplementsDetails()
        {
            return SupplementHandler.getAllSupplementDetails();
        }
    }
}