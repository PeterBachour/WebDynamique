using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_ViewAllUsers : System.Web.UI.Page
{
    DataTable dt;
    SqlDataAdapter sqlAdp;
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }

    public void Bind()
    {       
        DataSet ds = new DataSet();
        
        string query = "select UserName, roleid from Users";
        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        sqlAdp = new SqlDataAdapter(sqlCmd);
        sqlAdp.Fill(ds, "dtDept");

        if (Page.IsPostBack == false)
        {
            dt = new DataTable();
            dt = ds.Tables["dtDept"];
            ViewState["dt"] = dt;
        }

        else
            dt = (DataTable)ViewState["dt"];


        GridView1.DataSource = dt;
        GridView1.AutoGenerateColumns = true;
        GridView1.AutoGenerateSelectButton = true;
        GridView1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Users SET roleid = 'admin' WHERE UserName= '" +txtDname.Text+"'" ;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        dt.Rows[GridView1.SelectedIndex]["roleid"] = "admin";
        GridView1.DataBind();
        clearForm();
    }

    protected void clearForm()
    {
        txtDname.Text = "";
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDname.Text = dt.Rows[GridView1.SelectedIndex]["UserName"].ToString();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Users SET roleid = Null WHERE UserName= '" + txtDname.Text + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        dt.Rows[GridView1.SelectedIndex]["roleid"] = "";
        GridView1.DataBind();
        clearForm();
    }
}