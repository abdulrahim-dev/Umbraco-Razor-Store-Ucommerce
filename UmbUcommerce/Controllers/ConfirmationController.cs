using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbUcommerce.Models;

namespace UmbUcommerce.Controllers
{
    public class ConfirmationController : RenderMvcController
    {
        // GET: Confirmation
        public override ActionResult Index(RenderModel model)
        {
            ConfirmationPageViewModel confirmationPageViewModel = new ConfirmationPageViewModel();
          return View("/Views/Confirmation.cshtml", confirmationPageViewModel);
        }
    }
}