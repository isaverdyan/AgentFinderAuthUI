using AgentFinder.Identity.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AgentFinder.Identity.Models
{
    public class MessageBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string MessageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customers")]
        public dynamic Customers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("users")]
        public dynamic Users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
