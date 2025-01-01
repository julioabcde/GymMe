using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GymMe.Controller
{
    public class UserController
    {
        public static string validateRegistration(string username, string email, string gender, bool genderSelected, string dob, string password, string confPass)
        {
            // validate username
            // check if username is empty
            if (username == "")
            {
                return "Username is required!";
            }
            // check if username is < 5 or > 15
            if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be 5 to 15 characters long!";
            }

            // validate email
            // check if email is empty
            if (email == "")
            {
                return "Email is required!";
            }
            // check if email contains '@' and '.'
            if (!(email.Contains("@") || email.Contains(".")))
            {
                return "Email must contain '@' and '.'!";
            }
            // check if email is started with '@' or '.'
            if (email.StartsWith("@") || email.StartsWith("."))
            {
                return "Email can't be started with '@' or '.'!";
            }
            // loop to check if '@' and '.' are side by side
            for (int i = 0; i < email.Length - 1; i++)
            {
                if ((email[i] == '@' && email[i + 1] == '.') || (email[i] == '.' && email[i + 1] == '@'))
                {
                    return "'@' and '.' can't be placed side-by-side!";
                }
            }
            // check if email ends with ".com"
            if (email.EndsWith(".com") == false)
            {
                return "Email must end with '.com'!";
            }

            // check if gender is empty
            if (genderSelected == false)
            {
                return "Gender is required!";
            }

            // check if dob is empty
            if (dob == "")
            {
                return "Date of Birth is required!";
            }

            // validate password
            // check if password is empty
            if (password == "")
            {
                return "Password is required!";
            }
            // check if password is < 8 or > 16
            if (password.Length < 8 || password.Length > 16)
            {
                return "Passsword must be 8 to 16 charcters long!";
            }
            // check if password alphanumeric
            int capitalCounter = 0, lowerCounter = 0, numberCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                {
                    capitalCounter++;
                }
                else if (password[i] >= 'a' && password[i] <= 'z')
                {
                    lowerCounter++;
                }
                else if (password[i] >= '1' && password[i] <= '9')
                {
                    numberCounter++;
                }   
            }
            if (capitalCounter < 1 )
            {
                return "Password must contain at least 1 capital letter!";
            }
            if (lowerCounter < 1)
            {
                return "Password must contain at least 1 lower letter!";
            }
            if (numberCounter < 1)
            {
                return "Password must contain at least 1 number!";
            }
            // check if password and confPass is matched
            if (!(password.Equals(confPass)))
            {
                return "Your password and confirm password is not matched!";
            }

            return UserHandler.registerNewUser(username, email, gender, dob, password);
        }

        public static string validateLogin(string username, string password)
        {
            if (username == "")
            {
                return "Username is required!";
            }
            if (password == "")
            {
                return "Password is required!";
            }

            return UserHandler.logUserIn(username, password);
        }

        public static string validateRoleByUsername(string username)
        {
            return UserHandler.checkRoleByUsername(username);
        }
        
        public static string validateIdByUsername(string username)
        {
            return UserHandler.checkIdByUsername(username);
        }

        public static string validateRoleById(string id)
        {
            return UserHandler.checkRoleById(id);
        }

        public static List<object> showAllCustomers()
        {
            return UserHandler.getAllCustomers();
        }

        public static string showUserName(string userId)
        {
            return UserHandler.getUserName(userId);
        }
        
        public static string showUserEmail(string userId)
        {
            return UserHandler.getUserEmail(userId);
        }

        public static string showUserGender(string userId)
        {
            return UserHandler.getUserGender(userId);
        }

        public static string showUserDoB(string userId)
        {
            return UserHandler.getUserDoB(userId);
        }

        public static string validateUpdateProfile(string userId, string newUsername, string newEmail, string newGender, bool genderSelected, string newDob)
        {
            // validate username
            // check if username is empty
            if (newUsername == "")
            {
                return "Username is required!";
            }
            // check if username is < 5 or > 15
            if (newUsername.Length < 5 || newUsername.Length > 15)
            {
                return "Username must be 5 to 15 characters long!";
            }

            // validate email
            // check if email is empty
            if (newEmail == "")
            {
                return "Email is required!";
            }
            // check if email contains '@' and '.'
            if (!(newEmail.Contains("@") || newEmail.Contains(".")))
            {
                return "Email must contain '@' and '.'!";
            }
            // check if email is started with '@' or '.'
            if (newEmail.StartsWith("@") || newEmail.StartsWith("."))
            {
                return "Email can't be started with '@' or '.'!";
            }
            // loop to check if '@' and '.' are side by side
            for (int i = 0; i < newEmail.Length - 1; i++)
            {
                if ((newEmail[i] == '@' && newEmail[i + 1] == '.') || (newEmail[i] == '.' && newEmail[i + 1] == '@'))
                {
                    return "'@' and '.' can't be placed side-by-side!";
                }
            }
            // check if email ends with ".com"
            if (newEmail.EndsWith(".com") == false)
            {
                return "Email must end with '.com'!";
            }

            // check if gender is empty
            if (genderSelected == false)
            {
                return "Gender is required!";
            }

            // check if dob is empty
            if (newDob == "")
            {
                return "Date of Birth is required!";
            }
            
            return UserHandler.changeUserProfile(userId, newUsername, newEmail, newGender, newDob);
        }

        public static string validateUpdatePassword(string userId, string oldPassword, string newPassword)
        {
            // validate old password
            // check if old password is empty
            if (oldPassword == "")
            {
                return "Old password is required!";
            }
            bool isMatched = UserHandler.checkOldPassword(userId, oldPassword);
            // check if old password is match
            if (isMatched == false)
            {
                return "Old password is not matched!";
            }

            // validate new password
            // check if new password is empty
            if (newPassword == "")
            {
                return "New password is required!";
            }
            // check if new password is < 8 or > 16
            if (newPassword.Length < 8 || newPassword.Length > 16)
            {
                return "New password must be 8 to 16 charcters long!";
            }
            // check if new password alphanumeric
            int capitalCounter = 0, lowerCounter = 0, numberCounter = 0;
            for (int i = 0; i < newPassword.Length; i++)
            {
                if (newPassword[i] >= 'A' && newPassword[i] <= 'Z')
                {
                    capitalCounter++;
                }
                else if (newPassword[i] >= 'a' && newPassword[i] <= 'z')
                {
                    lowerCounter++;
                }
                else if (newPassword[i] >= '1' && newPassword[i] <= '9')
                {
                    numberCounter++;
                }
            }
            if (capitalCounter < 1)
            {
                return "New password must contain at least 1 capital letter!";
            }
            if (lowerCounter < 1)
            {
                return "New password must contain at least 1 lower letter!";
            }
            if (numberCounter < 1)
            {
                return "New password must contain at least 1 number!";
            }
            // check if new password == old password
            if (newPassword == oldPassword)
            {
                return "New password can't be the same as old password!";
            }
            
            return UserHandler.changeUserPassword(userId, newPassword);
        }
    }
}