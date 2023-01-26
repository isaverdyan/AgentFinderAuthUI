using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models;

public class AgentCustomer
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("AgentId")]
    public virtual Agent Agent { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime SubscriptionDate { get; set; }
}

