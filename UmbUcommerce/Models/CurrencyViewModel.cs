using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbUcommerce.Models
{
    public class CurrencyViewModel
    {
        public virtual string Name { get; set; }
       
        public virtual int PriceGroupId { get; set; }

        public bool IsCurrent { get; set; }
    }
}