using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.TestimonialDtos;
using Arkitektur.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Area.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class TestimonialController(ITestimonialService _testimonialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await _testimonialService.GetAllAsync();
            return View(abouts.Data);
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonial)
        {
            await _testimonialService.CreateAsync(createTestimonial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var response = await _testimonialService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            await _testimonialService.UpdateAsync(updateTestimonial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
