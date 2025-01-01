using GymMe.Factory;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class SupplementRepository
    {
        private static GymMeEntities db = DBInstance.getInstance();

        public static MsSupplementType getSupplementTypeByName(string type)
        {
            return db.MsSupplementTypes.Where(u => u.SupplementTypeName == type).FirstOrDefault();
        }

        public static int addNewSupplementType(MsSupplementType newSupplementType)
        {
            db.MsSupplementTypes.Add(newSupplementType);
            db.SaveChanges();
            return newSupplementType.SupplementTypeID;
        }
        
        public static MsSupplement getSupplementByName(string name)
        {
           return db.MsSupplements.Where(u => u.SupplementName == name).FirstOrDefault();
        }

        public static string addNewSupplement(MsSupplement newSupplement)
        {
            db.MsSupplements.Add(newSupplement);
            db.SaveChanges();
            return "New supplement has been added successfully!";
        }

        public static List<MsSupplement> getSupplementList()
        {
            return db.MsSupplements.ToList();
        }

        public static MsSupplement getSupplementById(string supplementId)
        {
            int supplementID = Convert.ToInt32(supplementId);
            return db.MsSupplements.Where(u => u.SupplementID == supplementID).FirstOrDefault();
        }

        public static string deleteSupplement(MsSupplement toDelete)
        {
            db.MsSupplements.Remove(toDelete);
            db.SaveChanges();
            return "Supplement has been deleted successfully!";
        }

        public static MsSupplementType getSupplementTypeById(string typeId)
        {
            int typeID = Convert.ToInt32(typeId);
            return db.MsSupplementTypes.Where(u => u.SupplementTypeID == typeID).FirstOrDefault();
        }

        public static string updateSupplement(MsSupplement toUpdate, string id, string newName, string newExpiryDate, string newPrice, string newTypeId)
        {
            toUpdate.SupplementName = newName;
            toUpdate.SupplementExpiryDate = DateTime.ParseExact(newExpiryDate, "dd-MM-yyyy", null);
            toUpdate.SupplementPrice = Convert.ToInt32(newPrice);
            toUpdate.SupplementTypeID = Convert.ToInt32(newTypeId);
            db.SaveChanges();
            return "Supplement has been updated successfully!";
        }

        public static List<object> getSupplementDetailList()
        {
            // use LINQ query to join MsSupplement and MsSupplementType table
            // to get supplement name, expiry date, price, and type name into a list
            var querySupplementDetails = (
                from s in db.MsSupplements
                join st in db.MsSupplementTypes
                on s.SupplementTypeID equals st.SupplementTypeID
                select new
                {
                    s.SupplementName,
                    s.SupplementExpiryDate,
                    s.SupplementPrice,
                    st.SupplementTypeName
                }
            ).ToList();

            // create a list of objects from the query result
            List<object> SupplementDetailList = querySupplementDetails.Select(x => (object)new
                {
                    SupplementName = x.SupplementName,
                    SupplementExpiryDate = x.SupplementExpiryDate,
                    SupplementPrice = x.SupplementPrice,
                    SupplementTypeName = x.SupplementTypeName
                }
            ).ToList();

            return SupplementDetailList;
        }
    }
}