using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string? CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(100)]
        public string? CompanyAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(25)]
        [StringLength(25)]
        public string? CompanyPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(25)]
        [StringLength(25)]
        public string? CompanyPhone2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? YearsInBusiness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public short? CompanyRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("LocationId")]
        public virtual Location location { get; set; }

   
    }
}
