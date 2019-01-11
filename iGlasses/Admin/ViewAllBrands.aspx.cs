using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewAllBrands : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddBrand_Click(object sender, EventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string query = "INSERT INTO Brand (Brand) VALUES ('" + NewBrand.Text + " ')";
        SqlCommand sqlcomm = new SqlCommand(query, sqlCon);
        sqlCon.Open();
        sqlcomm.ExecuteNonQuery();
        sqlCon.Close();
        NewBrand.Text = "";
        NewBrandImage.Text = "";

    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Choice.aspx");
    }
}