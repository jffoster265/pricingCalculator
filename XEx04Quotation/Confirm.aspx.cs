using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XEx04Quotation
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["salesPrice"] == null)
            {
                lblDiscountAmount.Text = null;
                lblSalesPrice.Text = null;
                lblTotalPrice.Text = null;
            }
            else
            {
                String discountAmount = (String)Session["discountAmount"];
                String salesPrice = (String)Session["salesPrice"];
                String totalPrice = (String)Session["totalPrice"];


                lblDiscountAmount.Text = discountAmount;
                lblSalesPrice.Text = salesPrice;
                lblTotalPrice.Text = totalPrice;

            }

           

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "" || txtName.Text == "")
            Response.Redirect("Default.aspx");
        }

        protected void btnQuotation_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                String email = txtEmail.Text;
                String name = txtName.Text;

                lblMessage.Text = "Quotation sent to " + name + " at " + email + ".";
                Session.Remove("txtEmail");
                Session.Remove(name);

            }
            

        }
    }
}