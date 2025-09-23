using Microsoft.Extensions.Localization;
using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class ProjectService : CommonService<ProjectService>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(ILogger<ProjectService> logger, IStringLocalizer<SharedResource> localizer, IProjectRepository projectRepository) : base(logger, localizer) {
            _projectRepository = projectRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public async Task<List<ProjectPageViewModel>> GetProjectsByLang(string lang)
        {
            List<Project> pList = await this._projectRepository.GetProjects();

            List<ProjectPageViewModel> projectPageViewModels = new List<ProjectPageViewModel>();

            foreach (var p in pList)
            {
                projectPageViewModels.Add(new ProjectPageViewModel
                {
                    Name = p.Name,
                    Datasets = p.Dataset ?? new Dataset(),
                    Description = Localize(p.Description, lang),
                    EvaluationMetrics = p.EvaluationMetrics ?? new EvaluationMetrics(),
                    ModelPath = p.ModelPath,
                    SourceCodes = p.SourceCode ?? new SourceCode(),
                    Status = p.Status,
                    TechStacks = p.TechStack ?? new TechStack(),
                    TryUrl = p.TryUrl,
                    Type = p.Type,
                    Viewer = p.Viewer,
                    Members = Convert.ToInt32(p.Members),
                    Role = Localize(p.Role, lang)
                    
                });
            }
            return projectPageViewModels;
        }
    }
}
