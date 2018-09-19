using System.Linq;
using System.Web.Mvc;
using UCommerce;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using Umbraco.Web.Mvc;
using UmbUcommerce.Models;

namespace UmbUcommerce.Controllers
{
    public class MiniBasketController : SurfaceController
    {
// GET: MiniBasket
        public ActionResult Index()
        {
            var miniBasket = new MiniBasketViewModel();
            miniBasket.IsEmpty = true;

            if (TransactionLibrary.HasBasket())
            {
                PurchaseOrder basket = TransactionLibrary.GetBasket(false).PurchaseOrder;

                var numberOfItems = basket.OrderLines.Sum(x => x.Quantity);
                if (numberOfItems != 0)
                {
                    foreach (var orderLine in basket.OrderLines)
                    {
                        var miniOrderLineViewModel = new MiniOrderlineViewModel
                        {
                            Quantity = orderLine.Quantity,
                            ProductName = orderLine.ProductName,
                            Sku = orderLine.Sku,
                            VariantSku = orderLine.VariantSku,
                            Total = new Money(orderLine.Total.GetValueOrDefault(), basket.BillingCurrency).ToString(),
                            Discount = orderLine.Discount,
                            Tax = new Money(orderLine.VAT, basket.BillingCurrency).ToString(),
                            Price = new Money(orderLine.Price, basket.BillingCurrency).ToString(),
                            ProductUrl = CatalogLibrary.GetNiceUrlForProduct(CatalogLibrary.GetProduct(orderLine.Sku)),
                            PriceWithDiscount = new Money(orderLine.Price - orderLine.UnitDiscount.GetValueOrDefault(), basket.BillingCurrency).ToString(),
                            OrderLineId = orderLine.OrderLineId
                        };


                        miniBasket.MiniOrderlineViewModelCollection.Add(miniOrderLineViewModel);
                    }

                    miniBasket.Total = new Money(basket.OrderTotal.GetValueOrDefault(), basket.BillingCurrency);
                    miniBasket.NumberOfItems = basket.OrderLines.Sum(x => x.Quantity);
                    miniBasket.IsEmpty = false;
                }
            }
            return View("/Views/PartialView/MiniBasket.cshtml", miniBasket);
        }
    }
}
    