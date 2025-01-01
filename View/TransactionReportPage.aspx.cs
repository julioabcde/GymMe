using GymMe.Controller;
using GymMe.DataSet;
using GymMe.Model;
using GymMe.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class TransactionReportPage : System.Web.UI.Page
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
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
            TransactionReport transactionReport = new TransactionReport();
            GymMeDataSet gymMeDataSet = TransactionController.showDataSet();
            transactionReport.SetDataSource(gymMeDataSet);
            CRV_Transaction.ReportSource = transactionReport;
        }
    }
}