using Microsoft.AspNetCore.Mvc;

namespace TechGamer.Web.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
