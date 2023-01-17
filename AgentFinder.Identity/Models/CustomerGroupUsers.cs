using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models
{
    public class CustomerGroupUsers
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        [ForeignKey("CustomerGroupId")]
        public virtual CustomerGroup customerGroup { get; set; }


    }
}
