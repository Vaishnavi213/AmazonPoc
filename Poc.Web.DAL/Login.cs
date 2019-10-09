using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poc.Web.DAL;
using Poc.Web.Entities;

namespace Poc.Web.DAL { 
    public class Login
    {
        AmazonDbContext Db = new AmazonDbContext();
        public Boolean EmailValid(Customer model)
        {
            var query = Db.Customers.Where(x => x.CustEmail == model.CustEmail).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false;
        }



        public int login(Customer model)
        {
            if (EmailValid(model))
            {
                var query = Db.Customers.Where(x => x.CustEmail == model.CustEmail).FirstOrDefault();
                if (query == null)
                {
                    return 0;
                }
                else
                {
                    if (query.Role.ToUpper() == "USER")
                    {
                        var pass = query.CustPassword;
                        if (model.CustPassword != pass)
                            return 0;
                        else
                            return 1;
                    }
                    else if (query.Role.ToUpper() == "ADMIN")
                    {
                        var pass = query.CustPassword;
                        if (model.CustPassword != pass)
                            return 0;
                        else
                            return 1;
                    }
                    else
                    {
                        var pass = query.CustPassword;
                        if (model.CustPassword != pass)
                            return 0;
                        else
                            return 2;
                    }
                }
            }
            else
            {
                return 0;
            }
        }
    }



}
