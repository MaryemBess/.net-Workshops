using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PS.Services
{
    public class ManageProduct
    {
        public List<Product> lsProduct { get; set; }
        public Func<char,List<Product>> FindProduct;
        public Action<Category> ScanProduct;

        public List<Product> Methode1(char c)
        {
            var req = from p in lsProduct
                      where p.Name.StartsWith(c)
                      select p;
            return req.ToList();
        }
        public ManageProduct()
        {
            //we can affect a method to FindProduct like this : 
            FindProduct = Methode1;
            // AND LIKE THIS :
            FindProduct = c =>
            {
                var req = from p in lsProduct
                          where p.Name.StartsWith(c)
                          select p;
                return req.ToList();
            };

            ScanProduct = car =>
            {
                var req = from p in lsProduct
                          where p.Category.CategoryId == car.CategoryId
                          select p;
                foreach (Product p in req)
                {
                    Console.WriteLine(p);
                }
            };
        }
        /**
         * retourne les cinq premiers produits qui ont un prix supérieur à price.
         */
        public IEnumerable<Chemical> Get5Chemical(double price)
        {
            var req1 = from p in lsProduct.OfType<Chemical>()
                       where p.Price > price
                       select p;
            var req2 = lsProduct.Where(p => p.Price > price).OfType<Chemical>();
            return req2.Take(5);

            //ignorer les 2 premiers produits 
            return req2.Skip(2).Take(5);
        }

        /**
         *  retourne le prix moyen de tous les produits
         */
        public double GetAveragePrice()
        {
            return lsProduct.Average(p => p.Price);
        }

        /**
         *  retourne le produit de max prix.
         */
        public Product GetMaxPrice()
        {
            var maxPrice = lsProduct.Max(p => p.Price);
            return lsProduct.Where(p => p.Price == maxPrice).First();

        }
        /**
         * retourne le nombre de produits chemical d’un city.
         */
        public int GetCountProduct(string city)
        {
            var req1 = from p in lsProduct.OfType<Chemical>()
                       where p.Adress.City.Equals(city)
                       select p;
            return req1.Count();
            
            var req2 = lsProduct.OfType<Chemical>().Where(p => p.Adress.City.Equals(city));
            return req2.Count();
        }

        /**
         *  : retourne la liste des produits chemical ordonnés par city
         */
        public IEnumerable<Chemical> GetChemicalCity()
        {
            var req1 = from p in lsProduct.OfType<Chemical>()
                       orderby p.Adress.City // orderby p.City descending 
                       select p;
            return req1;
        }

        /**
         * retourne la liste des produits chemical ordonnés et
         * groupé par city.
         */
        public IEnumerable<IGrouping<string, Chemical>> GetChemicalGroupByCity()
        {
            var req1 = from p in lsProduct.OfType<Chemical>()
                       orderby p.Adress.City
                       group p by p.Adress.City;
            foreach( var g in req1)
            {
                Console.WriteLine("-----------------------\nKey : "+g.Key);
                foreach(var v in g )
                    Console.WriteLine(v);
            }    
            return req1;
        }
    }
}
