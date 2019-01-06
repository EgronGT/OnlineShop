using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientId = Context.User.Identity.GetUserId();

            if (clientId != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);
                Cart cart = new Cart
                {
                    Amount = amount,
                    ClientID = clientId,
                    DatePurchased = DateTime.Now,
                    IsInCart = true,
                    ProductID = id
                };
                CartModel model = new CartModel();
                lblResult.Text = model.InsertCart(cart);
            }
            else
            {
                lblResult.Text = "Please login to order items";
            }
        }
    }
    private void FillPage()
    {
        //Get selected products data
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"])) ;
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel productModel = new ProductModel();
            Product product = productModel.GetProduct(id);

            //fill page with data
            lblPrice.Text = "Price per unit: <br/>$ " + product.Price;
            lblTitle.Text = product.Name;
            lblDescription.Text = product.Description;
            lblItemNR.Text = id.ToString();
            imgProduct.ImageUrl = "~/Image/Products/" + product.Image;

            //Fill Amount dropdownlist with nuber 1 -20

            int[] amount = Enumerable.Range(1, 20).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();
        }
    }

     
}