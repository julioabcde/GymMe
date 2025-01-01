using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class OrderSupplementPage : System.Web.UI.Page
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

                    if (userRole != "Customer")
                    {
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                    GV_SupplementDetailList.DataSource = SupplementController.showAllSupplementsDetails();
                    GV_SupplementDetailList.AutoGenerateColumns = false;
                    GV_SupplementDetailList.DataBind();

                    GV_CartList.DataSource = CartController.showCartDetailsByUserId(userId);
                    GV_CartList.AutoGenerateColumns = false;
                    GV_CartList.DataBind();

                    if (GV_CartList.Rows.Count == 0)
                    {
                        Btn_Checkout.Visible= false;
                        Btn_Clear.Visible= false;
                    }
                    else
                    {
                        Btn_Checkout.Visible = true;
                        Btn_Clear.Visible = true;
                    }
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void GV_SupplementDetailList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
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

                // get the control that triggered the event
                Control sourceControl = e.CommandSource as Control;
                // get the GridViewRow containing the control that triggered the event
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                // get the row index
                int idx = row.RowIndex;

                string supplementName = GV_SupplementDetailList.Rows[idx].Cells[1].Text;
                TextBox TBox_Quantity = (TextBox)GV_SupplementDetailList.Rows[idx].FindControl("TBox_Quantity");
                string quantity = TBox_Quantity.Text;
                
                Lbl_Status.Text = CartController.validateOrder(userId, supplementName, quantity);
                if (Lbl_Status.Text == "New cart has been added successfully!" || Lbl_Status.Text == "Cart has been updated successfully!")
                {
                    Response.Redirect("~/View/OrderSupplementPage.aspx");
                }
                else
                {
                    Lbl_Status.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
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
            CartController.clearCarts(userId);
            Response.Redirect("~/View/OrderSupplementPage.aspx");
        }

        protected void Btn_Checkout_Click(object sender, EventArgs e)
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
            CartController.validateCheckOut(userId);
            Response.Redirect("~/View/HistoryPage.aspx");
        }
    }
}