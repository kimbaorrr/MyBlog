using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Localization;
using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class ToolService : CommonService<ToolService>, IToolService
    {
        private readonly IToolRepository _toolRepository;
        public ToolService(ILogger<ToolService> logger, IStringLocalizer<SharedResource> localizer, IToolRepository toolRepository) : base(logger, localizer)
        {
            _toolRepository = toolRepository;
        }
        public async Task<List<Tool>> GetToolsByLang(string lang)
        {
            List<Tool> tools = await this._toolRepository.GetTools();

            if (tools == null)
            {
                this._logger.LogWarning("GetToolsByLang: Không có Tool nào trong DB {}", tools);
                return new List<Tool>();
            }

            Tool p = tools.FirstOrDefault()!;

            this._logger.LogInformation("GetToolsByLang: Lấy & gán dữ liệu thành công: {Count}", tools.Count);

            return tools;
        }
    }
}
