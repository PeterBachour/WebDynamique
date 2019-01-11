using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    ShoppingCart shoppingCart = ShoppingCart.Instance();// ShoppingCart();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string query = "SELECT * FROM Product where";
        query += " id in ( " + shoppingCart.ListProducts() + ")";// prod);
        using (SqlConnection con1 = new SqlConnection(constr))
        {
            using (SqlCommand cmd1 = new SqlCommand(query))
            {
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    cmd1.Connection = con1;

                    using (DataTable dt1 = new DataTable())
                    {
                        sda1.Fill(dt1);
                        Repeater1.DataSource = dt1;
                        Repeater1.DataBind();
                    }
                }
            }
        }
    }
}