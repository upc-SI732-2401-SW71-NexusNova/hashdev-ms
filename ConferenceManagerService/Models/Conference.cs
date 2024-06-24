using System.ComponentModel.DataAnnotations;

namespace ConferenceManagerService.Models
{
    public class Conference
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
