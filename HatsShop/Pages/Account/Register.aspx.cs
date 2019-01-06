using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();


            userStore.Context.Database.Connection.ConnectionString = 
            System.Configuration.ConfigurationManager.
            ConnectionStrings["HatsShop_DBConnectionString"].ConnectionString;


        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        // Create new user and try tp store in DB.

        IdentityUser user = new IdentityUser();
        user.UserName = txtUserName.Text;

        if (txtPassword.Text == txtConfirmPassword.Text)
        {
            try
            {
                //Create user object
                //Database will be created / expanded
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    UserInformation info = new UserInformation 
                    {
                        Address = txtAddress.Text,
                        FirstName = txtFirstName.Text,
                        LastName =txtLastName.Text,
                        PostalCode = string.IsNullOrEmpty(txtPostalCode.Text) ? 0 : Convert.ToInt32(txtPostalCode.Text),
                        DUID = user.Id
                    };
                    UserInfoModel model = new UserInfoModel();
                    model.InsertUserInformation(info);
                    //Store user in DB
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                    // Set to long in new user cookie
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);


                    // log in the new user and redirect to homepage
                    authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");

                }
                else
                {
                    litStatus.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                litStatus.Text = ex.ToString();
            }
        }
        else
        {
            litStatus.Text = "Paswords must match";
        }
    }
}

 