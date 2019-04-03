using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    [Table("CALENDARUSERS")]
    public class CalendarUser
    {
        [Key]
        [Required]
        [Column("calendarid", Order = 2)]
        public int CalendarID { get; set; }

        [Key]
        [Required]
        [Column("username", Order = 1)]
        [MinLength(2), MaxLength(16)]
        public string Username { get; set; }

        [Required]
        [Column("privilege")]
        [MaxLength(5)]
        public string PrivilegeKey { get; set; }

        //Navigation Properties
        [JsonIgnore]
        public virtual Calendar Calendar { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual PrivilegeModel Privilege { get; set; }
    }
}
