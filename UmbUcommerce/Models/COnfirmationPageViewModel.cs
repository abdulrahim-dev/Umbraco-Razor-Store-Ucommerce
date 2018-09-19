using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace UmbUcommerce.Models
{
    public class ConfirmationPageViewModel : RenderModel
    {
        public ConfirmationPageViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        {

        }
    }
}