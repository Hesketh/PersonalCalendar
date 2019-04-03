using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    [Table("EVENTS")]
    public class CalendarEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("eventid")]
        public int ID { get; set; }

        [Required]
        [Column("calendarid")]
        public int CalendarID { get; set; }

        [Required]
        [Column("eventtitle")]
        [MaxLength(32)]
        public string Title { get; set; }

        [Column("eventdescription")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Column("eventstart")]
        public DateTime Start { get; set; }

        [Column("eventend")]
        public DateTime End { get; set; }

        //Navigation Property
        [JsonIgnore]
        public virtual Models.Calendar Calendar { get; set; }
    }
}