using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    [Table("CALENDARS")]
    public class Calendar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("calendarid")]
        public int ID { get; set; }

        [Required]
        [Column("calendarname")]
        public string Name { get; set; }

        //Navigation Property
        [JsonIgnore]
        public virtual ICollection<Models.CalendarEvent> Events { get; set; }
        [JsonIgnore]
        public virtual ICollection<Models.CalendarUser> CalendarUsers { get; set; }
    }
}
