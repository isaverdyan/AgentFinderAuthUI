using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;

namespace AgentFinder.Identity.Models
{
    public class AgentInterestsLocation : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public virtual List<Location> Locations { get; set; }

        public string? Description { get; set; }
    }
}
