using Microsoft.AspNetCore.Mvc;
using TechGamer.Web.Models;

namespace TechGamer.Web.Extensions
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList pagedModel)
        {
            return base.View(pagedModel);
        }
    }
}
