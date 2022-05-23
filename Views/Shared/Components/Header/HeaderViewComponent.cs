using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}