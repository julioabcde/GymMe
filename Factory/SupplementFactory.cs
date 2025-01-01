using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class SupplementFactory
    {
        public static MsSupplementType createSupplementType(string type)
        {
            MsSupplementType newSupplementType = new MsSupplementType();
            newSupplementType.SupplementTypeName = type;
            return newSupplementType;
        }

        public static MsSupplement createSupplement(string name, string expiryDate, string price, string typeId)
        {
            int typeID = Convert.ToInt32(typeId);
            MsSupplement newSupplement = new MsSupplement();
            newSupplement.SupplementName = name;
            newSupplement.SupplementExpiryDate = DateTime.ParseExact(expiryDate, "dd-MM-yyyy", null);
            newSupplement.SupplementPrice = Convert.ToInt32(price);
            newSupplement.SupplementTypeID = typeID;
            return newSupplement;
        }
    }
}