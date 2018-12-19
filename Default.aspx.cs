using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Text;
using System.Security.Principal;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = "Hello, " + Context.User.Identity.Name;


        CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;
        Response.Write("Authenticated Identity is: " +
                        cp.Identity.Name);
        Response.Write("<p>");

        if (cp.IsInRole("user"))
        {
            Response.Write(cp.Identity.Name + " is in the user Role" );
          
            Response.Write("<p>");
        }
        if (cp.IsInRole("Admin"))
        {
            Response.Write(cp.Identity.Name + " is in the Admin Role");

            Response.Write("<p>");
        }
    }




    public void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();

        // clear and abandon session
        Session.Clear();
        Session.Abandon();

        Response.Redirect("Logon.aspx");
    }
}