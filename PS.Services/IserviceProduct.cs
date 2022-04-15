using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public interface IserviceProduct : IService<Product>
    {
        IEnumerable<Product> FindMost5ExpensiveProds();
        float UnavailableProductsPercentage();
        IEnumerable<Product> GetProdsByClient( Client c);
        void DeleteOldProducts();
    }
}
