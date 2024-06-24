namespace ConferenceManagerService.Dtos
{
    public class ConferenceCreateDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string description { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }
    }
}
