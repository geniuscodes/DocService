using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}