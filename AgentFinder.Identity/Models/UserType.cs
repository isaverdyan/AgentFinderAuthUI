using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class UserType
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public short UserTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(25)]
        public string TypeName { get; set; }
    }
}
