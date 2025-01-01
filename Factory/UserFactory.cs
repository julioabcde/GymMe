using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class UserFactory
    {
        public static MsUser createNewUser(string username, string email, string gender, string dob, string password)
        {
            MsUser newUser = new MsUser();
            newUser.UserName = username;
            newUser.UserEmail = email;
            newUser.UserGender = gender;
            newUser.UserDOB = DateTime.ParseExact(dob, "dd-MM-yyyy", null);
            newUser.UserRole = "Customer";
            newUser.UserPassword = password;
            return newUser;
        }
    }
}