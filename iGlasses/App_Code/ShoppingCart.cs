using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ShoppingCart
{
    private static ShoppingCart instance;

    private ShoppingCart() {
        ProductIds = new List<int>();
    }

    public static ShoppingCart Instance()
    {
        if (instance == null)
        {
            instance = new ShoppingCart();
        }
        return instance;
    }

    public List<int> ProductIds;
    public string ListProducts()
    {
        string x = "";
        for(int i =0; i< ProductIds.Count; i++)
        {
            if (i != ProductIds.Count - 1)
                x += ProductIds[i] + ", ";
            else
                x += ProductIds[i];
        }
        return  x;
    }
}