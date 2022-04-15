using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    [Owned]
    public class Adress
    {
        public String City { get; set; }
        public String StreetAdress { get; set; }

    }
}
