using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_ViewAllProducts : System.Web.UI.Page
{

    DataTable dt;
    SqlDataAdapter sqlAdp;
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string query = "select p.Name, b.Brand, t.Type, p.Price, p.Quantity, p.Image from Product p " +
        "join Brand b on p.Brand = b.Id " +
        "join Type t on p.Type = t.Id ";

    protected void Page_Load(object sender, EventArgs e)
    {       
        Bind();
    }

    public void Bind()
    {
        DataSet ds = new DataSet();

        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlAdp = new SqlDataAdapter(sqlCmd);
        sqlAdp.Fill(ds, "dtProducts");

        if (Page.IsPostBack == false)
        {
            dt = new DataTable();
            dt = ds.Tables["dtProducts"];
            ViewState["dt"] = dt;
        }

        else
            dt = (DataTable)ViewState["dt"];



        GridView1.DataSource = dt;
        GridView1.AutoGenerateColumns = true;
        GridView1.AutoGenerateSelectButton = true;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }



}
