using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Layout
{
    public partial class NavBar : System.Web.UI.MasterPage
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

                    if (userRole == "Customer")
                    {
                        Btn_OrderSupplement.Visible = true;
                        Btn_History.Visible = true;
                        Btn_Profile.Visible = true;
                        Btn_Logout.Visible = true;
                    }
                    else if (userRole == "Admin")
                    {
                        Btn_Home.Visible = true;
                        Btn_ManageSupplement.Visible = true;
                        Btn_OrderQueue.Visible = true;
                        Btn_History.Visible = true;
                        Btn_Profile.Visible = true;
                        Btn_TransactionReport.Visible = true;
                        Btn_Logout.Visible = true;
                    }
                }
            }
        }

        protected void Btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies["userCookie"].Expires = DateTime.Now.AddDays(-2);
            Session.Remove("user");
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void Btn_ManageSupplement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageSupplementPage.aspx");
        }

        protected void Btn_OrderSupplement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderSupplementPage.aspx");
        }

        protected void Btn_History_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HistoryPage.aspx");
        }

        protected void Btn_OrderQueue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionQueuePage.aspx");
        }

        protected void Btn_Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProfilePage.aspx");
        }

        protected void Btn_TransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionReportPage.aspx");
        }
    }
}