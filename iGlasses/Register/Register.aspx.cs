using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class Login_Login : System.Web.UI.Page
{
    SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    string Username1;
    string Email1;
    string pwd;
    string pwdcheck;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username1 = Username.Text;
        Email1 = Email.Text;
        pwd = Password.Value;
        pwdcheck = checkPassword.Value;
        Username.Text = "";
        Email.Text = "";
    }
    private static string getHash(string text)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    protected void SignUp_Click(object sender, EventArgs e)
    {
        try
        {
            int res = string.Compare(pwd, pwdcheck);
            if (res == 0)
            {
                string insertSql = "Insert into Users (UserName, Email, PasswordHash) values ('" + Username1 +
                    "', '" + Email1 + "', '" + Encrypt(pwd) + "')";
                SqlCommand com = new SqlCommand(insertSql, sqlCon);
                sqlCon.Open();
                com.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../Login/Login.aspx");
            }
            else
                Response.Write("passwords do not match");
        }
        catch
        {
            Response.Write("username already exists");
        }
    }

    public static string Encrypt(string strData)
    {
        return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
    }
    public static string Decrypt(string strData)
    {
        return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
    }
    public static byte[] Encrypt(byte[] strData)
    {
        PasswordDeriveBytes passbytes =
        new PasswordDeriveBytes(Global.strPermutation,
        new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
        });

        MemoryStream memstream = new MemoryStream();
        Aes aes = new AesManaged();
        aes.Key = passbytes.GetBytes(aes.KeySize / 8);
        aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

        CryptoStream cryptostream = new CryptoStream(memstream,
        aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptostream.Write(strData, 0, strData.Length);
        cryptostream.Close();
        return memstream.ToArray();
    }
    public static byte[] Decrypt(byte[] strData)
    {
        PasswordDeriveBytes passbytes =
        new PasswordDeriveBytes(Global.strPermutation,
        new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
        });

        System.IO.MemoryStream memstream = new MemoryStream();
        Aes aes = new AesManaged();
        aes.Key = passbytes.GetBytes(aes.KeySize / 8);
        aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

        CryptoStream cryptostream = new CryptoStream(memstream,
        aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptostream.Write(strData, 0, strData.Length);
        cryptostream.Close();
        return memstream.ToArray();
    }
    public static class Global
    {
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
    }
}