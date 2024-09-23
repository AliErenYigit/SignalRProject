using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.BookATableComponents
{
    public class _BookATablePartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
