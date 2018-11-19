using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = "Hello, " + Context.User.Identity.Name;


        
        string connStr = ConfigurationManager.ConnectionStrings["BAIS3110Security"].ConnectionString;
        ConnectionString.Text = connStr;
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