using Arkitektur.WebUI.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeContactInfoViewComponent(IContactService _contactService):ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var response=await _contactService.GetAllAsync();
            return View(response.Data);
        }
    }
}
