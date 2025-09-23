using Microsoft.AspNetCore.Mvc;
using MyBlog.DB.Entities;
using MyBlog.Services;
using MyBlog.Services.Interfaces;

namespace MyBlog.Controllers
{
    [Route("tool")]
    public class ToolController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IToolService _toolService;
        public ToolController(ILogger<ToolController> logger, IToolService toolService)
        {
            _logger = logger;
            _toolService = toolService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            List<Tool> tools = await this._toolService.GetToolsByLang(GetLang());
            return View(tools);
        }
        [HttpGet("load")]
        public IActionResult Load(string selector)
        {
            return PartialView("Partials/" + "_" + selector);
        }
    }
}
