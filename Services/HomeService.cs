using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.Extensions.Localization;
using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class HomeService : CommonService<HomeService>, IHomeService
    {
        private readonly IIntroductionRepository _introductionRepository;
        private readonly IPersonalRepository _personalRepository;    
        public HomeService(IIntroductionRepository introductionRepository, IPersonalRepository personalRepository, ILogger<HomeService> logger, IStringLocalizer<SharedResource> localizer) : base(logger, localizer)
        {
            this._introductionRepository = introductionRepository;
            this._personalRepository = personalRepository;
        }
        public async Task<HomeCardInfoViewModel> GetCardInfoByLang(string lang)
        {
            List<Personal> personals = await this._personalRepository.GetPersonals();

            if (personals == null)
            {
                this._logger.LogWarning("GetCardInfoByLang: Không có Personal nào trong DB {}", personals);
                return new HomeCardInfoViewModel();
            }

            Personal p = personals.FirstOrDefault()!;

            this._logger.LogInformation("GetCardInfoByLang: Lấy & gán dữ liệu thành công: {Count}", personals.Count);

            return new HomeCardInfoViewModel
            {
                FullName = Localize(p.FullName, lang),
                AvatarUrl = p.Avatar,
                Address = Localize(p.Address, lang),
                Email = p.Email,
                Favorite = Localize(p.Favorite, lang),
                Git = (p.Socials.Git!.Name, p.Socials.Git.Url),
                Job = Localize(p.Job, lang),
                Workplace = Localize(p.Workplace, lang),
                X = (p.Socials.X!.Name, p.Socials.X.Url)
            };
        }
        public async Task<HomeIntroContentViewModel> GetHomeIntroContentByLang(string lang)
        {
            List<Introduction> introductions = await this._introductionRepository.GetIntroductions();
            if (introductions == null)
            {
                this._logger.LogWarning("GetHomeIntroContentByLang: Không có Personal nào trong DB {}", introductions);
                return new HomeIntroContentViewModel();
            }

            Introduction i = introductions.FirstOrDefault()!;

            this._logger.LogInformation("GetHomeIntroContentByLang: Lấy & gán dữ liệu thành công: {Count}", introductions.Count);

            return new HomeIntroContentViewModel()
            {
                Goals = LocalizeByList(i.Goals, lang),
                Hi = GetLocalizeByKey("home_body.hi"),
                Passion = Localize(i.Passion, lang),
                Welcome = Localize(i.Welcome, lang),
                Thanks = GetLocalizeByKey("home_body.thanks"),
                Navigator =
                {
                    Contact = GetLocalizeByKey("home_body.link_list.contact"),
                    CV = GetLocalizeByKey("home_body.link_list.cv"),
                    Project = GetLocalizeByKey("home_body.link_list.projects"),
                    Tool = GetLocalizeByKey("home_body.link_list.tools")
                }
            };
        }



    }
}
