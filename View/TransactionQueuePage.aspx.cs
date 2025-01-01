using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class TransactionQueuePage : System.Web.UI.Page
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

                    if (userRole != "Admin")
                    {
                        Response.Redirect("~/View/OrderSupplementPage.aspx");
                    }
                    GV_TransactionList.DataSource = TransactionController.showTransactionQueue();
                    GV_TransactionList.AutoGenerateColumns = false;
                    GV_TransactionList.DataBind();
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void GV_TransactionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[e.Row.Cells.Count - 1].Text;

                Button Btn_Handle = (Button) e.Row.FindControl("Btn_Handle");
                Button Btn_Handled = (Button)e.Row.FindControl("Btn_Handled");

                if (status == "Unhandled")
                {
                    Btn_Handle.Visible = true;
                }
                else
                {
                    Btn_Handled.Visible = true;
                }
            }
        }

        protected void GV_TransactionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = GV_TransactionList.SelectedRow.Cells[4].Text;
            if (status != "Handled")
            {
                string transactionId = GV_TransactionList.SelectedRow.Cells[1].Text;
                TransactionController.validateHandleTransaction(transactionId);
                Response.Redirect("~/View/TransactionQueuePage.aspx");
            }
        }
    }
}