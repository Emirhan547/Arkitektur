using Arkitektur.WebUI.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutTopBarViewComponent(IContactService _contactService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response=await _contactService.GetAllAsync();
            return View(response.Data);
        }
    }
}
