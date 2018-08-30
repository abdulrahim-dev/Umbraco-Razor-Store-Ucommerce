using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbUcommerce.Controllers
{
    public class ConfirmationController : RenderMvcController
    {
        // GET: Confirmation
        public override ActionResult Index(RenderModel model)
        {
          return View("/Views/Confirmation.cshtml");
        }
    }
}