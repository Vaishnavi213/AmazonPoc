//using Poc.Web.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Poc.Web.DAL
//{
//    public class user
//    {
//        PocDbContext db = new PocDbContext();

//        //create Products
//        public Boolean addProduct(Customer cust)
//        {
//            db.Customers.Add(cust);
//            db.SaveChanges();
//            return true;
//        }

//        //retrieve products
//        public IEnumerable<Customer> getData()
//        {
//            return db.Customers.ToList();
//        }

//        //retrieve data by id
//        public IEnumerable<Customer> getDataById(int CustomerId)
//        {
//            var query = from obj in db.Customers where obj.CustId == CustomerId select obj;
//            return query;
//        }

//        //Update Products
//        public bool updateData(int CustomerId, Customer model)
//        {
//            if (datavalid(CustomerId))
//            {
//                var query = db.Customers.Where(z => z.CustId== CustomerId).FirstOrDefault();
  
//                query.CustName = model.CustName;
//                query.CustEmail = model.CustEmail;
//                query.CustPassword = model.CustPassword;
//                query.CustPhoneNo = model.CustPhoneNo;
//                query.CustAddress = model.CustAddress;
//                db.SaveChanges();
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }


//        //delete products
//        public bool deleteData(int CustomerId)
//        {
//            if (datavalid(CustomerId))
//            {
//                var query = db.Customers.Where(z => z.CustId == CustomerId).FirstOrDefault();
//                db.Entry(query).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
//                db.SaveChanges();
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public Boolean datavalid(int id)
//        {
//            var query = db.Customers.Where(z => z.CustId == id).FirstOrDefault();
//            if (query == null)
//                return false;
//            else
//                return true;
//        }
//    }
//}
    

