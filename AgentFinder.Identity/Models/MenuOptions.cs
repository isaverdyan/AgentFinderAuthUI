using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class MenuOptions
    {
        [Key]
        public int Id { get; set; }
        public string MenuText { get; set; }
        public string MenuUrl { get; set; }
        public string? Icon { get; set; }
        public string? LanguageCode { get; set; }
        public string? AltText { get; set; }
        public string? Target { get; set; }
        public int? ParentId { get; set; }
        public int OrderNumber { get; set; }
    }
}
