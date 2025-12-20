using Microsoft.AspNetCore.Mvc;
using Arkitektur.WebUI.Models;
using Arkitektur.WebUI.Services.ContactServices;
using Arkitektur.WebUI.Services.FeatureServices;


namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{

    public class _UILayoutFooterViewComponent(IContactService contactService, IFeatureService featureService) : ViewComponent
    {

        private readonly IContactService _contactService = contactService;
        private readonly IFeatureService _featureService = featureService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
  
            var contactsTask = _contactService.GetAllAsync();
            var featuresTask = _featureService.GetAllAsync();

            await Task.WhenAll(contactsTask, featuresTask);

            var contactsResponse = await contactsTask;
            var featuresResponse = await featuresTask;

            var contacts = contactsResponse.Data ?? new List<DTOs.ContactDtos.ResultContactDto>();
            var features = featuresResponse.Data ?? new List<DTOs.FeatureDtos.ResultFeatureDto>();

            var model = new FooterViewModel
            {
                Contacts = contacts,
                Features = features
            };

            return View(model);
        }
    }

}

