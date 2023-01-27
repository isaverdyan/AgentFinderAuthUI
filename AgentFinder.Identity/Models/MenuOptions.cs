using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class MenuOptions
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string MenuText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255)]
        public string MenuUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string? Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(5)]
        public string? LanguageCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string? AltText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string? Target { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNumber { get; set; }
    }
}
