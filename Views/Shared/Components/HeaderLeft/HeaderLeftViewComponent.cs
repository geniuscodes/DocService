using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.HeaderLeft
{
    public class HeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}