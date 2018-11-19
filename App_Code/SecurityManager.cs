using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Security.Cryptography;
/// <summary>
/// Summary description for SecurityManager
/// </summary>
public class SecurityManager
{
    public static string CreateSalt()
    {
        // Generate a cryptographic random number using the cryptographic
        // service provider
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[8];
        rng.GetBytes(buff);
        // Return a Base64 string representation of the random number
        return System.Text.Encoding.ASCII.GetString(buff);
    }

    public static string CreatePasswordHash(string pwd,string salt)
    {
        ////Hash password
        //byte[] data = System.Text.Encoding.ASCII.GetBytes(pwd);
        //data = new SHA256Managed().ComputeHash(data);
        //string hashedPassword = System.Text.Encoding.ASCII.GetString(data);

        //return hashedPassword;
        Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(pwd, System.Text.Encoding.ASCII.GetBytes(salt), 1000);
        return System.Text.Encoding.ASCII.GetString(rfc2898.GetBytes(20));
    }



    public static bool AddUser(string email, string password, string salt)
    {
        //variable to return whether a user was found or not.
        bool confirmation = false;
        //SQL Connection object (ADO.NET) to connect to database
        SqlConnection BAIS3110Security = new SqlConnection();
        BAIS3110Security.ConnectionString = "Persist Security Info=False;Integrated Security=True;Database=BAIS3110Security;server=(localdb)\\MSSQLLocalDB;";
        BAIS3110Security.Open();


        SqlCommand AddCommand = new SqlCommand();
        AddCommand.Connection = BAIS3110Security;
        AddCommand.CommandType = CommandType.StoredProcedure;
        AddCommand.CommandText = "AddUser";

        SqlParameter AddCommandParameter = new SqlParameter();
        AddCommandParameter.ParameterName = "@Email";
        AddCommandParameter.SqlDbType = SqlDbType.VarChar;
        AddCommandParameter.Direction = ParameterDirection.Input;
        AddCommandParameter.SqlValue = email;
        AddCommand.Parameters.Add(AddCommandParameter);

        SqlParameter AddCommandParameter2 = new SqlParameter();
        AddCommandParameter2.ParameterName = "@Password";
        AddCommandParameter2.SqlDbType = SqlDbType.VarChar;
        AddCommandParameter2.Direction = ParameterDirection.Input;
        AddCommandParameter2.SqlValue = password;
        AddCommand.Parameters.Add(AddCommandParameter2);

        SqlParameter AddCommandParameter3 = new SqlParameter();
        AddCommandParameter3.ParameterName = "@Salt";
        AddCommandParameter3.SqlDbType = SqlDbType.VarChar;
        AddCommandParameter3.Direction = ParameterDirection.Input;
        AddCommandParameter3.SqlValue = salt;
        AddCommand.Parameters.Add(AddCommandParameter3);

        AddCommand.ExecuteNonQuery();
        BAIS3110Security.Close();

        confirmation = true;

        return confirmation;
    }

    public static User GetUser(string email)
    {

        SqlConnection BAIS3110Security = new SqlConnection();
        BAIS3110Security.ConnectionString = "Persist Security Info=False;Integrated Security=True;Database=BAIS3110Security;server=(localdb)\\MSSQLLocalDB;";
        BAIS3110Security.Open();


        SqlCommand GetCommand = new SqlCommand();
        GetCommand.Connection = BAIS3110Security;
        GetCommand.CommandType = CommandType.StoredProcedure;
        GetCommand.CommandText = "GetUser";

        SqlParameter GetCommandParameter = new SqlParameter();
        GetCommandParameter.ParameterName = "@Email";
        GetCommandParameter.SqlDbType = SqlDbType.VarChar;
        GetCommandParameter.Direction = ParameterDirection.Input;
        GetCommandParameter.SqlValue = email;
        GetCommand.Parameters.Add(GetCommandParameter);


        SqlDataReader GetUserDataReader = GetCommand.ExecuteReader();

        User member = new User();
        if (GetUserDataReader.HasRows)
        {
            while (GetUserDataReader.Read())
            {
                member.Email = GetUserDataReader[0].ToString();
                member.Password = GetUserDataReader[1].ToString();
                member.Salt = GetUserDataReader[2].ToString();
            }
        }

        BAIS3110Security.Close();

        return member;
    }
}