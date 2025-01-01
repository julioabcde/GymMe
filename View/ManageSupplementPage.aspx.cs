using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GymMe.View
{
    public partial class ManageSupplementPage : System.Web.UI.Page
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
                    GV_SupplementList.DataSource = SupplementController.showAllSupplements();
                    GV_SupplementList.AutoGenerateColumns = false;
                    GV_SupplementList.DataBind();
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void GV_SupplementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string supplementId = GV_SupplementList.SelectedRow.Cells[1].Text;
            string typeID = GV_SupplementList.SelectedRow.Cells[5].Text;
            string url = string.Format("~/View/UpdateSupplementPage.aspx?supplementId={0}&typeId={1}", supplementId, typeID);
            Response.Redirect(url);
        }

        protected void GV_SupplementList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GV_SupplementList.Rows[e.RowIndex].Cells[1].Text;
            Lbl_Status.Text = SupplementController.validateDeleteSupplement(id);
            if (Lbl_Status.Text == "Supplement has been deleted successfully!")
            {
                Response.Redirect("~/View/ManageSupplementPage.aspx");
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertSupplementPage.aspx");
        }
    }
}