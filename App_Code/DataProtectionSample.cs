using System;
using System.Collections.Generic;
using System.Web;

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for DataProtectionSample
/// </summary>
public class DataProtectionSample
{
    // Create byte array for additional entropy when using Protect method.
    static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

    public string EncryptString(string data)
    {
        byte[] binary = Encoding.ASCII.GetBytes(data);
        string encryptedString = Convert.ToBase64String(Protect(binary));
        return encryptedString;
    }

    public string DecryptString(string data)
    {
        string encryptedString = data;
        byte[] encryptedArray = Convert.FromBase64String(encryptedString);
        byte[] unencryptedArray = Unprotect(encryptedArray);
        string unencryptedString = Encoding.ASCII.GetString(unencryptedArray);
        return unencryptedString;
    }

    public byte[] Protect(byte[] data)
    {
        try
        {
            // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
            //  only by the same current user.
            return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Data was not encrypted. An error occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
    }

    public byte[] Unprotect(byte[] data)
    {
        try
        {
            byte[] test;//Decrypt the data using DataProtectionScope.CurrentUser.
            test = ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            return test; //ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Data was not decrypted. An error occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
    }

    public void PrintValues(Byte[] myArr)
    {
        foreach (Byte i in myArr)
        {
            Console.Write("\t{0}", i);
        }
        Console.WriteLine();
    }
}