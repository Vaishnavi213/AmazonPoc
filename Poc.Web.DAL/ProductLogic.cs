using Poc.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poc.Web.DAL
{
    public class ProductLogic
    {
        AmazonDbContext db = new AmazonDbContext();

        //create Products
        public Boolean addProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return true;
        }

        //retrieve products
        public IEnumerable<Product> getData()
        {
            return db.Products.ToList();
        }

        //retrieve data by id
        public Product getDataById(int proId)
        {
            return db.Products.SingleOrDefault(p => p.ProductId == proId);
            //var query = from obj in db.Products where obj.ProductId == proId select obj;
            //return query;
        }

        //Update Products
        public bool updateData(int proId, Product model)
        {
            if (datavalid(proId))
            {
                var query = db.Products.Where(z => z.ProductId == proId).FirstOrDefault();
                //   var query1 = db.Categories.Where(c => model.ProductName == c.CategoryName).Select(c => c.CategoryId).SingleOrDefault();
                query.ProductName = model.ProductName;
                query.Price = model.Price;
                query.Image = model.Image;
                query.Description = model.Description;
                //  query.CategoryId = model.CategoryId;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete products
        public bool deleteData(int proId)
        {
            if (datavalid(proId))
            {
                var query = db.Products.Where(z => z.ProductId == proId).FirstOrDefault();
                db.Entry(query).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean datavalid(int id)
        {
            var query = db.Products.Where(z => z.ProductId == id).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }
    }
}


