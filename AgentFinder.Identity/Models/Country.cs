using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;


namespace AgentFinder.Identity.Models;

public class Country : AuditableEntity
{
    [Key]
    public int Id { get; set;}
    /// <summary>
    /// 
    /// </summary>
    [MaxLength(25)]
    public string Name { get; set;}
    /// <summary>
    /// 
    /// </summary>
    [MaxLength(5)]
    public string ShortCode { get; set; }

}

