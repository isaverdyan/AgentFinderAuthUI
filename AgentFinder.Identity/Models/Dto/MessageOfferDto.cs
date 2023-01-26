using Newtonsoft.Json;

namespace AgentFinder.Identity.Models.Dto
{
    public class MessageOfferDto
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
        [JsonProperty("user")]
        public UserDto? User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("messagetext")]
        public string? MessageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lastcontactdate")]
        public string? LastContactDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("longdescription")]
        public string? LongDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("shortdescription")]
        public string? ShortDescription { get; set; }
    }
}
