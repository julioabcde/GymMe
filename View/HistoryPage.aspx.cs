using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class HistoryPage : System.Web.UI.Page
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
                        GV_TransactionListCustomer.Visible = true;
                        GV_TransactionListCustomer.DataSource = TransactionController.showHandledTransactionsByUserId(userId);
                        GV_TransactionListCustomer.AutoGenerateColumns = false;
                        GV_TransactionListCustomer.DataBind();
                    }
                    else
                    {
                        GV_TransactionListAdmin.Visible = true;
                        GV_TransactionListAdmin.DataSource = TransactionController.showHandledTransactions();
                        GV_TransactionListAdmin.AutoGenerateColumns = false;
                        GV_TransactionListAdmin.DataBind();
                    }
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void GV_TransactionListCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transactionId = GV_TransactionListCustomer.SelectedRow.Cells[1].Text;
            string userId = "";
            if (Request.Cookies["userCookie"] != null)
            {
                userId = Request.Cookies["userCookie"].Value;
            }
            else
            {
                userId = (string)System.Web.HttpContext.Current.Session["user"];
            }
            string url = string.Format("~/View/TransactionDetailPage.aspx?transactionId={0}&userId={1}", transactionId, userId);
            Response.Redirect(url);
        }

        protected void GV_TransactionLisAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transactionId = GV_TransactionListAdmin.SelectedRow.Cells[1].Text;
            string userId = GV_TransactionListAdmin.SelectedRow.Cells[2].Text;
            string url = string.Format("~/View/TransactionDetailPage.aspx?transactionId={0}&userId={1}", transactionId, userId);
            Response.Redirect(url);
        }
    }
}