using System.Collections.Generic;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using UmbUcommerce.Models;
using Umbraco.Web.Mvc;
using UCommerce.Runtime;
using System.Linq;
using UCommerce.Infrastructure;
using System;
using UCommerce.Content;

namespace UmbUcommerce.Controllers
{
    public class PartialViewController : SurfaceController
    {
        public ActionResult CategoryNavigation()
        {
            var categoryNavigationModel = new CategoryNavigationViewModel();

            ICollection<Category> rootCategories = CatalogLibrary.GetRootCategories();

            categoryNavigationModel.Categories = MapCategories(rootCategories);

            return View("/views/PartialView/_HeaderMainMenuCategoryNav.cshtml", categoryNavigationModel);
        }

        private IList<CategoryViewModel> MapCategories(ICollection<Category> categoriesToMap)
        {
            var categoriesToReturn = new List<CategoryViewModel>();

            foreach (var category in categoriesToMap)
            {
                var categoryViewModel = new CategoryViewModel();

                categoryViewModel.Name = category.DisplayName();
                categoryViewModel.Url = CatalogLibrary.GetNiceUrlForCategory(category);
                categoryViewModel.Categories = MapCategories(CatalogLibrary.GetCategories(category));

                categoriesToReturn.Add(categoryViewModel);
            }

            return categoriesToReturn;
        }



        public ActionResult HomePageTabWithProducts(List<string> productIds)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel();

            //loop productIds
            foreach (var productId in productIds)
            {
                var product = CatalogLibrary.GetProduct(Convert.ToInt32(productId));

                productsViewModel.Products.Add(new ProductViewModel()
                {
                    Name = product.Name,
                    PriceCalculation = CatalogLibrary.CalculatePrice(product),
                    Url = CatalogLibrary.GetNiceUrlForProduct(product),
                    Sku = product.Sku,
                    IsVariant = product.IsVariant,
                    VariantSku = product.VariantSku,
                    ThumbnailImageUrl = ObjectFactory.Instance.Resolve<IImageService>().GetImage(product.ThumbnailImageMediaId).Url
                });


                //Get image and other details
            }
            // add to model
            return View("/views/PartialView/_HomePageTabProducts.cshtml", productsViewModel);
        }
    }
}