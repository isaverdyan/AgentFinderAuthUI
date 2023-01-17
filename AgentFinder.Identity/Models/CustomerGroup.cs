using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class CustomerGroup
    {
        [Key]
        public int Id { get; set; }

        public string GroupName { get; set; }
    }
}
