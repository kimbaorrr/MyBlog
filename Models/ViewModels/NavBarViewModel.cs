namespace MyBlog.Models.ViewModels
{
    public class NavBarViewModel
    {
        public string LogoUrl { get; set; } = "#";
        public string Brand { get; set; } = "BaoIT Blog";
        public NavBarLinks Links { get; set; } = new NavBarLinks();
        public class NavBarLinks
        {
            public string Contact { get; set; } = string.Empty;
            public string CV { get; set; } = string.Empty;
            public string Project { get; set; } = string.Empty;
            public string Tool { get; set; } = string.Empty;
            public string Home { get; set; } = string.Empty;
        }

    }
}
