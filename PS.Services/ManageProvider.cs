using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    /**
     * LinQ ( ychabah l sql)
     * 
     * Methode prédefinis (lambda expressions)
     * 
    */
    public class ManageProvider
    {


        public List<Provider> providers { get; set; } = new List<Provider>();
        /**
         *  retourne la liste des providers dont le nom
            contient name.
         */
        public List<Provider> GetProviderByName(string name)
        {
            /*
             * besh nekhdmou bel linq
             * par défaut yraja3 IEnumerable alors nzidoha .ToList() 
             * ILink  -> ICollection ( 3andha l crud) -> IEnumerable ( sért a parcourir) 
             */
            List<Provider> req = (from p in providers
                                 where p.Username.Contains(name)
                                 select p).ToList();

            return req;
        }


        public List<String> GetProviderEmailsByName(string name)
        {
            /*List<String> req = (from p in providers
                                  where p.Username.Contains(name)
                                  select p.Username).ToList();
            return req;*/

            return providers.Where(p => p.Username.Contains(name)).Select(p => p.Email).ToList();
        }

        public Provider GetFirstProviderByName(string name)
        {
            var req = (from p in providers
                       where p.Username.StartsWith(name)
                       select p);
            return req.First();
        }
        public void DisplayUsernameAndEmail(string name)
        {
            var req = (from p in providers
                                where p.Username.Contains(name)
                                select (p.Username,p.Email)).ToList();
            foreach (var p in req)
                Console.WriteLine(p);
        }
    }


}
