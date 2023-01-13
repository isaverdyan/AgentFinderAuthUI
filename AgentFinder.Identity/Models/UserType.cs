using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class UserType
    {
        [Key]
        public short UserTypeId { get; set; }
        public string TypeName { get; set; }
    }
}
