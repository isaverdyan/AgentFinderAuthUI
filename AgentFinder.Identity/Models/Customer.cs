using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;

namespace AgentFinder.Identity.Models
{
    public class Customer : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

    }
}
