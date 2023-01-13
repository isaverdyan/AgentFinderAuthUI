using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

    }
}
