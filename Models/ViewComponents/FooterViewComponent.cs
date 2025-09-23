using Microsoft.AspNetCore.Mvc;
using MyBlog.DB.Entities;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using System.Net.WebSockets;

namespace MyBlog.Models.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IPersonalRepository _personalRepository;
        public FooterViewComponent(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socials = await this._personalRepository.GetSocials();
            return View(socials);
        }
        
        
            
    }
}
