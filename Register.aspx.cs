using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Register_Click(object sender, EventArgs e)
    {
        bool Confirmation = false;

        SecurityManager UserAdder = new SecurityManager();
        string salt = SecurityManager.CreateSalt();
        string password = SecurityManager.CreatePasswordHash(UserPass.Text, salt);

        Confirmation = SecurityManager.AddUser(UserEmail.Text, password, salt);


        if (Confirmation)
        {
            Response.Write("The User was added successfully!");
        }
        else
        {
            Response.Write("Sorry the user was not added.");
        }


    }

}