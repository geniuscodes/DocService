using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.HeaderSearchForm
{
    public class HeaderSearchFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}