using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddToCart_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ShoppingCart shoppingCart = ShoppingCart.Instance();
        shoppingCart.ProductIds.Add(int.Parse( btn.CommandArgument.ToString()));
        Response.Redirect("Eyeglasses/Eyeglasses.aspx");
    }

}