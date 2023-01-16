using System.ComponentModel.DataAnnotations;
using AgentFinder.Identity.Entities;

namespace AgentFinder.Identity.Models
{
    public class Customer : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public CustomerGroup CustomerGroup { get; set; }

    }
}
