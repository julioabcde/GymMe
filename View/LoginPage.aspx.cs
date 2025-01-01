using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class LoginPage : System.Web.UI.Page
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

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            string username = TBox_Username.Text;
            string password = TBox_Password.Text;
            bool isRemembered = CBox_RememberMe.Checked;

            Lbl_Status.Text = UserController.validateLogin(username, password);
            if (Lbl_Status.Text == "Login success!")
            {
                string role = UserController.validateRoleByUsername(username);
                string id = UserController.validateIdByUsername(username);
                Session["user"] = id;
                if (isRemembered == true)
                {
                    HttpCookie userCookie = new HttpCookie("userCookie");
                    userCookie.Value = id;
                    userCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userCookie);
                }

                if (role == "Admin")
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                else
                {
                    Response.Redirect("~/View/OrderSupplementPage.aspx");
                }
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}