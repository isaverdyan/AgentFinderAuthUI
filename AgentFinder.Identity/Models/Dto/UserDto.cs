using Newtonsoft.Json;

namespace AgentFinder.Identity.Models.Dto
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userid")]
        public string? UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("firstname")]
        public string? FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lastname")]
        public string? LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("username")]
        public string? UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token")]
        public string? Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("role")]
        public string? Role { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        
    }
}
