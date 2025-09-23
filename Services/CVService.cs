using Microsoft.Extensions.Localization;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class CVService : CommonService<CVService>, ICVService
    {
        public CVService(ILogger<CVService> logger, IStringLocalizer<SharedResource> localizer) : base (logger, localizer) { }

    }
}
