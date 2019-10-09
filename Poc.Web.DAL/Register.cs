using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poc.Web.Entities;

namespace Poc.Web.DAL
{
    public class Register
    {
        AmazonDbContext db = new AmazonDbContext();
        public Boolean AddData(Customer model)
        {
            model.Role = "user";
            db.Customers.Add(model);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Customer> getdata()
        {
            return db.Customers.ToList();
        }

        public IEnumerable<Customer> getdatabyid(int id)
        {
            var query = from r in db.Customers where r.CustId == id select r;
            return query;
        }

        public bool updateData(int id, Customer model)
        {
            if (datavalid(id))
            {
                var query = db.Customers.Where(z => z.CustId == id).FirstOrDefault();
                query.CustName = model.CustName;
                query.CustEmail = model.CustEmail;
                query.CustPassword = model.CustPassword;
                query.CustPhoneNo = model.CustPhoneNo;             
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteData(int id)
        {
            if (datavalid(id))
            {
                var query = db.Customers.Where(z => z.CustId == id).FirstOrDefault();
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
            var query = db.Customers.Where(z => z.CustId == id).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }
    }
}