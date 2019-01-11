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
    string query = "select p.Id, p.Name, b.Brand, t.Type, p.Price, p.Quantity, p.Image from Product p " +
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
        Nametxt.Text = dt.Rows[GridView1.SelectedIndex]["Name"].ToString();
        string brand = dt.Rows[GridView1.SelectedIndex]["Brand"].ToString();
        string type = dt.Rows[GridView1.SelectedIndex]["Type"].ToString();
        BrandDDL.ClearSelection();
        TypeDDL.ClearSelection();
        BrandDDL.Items.FindByText(brand).Selected = true;
        TypeDDL.Items.FindByText(type).Selected = true;
        Pricetxt.Text = dt.Rows[GridView1.SelectedIndex]["Price"].ToString();
        Quantitytxt.Text = dt.Rows[GridView1.SelectedIndex]["Quantity"].ToString();
        Imagetxt.Text = dt.Rows[GridView1.SelectedIndex]["Image"].ToString();
        btnAdd.Text = "Edit";
    }


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "Edit")
        {
            dt.Rows[GridView1.SelectedIndex]["Name"] = Nametxt.Text;
            dt.Rows[GridView1.SelectedIndex]["Brand"] = BrandDDL.SelectedItem.Text;// .DataTextField.Text;
            dt.Rows[GridView1.SelectedIndex]["Type"] = TypeDDL.SelectedItem.Text;
            dt.Rows[GridView1.SelectedIndex]["Price"] = Pricetxt.Text;
            dt.Rows[GridView1.SelectedIndex]["Quantity"] = Quantitytxt.Text;
            dt.Rows[GridView1.SelectedIndex]["Image"] = Imagetxt.Text;

            query = "update Product set Name='" + Nametxt.Text + "', Brand=" + BrandDDL.SelectedValue + ", Type=" +
                TypeDDL.SelectedValue + ", Price=" + Pricetxt.Text + ", Quantity="+ Quantitytxt.Text+ ", Image='"+
                Imagetxt.Text + "' where id=" + dt.Rows[GridView1.SelectedIndex]["Id"].ToString();
            SqlCommand sqlcomm = new SqlCommand(query, sqlCon);
            sqlCon.Open();
            sqlcomm.ExecuteNonQuery();
            sqlCon.Close();


        }
        else
        {
            DataRow row = dt.NewRow();
            row["Name"] = Nametxt.Text;
            row["Brand"] = BrandDDL.SelectedItem.Text;
            row["Type"] = TypeDDL.SelectedItem.Text;
            row["Price"] = Pricetxt.Text;
            row["Quantity"] = Quantitytxt.Text;
            row["Image"] = Imagetxt.Text;
            dt.Rows.Add(row);

            query = "INSERT INTO Product (Name,Brand,Type, Price,Quantity, Image) VALUES ('"
                + Nametxt.Text + "', " + BrandDDL.SelectedValue + ", " +
               TypeDDL.SelectedValue + "," + Pricetxt.Text + ", " + Quantitytxt.Text + ", '" +
               Imagetxt.Text + "')";
            SqlCommand sqlcomm = new SqlCommand(query, sqlCon);
            sqlCon.Open();
            sqlcomm.ExecuteNonQuery();
            sqlCon.Close();
        }

        GridView1.DataBind();
        clearForm();
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        dt.Rows[GridView1.SelectedIndex].Delete();
        query = "delete from Product where id=" + dt.Rows[GridView1.SelectedIndex]["Id"].ToString();
        SqlCommand sqlcomm = new SqlCommand(query, sqlCon);
        sqlCon.Open();
        sqlcomm.ExecuteNonQuery();
        sqlCon.Close();
        BrandDDL.DataBind();
        BrandDDL.AutoPostBack = true;
        clearForm();
        Response.Redirect("ViewAllProducts.aspx");
    }

    protected void clearForm()
    {
        Nametxt.Text = "";
        Pricetxt.Text = "";
        Quantitytxt.Text = "";
        Imagetxt.Text = "";
        btnAdd.Text = "Add";
    }



    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Choice.aspx");
    }
}
