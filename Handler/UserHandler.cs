using GymMe.Factory;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class UserHandler
    {
        public static string registerNewUser(string username, string email, string gender, string dob, string password)
        {
            // check if username or email has been used
            MsUser userByUsername = UserRepository.getUserByUsername(username);
            MsUser userByEmail = UserRepository.getUserByEmail(email);
            if (userByUsername != null)
            {
                return "This username has been used!";
            }
            if (userByEmail != null )
            {
                return "This email has been used!";
            }

            MsUser newUser = UserFactory.createNewUser(username, email, gender, dob, password);
            return UserRepository.addNewUser(newUser);
        }

        public static string logUserIn(string username, string password)
        {
            // check if user with current username and password exist
            MsUser userByUsernameAndPassword = UserRepository.getUserByUsernameAndPassword(username, password);
            if (userByUsernameAndPassword != null)
            {
                if (userByUsernameAndPassword.UserName == username && userByUsernameAndPassword.UserPassword == password)
                {
                    return "Login success!";
                }
            }
            return "User is not found";
        }

        public static string checkRoleByUsername(string username)
        {
            // check if user with current username exist
            MsUser userByUsername = UserRepository.getUserByUsername(username);
            if (userByUsername != null)
            {
                return userByUsername.UserRole;
            }
            return "";
        }

        public static string checkIdByUsername(string username)
        {
            // check if user with current username exist
            MsUser userByUsername = UserRepository.getUserByUsername(username);
            if (userByUsername != null)
            {
                return userByUsername.UserID.ToString();
            }
            return "0";
        }

        public static string checkRoleById(string id)
        {
            // check if user with current id exist
            MsUser userById = UserRepository.getUserById(id);
            if (userById != null)
            {
                return userById.UserRole;
            }
            return "";
        }

        public static List<object> getAllCustomers()
        {
            return UserRepository.getCustomerList();
        }

        public static string getUserName(string userId)
        {
            // check if user with current id exist
            MsUser userById = UserRepository.getUserById(userId);
            if (userById != null)
            {
                return userById.UserName;
            }
            return "";
        }

        public static string getUserEmail(string userId)
        {
            // check if user with current id exist
            MsUser userById = UserRepository.getUserById(userId);
            if (userById != null)
            {
                return userById.UserEmail;
            }
            return "";
        }

        public static string getUserGender(string userId)
        {
            // check if user with current id exist
            MsUser userById = UserRepository.getUserById(userId);
            if (userById != null)
            {
                return userById.UserGender;
            }
            return "";
        }

        public static string getUserDoB(string userId)
        {
            // check if user with current id exist
            MsUser userById = UserRepository.getUserById(userId);
            if (userById == null)
            {
                return userById.UserDOB.ToString("dd-MM-yyyy");
            }
            return "";
        }

        public static string changeUserProfile(string userId, string newUsername, string newEmail, string newGender, string newDob)
        {
            MsUser toUpdate = UserRepository.getUserById(userId);
            if (toUpdate != null)
            {
                return UserRepository.updateUserProfile(toUpdate, newUsername, newEmail, newGender, newDob);
            }
            return "User is not found!";
        }

        public static bool checkOldPassword(string userId, string oldPassword)
        {
            MsUser matched = UserRepository.getUserById(userId);
            if (matched != null)
            {
                if (matched.UserPassword == oldPassword)
                {
                    return true;
                }
            }
            return false;
        }

        public static string changeUserPassword(string userId, string newPassword)
        {
            MsUser toUpdate = UserRepository.getUserById(userId);
            if (toUpdate != null)
            {
                return UserRepository.updateUserPassword(toUpdate, newPassword);
            }
            return "User is not found!";
        }
    }
}