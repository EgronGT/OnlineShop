using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            HatsShop_DBEntities db = new HatsShop_DBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();
            return cart.DatePurchased + "was succesfully inserted";
        }
        catch (Exception e)
        {

            return "Error:" + e;
        }
    }
    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            HatsShop_DBEntities db = new HatsShop_DBEntities();

            //Fetch object from db
            Cart p = db.Carts.Find(id);

            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ProductID = cart.ProductID;

            db.SaveChanges();
            return cart.DatePurchased + "was succesfully updated";

        }
        catch (Exception e)
        {

            return "Error:" + e;
        }
    }
    public string UpdateCart(int id)
    {
        try
        {
            HatsShop_DBEntities db = new HatsShop_DBEntities();
            Cart cart = db.Carts.Find(id);

            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return cart.DatePurchased + "was succesfully deleted";
        }
        catch (Exception e)
        {

            return "Error:" + e;
        }
    }

 
    public List<Cart> GetOrdersInCart(string userId)
    {
        HatsShop_DBEntities db = new HatsShop_DBEntities();

         List<Cart> orders = (from x in db.Carts
                             where x.ClientID == userId && (x.IsInCart??false)
                              orderby x.DatePurchased
                              select x).ToList();
        return orders;
    }
    public int GetAmountOfOrders(string userId)
    {
        try
        {
            HatsShop_DBEntities db = new HatsShop_DBEntities();
            int amount = (from x in db.Carts
                          where x.ClientID == userId && (x.IsInCart ?? false)
                          select x.Amount??0).Sum();
            return amount;
        }
        catch
        {

            return 0;
        }
    }

    private static string GetClientID(Cart x)
    {
        return x.ClientID;
    }

    public void UpdateQuantity(int id, int quantity)
    {
        HatsShop_DBEntities db = new HatsShop_DBEntities();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;

        db.SaveChanges();
    }

    public void MarkOrdersAsPaid(List<Cart> carts)
    {
        HatsShop_DBEntities db = new HatsShop_DBEntities();
        if (carts != null)
        {
            foreach(Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.ID);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.IsInCart = false;

            }
            db.SaveChanges();
        }
    }

    public void DeleteCart(int cartId)
    {
        throw new NotImplementedException();
    }
}