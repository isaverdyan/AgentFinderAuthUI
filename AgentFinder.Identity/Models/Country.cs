using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;


namespace AgentFinder.Identity.Models;

public class Country : AuditableEntity
{
    [Key]
    public int Id { get; set;}

    public string Name { get; set;}

    public string ShortCode { get; set; }

}

