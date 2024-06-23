namespace ConferenceManagerService.Dtos
{
    public class ConferenceCreateDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateConference { get; set; }
        public string Location { get; set; }
        public int NumberTickets { get; set; }
        public float Price { get; set; }
    }
}
