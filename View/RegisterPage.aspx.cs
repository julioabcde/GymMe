using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class RegisterPage : System.Web.UI.Page
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

                    if (userRole == "Admin")
                    {
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/View/OrderSupplementPage.aspx");
                    }
                }
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

        protected void IB_DoB_Click(object sender, ImageClickEventArgs e)
        {
            if(Cld_DoB.Visible == false)
            {
                Cld_DoB.Visible = true;
            }
            else if(Cld_DoB.Visible == true)
            {
                Cld_DoB.Visible = false;
            }
        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            string username = TBox_Username.Text;
            string email = TBox_Email.Text;
            string gender = "";
            bool genderSelected = true;
            if (Rbt_Male.Checked)
            {
                gender = Rbt_Male.Text;
            }
            else if (Rbt_Female.Checked)
            {
                gender = Rbt_Female.Text;
            }
            else
            {
                genderSelected = false;
            }
            string dob = TBox_DoB.Text;
            string password = TBox_Password.Text;
            string confPass = Tbox_ConfPass.Text;

            Lbl_Status.Text = UserController.validateRegistration(username, email, gender, genderSelected, dob, password, confPass);
            if (Lbl_Status.Text == "Registration success!")
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}