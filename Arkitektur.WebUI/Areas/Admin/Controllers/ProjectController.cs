using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController(IProjectService _projectService, ICategoryService _categoryService) : Controller
    {
        private async Task GetCategories()
        {
            var result = await _categoryService.GetAllAsync();
            var categories = result.Data;
            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()
                                  }).ToList();

        }
        public async Task<IActionResult> Index()
        {
            var response = await _projectService.GetProjectsWithCategoriesAsync();
            return View(response.Data);
        }
        public async Task<IActionResult> CreateProject()
        {
            await GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
        {
            await GetCategories();
            await _projectService.CreateAsync(projectDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            await GetCategories();
            var response = await _projectService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await GetCategories();
            await _projectService.UpdateAsync(projectDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}