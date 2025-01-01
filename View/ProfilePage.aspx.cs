using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // check if session or cookies exist
                if (Session["user"] != null || Request.Cookies["userCookie"] != null)
                {
                    string userRole = "";
                    string userId = "";
                    // if cookies exist, get id from cookie
                    if (Request.Cookies["userCookie"] != null)
                    {
                        userId = Request.Cookies["userCookie"].Value;
                    }
                    // if cookies doesn't exist, get id from session
                    else
                    {
                        userId = (string)System.Web.HttpContext.Current.Session["user"];
                    }
                    // get role from id
                    userRole = UserController.validateRoleById(userId);

                    TBox_Username.Text = UserController.showUserName(userId);
                    TBox_Email.Text = UserController.showUserEmail(userId);
                    string gender = UserController.showUserGender(userId);
                    if (gender == "Male")
                    {
                        Rbt_Male.Checked = true;
                    }
                    else if (gender == "Female")
                    {
                        Rbt_Female.Checked = true;
                    }
                    TBox_DoB.Text = UserController.showUserDoB(userId);
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void IB_DoB_Click(object sender, ImageClickEventArgs e)
        {
            if (Cld_DoB.Visible == false)
            {
                Cld_DoB.Visible = true;
            }
            else if (Cld_DoB.Visible == true)
            {
                Cld_DoB.Visible = false;
            }
        }

        protected void Btn_Choose_Click(object sender, EventArgs e)
        {
            if(Cld_DoB.SelectedDate == DateTime.MinValue)
            {
                TBox_DoB.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                TBox_DoB.Text = Cld_DoB.SelectedDate.ToString("dd-MM-yyyy");
            }
        }

        protected void Btn_UpdateProfile_Click(object sender, EventArgs e)
        {
            string userId = "";
            if (Request.Cookies["userCookie"] != null)
            {
                userId = Request.Cookies["userCookie"].Value;
            }
            else
            {
                userId = (string)System.Web.HttpContext.Current.Session["user"];
            }
            string newUsername = TBox_Username.Text;
            string newEmail = TBox_Email.Text;
            string newGender = "";
            bool genderSelected = true;
            if (Rbt_Male.Checked)
            {
                newGender = Rbt_Male.Text;
            }
            else if (Rbt_Female.Checked)
            {
                newGender = Rbt_Female.Text;
            }
            else
            {
                genderSelected = false;
            }
            string newDoB = TBox_DoB.Text;

            Lbl_Status.Text = UserController.validateUpdateProfile(userId, newUsername, newEmail, newGender, genderSelected, newDoB);
            if (Lbl_Status.Text == "User profile has been updated successfully!")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_UpdatePass_Click(object sender, EventArgs e)
        {
            string userId = "";
            if (Request.Cookies["userCookie"] != null)
            {
                userId = Request.Cookies["userCookie"].Value;
            }
            else
            {
                userId = (string)System.Web.HttpContext.Current.Session["user"];
            }
            string oldPassword = TBox_OldPassword.Text;
            string newPassword = Tbox_NewPassword.Text;

            Lbl_PassStatus.Text = UserController.validateUpdatePassword(userId, oldPassword, newPassword);
            if (Lbl_PassStatus.Text == "User password has been updated sucessfully!")
            {
                Lbl_PassStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Lbl_PassStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}