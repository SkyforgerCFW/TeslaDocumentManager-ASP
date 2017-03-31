using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TeslaDocumentManager
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (UserLogIn.UserLogInCheck(this.Request))
                {
                    error_message.Visible = false;
                    UserLogIn user = UserLogIn.UserLoggedIn(this.Request);
                    if (user.AccessLevel == 1)
                    {
                        //admin-moderator-user
                        Response.Redirect("~/AdminPage.aspx");//nece?
                        return;
                    }
                    error_message.Text = "Podaci za prijavu nisu tačni!";
                    error_message.ForeColor = System.Drawing.Color.Red;
                    error_message.Visible = true;
                }
            }             
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            error_message.Visible = false;
            //string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(tbx_pass.Text, "SHA1");
            if (UserLogIn.LogInUser(Response, tbx_username.Text, tbx_pass.Text))
            {
                switch (Convert.ToInt32(Request.Cookies["AccessLevel"].Value))
                {
                    case 1 :
                            {
                            Response.Redirect("~/AdminPage.aspx");
                            break;
                        }
                    case 2:
                        {
                            Response.Redirect("~/AdminPage.aspx");
                            break;
                        }
                    case 3:
                        {
                            Response.Redirect("~/UserPage.aspx");
                            break;
                        }
                }

                
                return;
            }

            error_message.Text = "Podaci za prijavu nisu tačni!";
            error_message.ForeColor = System.Drawing.Color.Red;
            error_message.Visible = true;
        }
    }
}