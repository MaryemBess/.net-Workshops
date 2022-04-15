using PS.Data;
using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ServiceProduct : Service<Product>, IserviceProduct
    {
        public void DeleteOldProducts()
        {
            Delete(p => (DateTime.Now - p.DateProd).TotalDays > 365);
        }

        public IEnumerable<Product> FindMost5ExpensiveProds()
        {

            return GetMany().OrderByDescending(p => p.Price).Take(5); 
        }

        public IEnumerable<Product> GetProdsByClient(Client c)
        {
            ServiceAchat sa = new ServiceAchat();
            return sa.GetMany(a => a.ClientFK == c.Cin).Select(a => a.Product);
        }

        public float UnavailableProductsPercentage()
        {
            int nbProduct = GetMany().Count();
            int nbUnavailable = GetMany(p => p.Quantity == 0).Count();
            return (float) (nbUnavailable / nbProduct) * 100;
        }
    }
}
