using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XEx04Quotation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            String discountAmount = (String)Session["discountAmount"];
            String salesPrice = (String)Session["salesPrice"];
            String totalPrice = (String)Session["totalPrice"];
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                decimal salesPrice = Convert.ToDecimal(txtSalesPrice.Text);
                decimal discountPercent = Convert.ToDecimal(txtDiscountPercent.Text) / 100;

                decimal discountAmount = salesPrice * discountPercent;
                decimal totalPrice = salesPrice - discountAmount;

                lblDiscountAmount.Text = discountAmount.ToString("c");
                lblTotalPrice.Text = totalPrice.ToString("c");

                Session.Add("discountAmount", discountAmount.ToString("c"));
                Session.Add("salesPrice", salesPrice.ToString("c"));
                Session.Add("totalPrice", totalPrice.ToString("c"));
            }   
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["salesPrice"] == null)
            {
                lblMessage.Text = "Click the Calculate button before you confirm.";
            }
            else
            {
                Response.Redirect("Confirm.aspx");
            }
           
        }
    }
}