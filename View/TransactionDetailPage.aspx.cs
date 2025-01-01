using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
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

                    TBox_TransactionId.Text = Request.QueryString["transactionId"];
                    TBox_UserId.Text = Request.QueryString["userId"];
                    TBox_TransactionDate.Text = TransactionController.showTransactionDate(TBox_TransactionId.Text);
                    TBox_Status.Text = TransactionController.showTransactionStatus(TBox_TransactionId.Text);

                    GV_TransactionList.DataSource = TransactionController.showTransactionDetails(TBox_TransactionId.Text);
                    GV_TransactionList.AutoGenerateColumns = false;
                    GV_TransactionList.DataBind();

                    Lbl_Total.Text = TransactionController.showTotalPrice(TBox_TransactionId.Text);
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HistoryPage.aspx");
        }
    }
}