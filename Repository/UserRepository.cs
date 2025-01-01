using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GymMe.Repository
{
    public class UserRepository
    {
        private static GymMeEntities db = DBInstance.getInstance();

        public static string addNewUser(MsUser newUser)
        {
                db.MsUsers.Add(newUser);
                db.SaveChanges();
                return "Registration success!";
        }

        public static MsUser getUserByEmail(string email)
        {
            return db.MsUsers.Where(u => u.UserEmail == email).FirstOrDefault();
        }

        public static MsUser getUserByUsername(string username)
        {
            return db.MsUsers.Where(u => u.UserName == username).FirstOrDefault();
        }
        
        public static MsUser getUserByUsernameAndPassword(string username, string password)
        {
            return db.MsUsers.Where(u => u.UserName == username && u.UserPassword == password).FirstOrDefault();
        }

        public static MsUser getUserById(string id)
        {
            int userId = Convert.ToInt32(id);
            return db.MsUsers.Where(u => u.UserID == userId).FirstOrDefault();
        }

        public static List<object> getCustomerList()
        {
            // use LINQ query to get users with "Customer" role
            // and all their attributes, except for user password into a list
            var queryCustomer = (
                from x in db.MsUsers
                where x.UserRole == "Customer"
                select new
                {
                    x.UserID,
                    x.UserName,
                    x.UserEmail,
                    x.UserDOB,
                    x.UserGender,
                    x.UserRole,
                }
             ).ToList();

            // create a list of objects from the query result
            List<object> customerList = queryCustomer.Select(x => (object) new
                {
                    UserID = x.UserID,
                    UserName = x.UserName,
                    UserEmail = x.UserEmail,
                    UserDOB = x.UserDOB,
                    UserGender = x.UserGender,
                    UserRole = x.UserRole
                }
            ).ToList();

            return customerList;
        }

        public static string updateUserProfile(MsUser toUpdate, string newUsername, string newEmail, string newGender, string newDob)
        {
            toUpdate.UserName = newUsername;
            toUpdate.UserEmail = newEmail;
            toUpdate.UserGender = newGender;
            toUpdate.UserDOB = DateTime.ParseExact(newDob, "dd-MM-yyyy", null); ;
            db.SaveChanges();
            return "User profile has been updated successfully!";
        }

        public static string updateUserPassword(MsUser toUpdate, string newPassword)
        {
            toUpdate.UserPassword = newPassword;
            db.SaveChanges();
            return "User password has been updated sucessfully!";
        }
    }
}