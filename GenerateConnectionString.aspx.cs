using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateConnectionString : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EncryptButton_Click(object sender, EventArgs e)
    {
        DataProtectionSample encrypter = new DataProtectionSample();
        string encryptedCString = encrypter.EncryptString(ConnectionString.Text);

        EncryptedString.Text = encryptedCString;
        //Response.Write("<br />");
        //Response.Write(encryptedCString);
    }
}