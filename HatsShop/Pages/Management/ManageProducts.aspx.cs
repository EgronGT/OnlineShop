using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
     }
}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductModel productModel = new ProductModel();
        Product product = CreateProduct();

        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResult.Text = productModel.UpdateProduct(id, product);
        }
        else
        {
            lblResult.Text = productModel.InsertProduct(product);

        }

    }


    private void FillPage(int id)
    {
        ProductModel productModel = new ProductModel();
        Product product = productModel.GetProduct(id);

        txtDescription.Text = product.Description;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        ddlImage.SelectedValue = product.Image;
        ddlImage.SelectedValue = product.TypeID.ToString();

    }
    
    private void GetImages()
    {
        try
        {
            //Get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Image/Products/ "));

            
            //get all filenames and add them to an array list

            ArrayList imageList = new ArrayList();
          

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }
            //Set the ArrayList as dropDownView's datasource and refresh

            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();
        }
        catch(Exception e)
        {
            lblResult.Text = e.ToString();
        }
    }
    private Product CreateProduct()
    {

Product product = new Product();

        product.Name = txtName.Text;
        // product.Price = Convert.ToDouble(txtPrice.Text);
       // product.Price = Convert.ToDouble(txtPrice.Text);
        
        product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddlImage.SelectedValue;

        return product;
        
    }



    
}


        
    
