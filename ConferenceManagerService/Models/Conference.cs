using System.ComponentModel.DataAnnotations;

namespace ConferenceManagerService.Models
{
    public class Conference
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateConference { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int NumberTickets { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
