using MyBlog.DB.Entities;

namespace MyBlog.Models.ViewModels
{
    public class ProjectPageViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TryUrl { get; set; } = "#";
        public string Type { get; set; } = string.Empty;
        public string Viewer { get; set; } = "0";
        public SourceCode SourceCodes { get; set; } = new SourceCode();
        public bool Status { get; set; } = false;
        public int Members { get; set; } = 1;
        public TechStack TechStacks { get; set; } = new TechStack();
        public Dataset Datasets { get; set; } = new Dataset();
        public string ModelPath { get; set; } = string.Empty;
        public EvaluationMetrics EvaluationMetrics { get; set; } = new EvaluationMetrics();
        public string Role { get; set; } = string.Empty;

    }
}
