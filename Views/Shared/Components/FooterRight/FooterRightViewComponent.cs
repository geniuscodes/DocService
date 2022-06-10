using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.FooterRight
{
    public class FooterRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}