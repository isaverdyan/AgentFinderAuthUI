using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AgentId")]
        public int UserId { get; set; }

        public string? CompanyName { get; set; }

        public int? YearsInBusiness { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location location { get; set; }

   
    }
}
