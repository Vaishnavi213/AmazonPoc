using Microsoft.EntityFrameworkCore;
using Poc.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poc.Web.DAL
{
    public class myCart
    {
        AmazonDbContext db = new AmazonDbContext();

        public Boolean AddCart(Cart model)
        {
            var availableStock = db.Products.Where(x => x.ProductId == model.Product_Id).FirstOrDefault();
            int StockInHand = availableStock.Quantity;
            if (StockInHand > model.Quantity)
            {
                var Authorize = db.Carts.Where(x => x.CustomerId == model.CustomerId && x.Product_Id == model.Product_Id).FirstOrDefault();
                if (Authorize == null)
                {
                    db.Carts.Add(model);
                    db.SaveChanges();
                    var query = db.Carts.Where(x => x.CartId == model.CartId).FirstOrDefault();
                    var query1 = db.Products.Where(p => p.ProductId == model.Product_Id).FirstOrDefault();
                    decimal price = query1.Price;
                    query.Price = price;
                    var query4 = from c in db.Carts where c.CustomerId == model.CustomerId select c;
                    query.Product_Image = query1.Image;
                    query.Total = (query.Quantity * price);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    Authorize.Quantity = Authorize.Quantity + model.Quantity;
                    Authorize.Total = Authorize.Total + (model.Quantity * Authorize.Price);
                    db.Carts.Update(Authorize);
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        public decimal Total(Cart model)
        {
            decimal total = 0;
            var query = from q in db.Carts where q.CustomerId == model.CustomerId select q;
            foreach (var u in query)
            {
                total = total + u.Total;
            }
            return total;
        }

        //public bool RemoveFromCart(Cart model)
        //{
        //    var Authorize = db.Carts.Where(x => x.Product_Id == model.Product_Id && x.CustomerId == model.CustomerId).FirstOrDefault();
        //    if (Authorize.Quantity == 1)
        //    {
        //        db.Entry(Authorize).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    else if (Authorize.Quantity > 1)
        //    {
        //        Authorize.Quantity = Authorize.Quantity - model.Quantity;
        //        Authorize.Total = Authorize.Total - (model.Quantity * Authorize.Price);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public Product GetProduct(int id)
        //{
        //    return db.Products.Find(id);
        //}

        //public bool RemoveFromCart(int id)
        //{
        //    Product product = GetProduct(id);
        //    db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //    db.SaveChanges();
        //    return true;
        //}

        public bool RemoveFromCart(int cartid)
        {
            var del = db.Carts.Where(k => k.CartId == cartid).FirstOrDefault();

            if (del == null)
            {
                return false;
            }

            db.Carts.Remove(del);
            db.SaveChanges();

            return true;
        }
        public IEnumerable<Cart> GetCartValue(Cart model)
        {
            var query = from c in db.Carts where c.CustomerId == model.CustomerId select c;
            return query;
        }
    }
}

