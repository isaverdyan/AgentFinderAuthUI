namespace AgentFinder.Identity.Entities;


public class AuditableEntity : IAuditableEntity<Guid>
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }

