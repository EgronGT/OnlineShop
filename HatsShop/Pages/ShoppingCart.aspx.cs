﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Pages_ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Get Id of current logger in user and display items
        string userId = User.Identity.GetUserId();
        GetPurchasesInCart(userId);
    }

    private void GetPurchasesInCart(string userId)
    {
        CartModel model = new CartModel();
        double subTotal = 0;

        // Generate html for each element in purchaseList
        List<Cart> purchaseList = model.GetOrdersInCart(userId);
         CreateShopTable(purchaseList, out subTotal);

        //Add totals to webpage
        double hat = subTotal * 0.21;
        double totalAmount = subTotal + hat + 15;


        //Display values on page
        litTotal.Text = "$ " + subTotal;
        litType.Text = "$ " + hat;
        litTotalAmount.Text = " " + totalAmount;

    }

    private void CreateShopTable(List<Cart> purchaseList, out double subTotal)
    {
        subTotal = new Double();
        ProductModel model = new ProductModel();


        foreach (Cart cart in purchaseList)
        {
            Product product = model.GetProduct(cart.ProductID);

            //Create the image button
            ImageButton bntImage = new ImageButton
            {
                ImageUrl = string.Format("~/Images/Products/{0}", product.Image),
                PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID)
            };

            //Create the delete link
            LinkButton linkDelete = new LinkButton
            {
                 PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId={0}", cart.ID),
                Text = "Delete Item",
                ID = "del" + cart.ID
            };

             
            //EventHandler Delete_Item = null;
            //Add an OnClick event
            linkDelete.Click += Delete_Item;

            //Create the "Quantity dropdownlist
            //Generate list with numbers from 1 to 20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            DropDownList ddlAmount = new DropDownList
            {
                DataSource = amount,
                AppendDataBoundItems = true,
                AutoPostBack = true,
                ID = cart.ID.ToString()
            };
            ddlAmount.DataBind();
            ddlAmount.SelectedValue = cart.Amount.ToString();
            ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

            //Create html table with 2 rows
            Table table = new Table { CssClass = "cartTable" };
            TableRow a = new TableRow();
            TableRow b = new TableRow();

            //Cells row a
            TableCell a1 = new TableCell {RowSpan = 2, Width= 50 };
            TableCell a2 = new TableCell
            {
                Text = string.Format("<h4>{0}</h4><br/>{1}<br/>In Stock",
                product.Name, "Item No: " + product.ID),
                HorizontalAlign = HorizontalAlign.Left,
                Width = 350 };
            TableCell a3 = new TableCell {Text ="Unit Price<hr/>" };
            TableCell a4 = new TableCell {Text = "Quantity<hr/>" };
            TableCell a5 = new TableCell {Text="Item Total<hr/>" };
            TableCell a6 = new TableCell { };

            //Cells row b
            TableCell b1 = new TableCell { };
            TableCell b2 = new TableCell { Text ="$ " + product.Price};
            TableCell b3 = new TableCell { };
            var total = cart.Amount * product.Price;
            double totaldbl = double.Parse(total.ToString());
            TableCell b4 = new TableCell { Text = "$ " + Math.Round (totaldbl, 2)};
            TableCell b5 = new TableCell { };
            TableCell b6 = new TableCell { };

            Control btnImage = null;
            //Set 'special' controls
            a1.Controls.Add(btnImage);
            a6.Controls.Add(ddlAmount);
            b3.Controls.Add(ddlAmount);

            //Add Cels to rows
            a.Cells.Add(a1);
            a.Cells.Add(a2);
            a.Cells.Add(a3);
            a.Cells.Add(a4);
            a.Cells.Add(a5);
            a.Cells.Add(a6);

             b.Cells.Add(b1);
            b.Cells.Add(b2);
            b.Cells.Add(b3);
            b.Cells.Add(b4);
            b.Cells.Add(b5);
            b.Cells.Add(b6);

            //Add rows to table
            table.Rows.Add(a);
            table.Rows.Add(b);

            //Add table to onlPshopingCart
            pnlShoppingCart.Controls.Add(table);

            //Add total amount of item in cart ro subtotal
            var totalint = cart.Amount * product.Price;

            subTotal += double.Parse(totalint.ToString());
        }

        //Add current user's shpping cart to user specific session value
        Session[User.Identity.GetUserId()] = purchaseList;

    }

  

    private void Delete_Item(object sender, EventArgs e)
    {
        LinkButton selectedLink = (LinkButton)sender;
        string link= selectedLink.ID.Replace("del", "");
        int cartId = Convert.ToInt32(link);

        CartModel model = new CartModel();
        model.DeleteCart(cartId);

        Response.Redirect("~/Pages(ShoppingCart.aspx");

    }

    private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList selectedList = (DropDownList)sender;
        int quantity = Convert.ToInt32(selectedList.SelectedValue);
        int cartId = Convert.ToInt32(selectedList.ID);

        CartModel model = new CartModel();
        model.UpdateQuantity(cartId, quantity);

        Response.Redirect("~/Pages(ShoppingCart.aspx");
    }
}

    
 