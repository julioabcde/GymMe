using GymMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
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
                    TBox_Id.Text = Request.QueryString["supplementId"];
                    TBox_Name.Text = SupplementController.showSupplementName(TBox_Id.Text);
                    TBox_ExpiryDate.Text = SupplementController.showSupplementExpiryDate(TBox_Id.Text);
                    TBox_Price.Text = SupplementController.showSupplementPrice(TBox_Id.Text);
                    TBox_TypeId.Text = Request.QueryString["typeId"];
                    TBox_TypeName.Text = SupplementController.showSupplementTypeName(TBox_TypeId.Text);
                }
                else if (Session["user"] == null && Request.Cookies["userCookie"] == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }

        protected void IB_ExpiryDate_Click(object sender, ImageClickEventArgs e)
        {
            if (Cld_ExpiryDate.Visible == false)
            {
                Cld_ExpiryDate.Visible = true;
            }
            else if (Cld_ExpiryDate.Visible == true)
            {
                Cld_ExpiryDate.Visible = false;
            }
        }

        protected void Btn_Choose_Click(object sender, EventArgs e)
        {
            if (Cld_ExpiryDate.SelectedDate == DateTime.MinValue)
            {
                TBox_ExpiryDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                TBox_ExpiryDate.Text = Cld_ExpiryDate.SelectedDate.ToString("dd-MM-yyyy");
            }
        }

        protected void Btn_Load_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TBox_TypeId.Text))
            {
                TBox_TypeId.Text = "1";
            }
            TBox_TypeName.Text = SupplementController.showSupplementTypeName(TBox_TypeId.Text);
            if (TBox_TypeName.Text != "Not available!")
            {
                TBox_TypeName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                TBox_TypeName.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            string id = TBox_Id.Text;
            string newName = TBox_Name.Text;
            string newExpiryDate = TBox_ExpiryDate.Text;
            string newPrice = TBox_Price.Text;
            string newTypeId = TBox_TypeId.Text;
            string newTypeName = TBox_TypeName.Text;

            Lbl_Status.Text = SupplementController.validateUpdateSupplement(id, newName, newExpiryDate, newPrice, newTypeId, newTypeName);
            if (Lbl_Status.Text == "Supplement has been updated successfully!")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageSupplementPage.aspx");
        }
    }
}