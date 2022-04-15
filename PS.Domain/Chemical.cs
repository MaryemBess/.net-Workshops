using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
  public  class Chemical : Product
    {

        //public Chemical(int productId, string name, double price, DateTime dateProd, string description, int quantity, List<Provider> providers) : base(productId, name, price, dateProd, description, quantity, providers)
        //{
        //}


        public String LabName { get; set; }

        public Adress Adress { get; set; }

        public override void GetMyType()
        {
            base.GetMyType(); // pour hériter console.write du parentk.
            Console.Write("chimique\n");
        }

    }
}
