namespace AgentFinder.Identity.Entities;

public interface IAuditableEntity<Guid>
    {
        Guid UpdatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        DateTime CreatedDate { get; set; }
        Guid CreatedBy { get; set; }

    }

