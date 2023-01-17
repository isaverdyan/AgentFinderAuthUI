using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentFinder.Identity.Entities;

namespace AgentFinder.Identity.Models;

public class Location : AuditableEntity
{
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        [ForeignKey("CityId")]
        public virtual City ciy { get; set; }

}

