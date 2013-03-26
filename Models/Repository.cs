using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApis.Models
{
    public abstract class Repository
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["PMEntities"];

        private static PMEntities _dataContext;
        public static PMEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = new PMEntities(ConnectionString)); }
        }

        

       
    }
}