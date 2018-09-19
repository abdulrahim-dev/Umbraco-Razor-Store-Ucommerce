using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.EntitiesV2;
using UCommerce.Infrastructure;
using Umbraco.Web.Mvc;
using UmbUcommerce.Models;

namespace UmbUcommerce.Controllers
{
    public class CurrencyController : SurfaceController
    {
        // GET: Currency
        public ActionResult GetCurrency()
        {
            var priceGroupRepository = ObjectFactory.Instance.Resolve<IRepository<PriceGroup>>();
            var priceGroups = priceGroupRepository.Select(x => !x.Deleted);

            //Get current price group
            var PriceGroupCurrent = UCommerce.Runtime.SiteContext.Current.CatalogContext.CurrentPriceGroup;

            var model = new List<CurrencyViewModel>();
            if (priceGroups.Any())
            {
                foreach (var pg in priceGroups)
                {
                    model.Add(new CurrencyViewModel()
                    {
                        PriceGroupId = pg.PriceGroupId,
                        Name = pg.Name,
                        IsCurrent = (pg.PriceGroupId == PriceGroupCurrent.PriceGroupId) ? true : false
                    });
                }
            }
            return View("/Views/PartialView/_CurrencyList.cshtml", model);
        }

        //
        [HttpPost]
        public ActionResult ChangeCurrency(int PriceGroupId)
        {
            var priceGroupRepository = ObjectFactory.Instance.Resolve<IRepository<PriceGroup>>();
            var priceGroupSelected = priceGroupRepository.Select(x => !x.Deleted && x.PriceGroupId == PriceGroupId).FirstOrDefault();

            if (priceGroupSelected != null)
            {
                UCommerce.Api.CatalogLibrary.ChangePriceGroup(priceGroupSelected, true);
                return Json(new
                {
                    success = true
                });
            }
            return Json(new
            {
                success = false
            });
        }
    }
}