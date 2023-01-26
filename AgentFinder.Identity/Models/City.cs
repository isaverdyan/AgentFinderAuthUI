using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentFinder.Identity.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public virtual  Country country { get; set; }

    }
}
