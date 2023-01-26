using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Models
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string? FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string? LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        [MaxLength(50)]
        public string? UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string? Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(25)]
        public string? Role { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string? Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("UserTypeId")]
        public virtual UserType userType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
