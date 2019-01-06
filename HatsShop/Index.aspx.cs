using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
        {
        //Get a list odìf all products in DB
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();

        //Make sure products exist in database 
        if (products != null)
        {

            // Create a new panel with ann Imagebutton And 2 labels fot each Paoduct
            foreach (Product product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //Set childControls' proprieties
                imageButton.ImageUrl = "~/Image/Products/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.ID;


                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                lblPrice.Text = "$ " + product.Price;
                lblPrice.CssClass = "productPrice";

                //Add child controls to panel
                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br/>" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<b/>" });
                productPanel.Controls.Add(lblPrice);

                //add dynamic panels to static parent panel
                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
        {
            //no products found
            pnlProducts.Controls.Add(new Literal { Text = "No Productsfound!" });
           
               }
        

            }
        }

  