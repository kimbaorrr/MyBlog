using Microsoft.Extensions.Localization;
using MyBlog.DB.Entities;

namespace MyBlog.Services
{
    public abstract class CommonService<T>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        protected readonly ILogger<T> _logger;
        public CommonService(ILogger<T> logger, IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        protected string Localize(DB.Entities.LocalizedString field, string lang) =>
            lang == "en" ? field.En : field.Vi;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        protected List<string> LocalizeByList(IList<DB.Entities.LocalizedString> list, string lang)
        {
            if (list == null) return new List<string>();
            return list.Select(x => lang == "en" ? x.En : x.Vi).ToList();
        }
        /// <summary>
        /// Lấy bản dịch trong Resources theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetLocalizeByKey(string key)
        {
            return this._localizer[key];
        }
    }


}
