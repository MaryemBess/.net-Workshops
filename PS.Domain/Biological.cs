using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Biological : Product
    {
        //public Biological(string Herbs,int productId, string name, double price, DateTime dateProd, string description, int quantity, List<Provider> providers) : base(productId, name, price, dateProd, description, quantity, providers)
        //{
        //    this.Herbs = Herbs;
        //}

        public string Herbs { get; set; }

        public void GetMyType()
        {
            base.GetMyType();
            Console.Write("biologique\n");
        }
    }
}
