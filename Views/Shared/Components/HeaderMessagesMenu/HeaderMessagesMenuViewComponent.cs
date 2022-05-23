using Microsoft.AspNetCore.Mvc;

namespace DocService.Views.Shared.Components.HeaderMessagesMenu
{
    public class HeaderMessagesMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}