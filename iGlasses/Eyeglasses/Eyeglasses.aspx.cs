using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Eyeglasses : System.Web.UI.Page
{
    string up;
    string low;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
        low = ((Label)FormView1.FindControl("lower_tb")).Text;
        up = ((Label)FormView1.FindControl("upper_tb")).Text;
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string query = "SELECT p.* , b.*  FROM Product p join[Brand] b on p.Brand = b.id where p.Type = 1 ";
        string query1 = "select min(Price) as min, max(Price) as max from Product";
        string condition = string.Empty;
        using (SqlConnection con1 = new SqlConnection(constr))
        {
            using (SqlCommand cmd1 = new SqlCommand(query1))
            {
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    cmd1.Connection = con1;

                    using (DataTable dt1 = new DataTable())
                    {
                        sda1.Fill(dt1);
                        FormView1.DataSource = dt1;
                        FormView1.DataBind();
                    }
                }
            }
        }
        foreach (ListItem item in CheckBoxList1.Items)
        {
            condition += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
        }
        
        if (!string.IsNullOrEmpty(condition))
        {
            condition = string.Format(" and b.id IN ({0}) and Price BETWEEN {1} AND {2};", condition.Substring(0, condition.Length - 1), low, up);
        }

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query + condition))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.Connection = con;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }
        
    }
    protected void Country_Selected(object sender, EventArgs e)
    {
        this.BindGrid();
    }
}