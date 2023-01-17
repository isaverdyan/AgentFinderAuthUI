using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;

namespace AgentFinder.Identity.Models
{
    public class OfferMessage : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        [ForeignKey("AgentId")]
        public virtual User agent { get; set; }

        [ForeignKey("CustomerGroupId")]
        public virtual CustomerGroup customerGroup { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType userType { get; set; }

    }
}
