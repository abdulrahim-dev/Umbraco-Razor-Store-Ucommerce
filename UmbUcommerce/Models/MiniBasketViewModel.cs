using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCommerce;

namespace UmbUcommerce.Models
{
    public class MiniBasketViewModel
    {
        public MiniBasketViewModel()
        {
            MiniOrderlineViewModelCollection = new List<MiniOrderlineViewModel>();
        }

        public int NumberOfItems { get; set; }
        public Money Total { get; set; }
        public bool IsEmpty { get; set; }

        public List<MiniOrderlineViewModel> MiniOrderlineViewModelCollection { get; set; }
        
    }
    public class MiniOrderlineViewModel
    {
        public string Total { get; set; }

        public int Quantity { get; set; }

        public int OrderLineId { get; set; }

        public string Sku { get; set; }

        public string VariantSku { get; set; }

        public string ProductName { get; set; }

        public string Tax { get; set; }

        public decimal? Discount { get; set; }

        public string ProductUrl { get; set; }

        public string Price { get; set; }

        public string PriceWithDiscount { get; set; }

    }
}