using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class Login_Login : System.Web.UI.Page
{
    SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string Username1;
    string pwd;

    protected void Page_Load(object sender, EventArgs e)
    {
        Username1 = ((TextBox)Login1.FindControl("UserName")).Text;
        pwd = ((TextBox)Login1.FindControl("Password")).Text; 
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        string check = "select count(*) from Users where UserName = '" + Username1 + "' and PasswordHash = '" + Encrypt(pwd) + "'";
        string roles = "select roleid from Users where UserName = '" + Username1 + "' and PasswordHash = '" + Encrypt(pwd) + "'";
        SqlCommand com = new SqlCommand(check, sqlCon);
        SqlCommand comm = new SqlCommand(roles, sqlCon);
        sqlCon.Open();
        string role = comm.ExecuteScalar().ToString();
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        sqlCon.Close();
        if (temp == 1)
        {
            int result = string.Compare(role, "admin");
            if (result == 0)
            {
                Response.Redirect("../Admin/Choice.aspx");
            }
            else
            { 
            Session["HomePage"] = Username1;
            Response.Redirect("../HomePage/HomePage.aspx");
            }
        }
        else
        {
            Response.Redirect("../Register/Register.aspx");
            ((Literal)Login1.FindControl("FailureText")).EnableViewState=true;

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