using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class Logon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Logon_Click(object sender, EventArgs e)
    {
        
        User CurrentUser = SecurityManager.GetUser(UserEmail.Text);

        string check = SecurityManager.CreatePasswordHash(UserPass.Text, CurrentUser.Salt);

        if (check == CurrentUser.Password)
        {
            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
            string roles = CurrentUser.Role;
            //generate and encrypt an authentication ticket
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, CurrentUser.Email, DateTime.Now, DateTime.Now.AddMinutes(60), false, roles);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Response.Redirect(FormsAuthentication.GetRedirectUrl(CurrentUser.Email, false));

            
        }
        else
        {
            Msg.Text = "Invalid credentials. Please try again";
        }



    }

} 
//((CurrentUser != null) &&