using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    [Table("USERS")]
    public class User
    {
        [Key]
        [Required]
        [Column("username")]
        [MinLength(2), MaxLength(16)]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        [MinLength(3), MaxLength(32)]
        public string Password { get; set; }

        //Navigation Propert
        [JsonIgnore]
        public virtual ICollection<Models.CalendarUser> CalendarUsers { get; set; }
    }
}
