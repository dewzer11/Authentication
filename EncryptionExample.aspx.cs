using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EncryptionExample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string secretString = "";
        DataProtectionSample Encryption = new DataProtectionSample();
        

            // Create a simple byte array containing data to be encrypted.

        byte[] secret = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

        //Encrypt the data.
        byte[] encryptedSecret = Encryption.Protect(secret);
        Response.Write("The encrypted byte array is:");
        Encryption.PrintValues(encryptedSecret);

        // Decrypt the data and store in a byte array.
        byte[] originalData = Encryption.Unprotect(encryptedSecret);
        Response.Write("The original data is:");
        Encryption.PrintValues(originalData);
    }
}