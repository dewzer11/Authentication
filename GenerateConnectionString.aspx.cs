using System;
using System.Collections.Generic;
using System.Text;
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
        //DataProtectionSample encrypter = new DataProtectionSample();
        //string encryptedCString = encrypter.EncryptString(ConnectionString.Text);


        byte[] binary = Encoding.ASCII.GetBytes(ConnectionString.Text);
        string encryptedString = Convert.ToBase64String(binary);

        EncryptedString.Text = encryptedString;

        byte[] connStrArray = Convert.FromBase64String(encryptedString);
        string unencryptedString = Encoding.ASCII.GetString(connStrArray);

        DecryptedString.Text = unencryptedString;
        //string decryptedCString = encrypter.DecryptString(ConnectionString.Text);
        //DecryptedString.Text = decryptedCString;
    }
}