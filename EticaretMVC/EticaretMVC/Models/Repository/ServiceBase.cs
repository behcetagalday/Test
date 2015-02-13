using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models.Repository
{
    public class ServiceBase
    {
        private ShopicaDBEntities _DB;

        public ShopicaDBEntities DB
        {
            get {
                _DB = _DB ?? new ShopicaDBEntities();    
                return _DB;
            }
           
        }
    }
}