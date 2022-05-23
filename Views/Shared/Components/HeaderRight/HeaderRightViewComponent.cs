using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.HeaderRight
{
    public class HeaderRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}