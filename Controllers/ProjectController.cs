using Microsoft.AspNetCore.Mvc;
using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;
using MyBlog.Services;
using MyBlog.Services.Interfaces;

namespace MyBlog.Controllers
{
    [Route("project")]
    public class ProjectController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProjectPageViewModel> projectPageViewModels = await this._projectService.GetProjectsByLang(GetLang());
            return View(projectPageViewModels);
        }
    }
}
