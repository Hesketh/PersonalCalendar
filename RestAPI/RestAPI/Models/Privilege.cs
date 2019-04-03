using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Having this seems pointless. An enum would be better
namespace RestAPI.Models
{
    [Table("PRIVILEGES")]
    public class PrivilegeModel
    {
        [Key]
        [Column("privilege")]
        [MaxLength(5)]
        public string Privilege { get; set; }

        //Navigation Property
        [JsonIgnore]
        public virtual CalendarUser CalendarUser { get; set; }
    }
}
