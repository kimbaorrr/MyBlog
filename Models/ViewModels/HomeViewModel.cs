namespace MyBlog.Models.ViewModels
{
    public class HomeCardInfoViewModel
    {
        public string AvatarUrl { get; set; } = "#";
        public string FullName { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public string Favorite { get; set; } = string.Empty;
        public string Workplace { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public (string, string) Git { get; set; } 
        public (string, string) X { get; set; }
    }
    public class HomeIntroContentViewModel
    {
        public string Hi { get; set; } = string.Empty;
        public string Welcome { get; set; } = string.Empty;
        public string Passion { get; set;} = string.Empty;
        public List<string> Goals { get; set; } = new();
        public string Thanks { get; set; } = string.Empty;
        public IntroContentNavigator Navigator { get; set; } = new IntroContentNavigator();


        public class IntroContentNavigator
        {
            public string Contact { get; set; } = string.Empty;
            public string CV { get; set; } = string.Empty;
            public string Project { get; set; } = string.Empty;
            public string Tool { get; set; } = string.Empty;
        }
    }

    public class HomePageViewModel
    {
        public HomeCardInfoViewModel HomeCardInfoViewModel { get; set; } = new HomeCardInfoViewModel();
        public HomeIntroContentViewModel HomeIntroContentViewModel { get; set; } = new HomeIntroContentViewModel();
    }

    
}
