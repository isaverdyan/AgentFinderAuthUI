using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models;

public class CustomerNotification
{
    /// <summary>
    /// 
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("AgentId")]
    public virtual Agent Agent { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Notification { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime Created { get; set; }
}

