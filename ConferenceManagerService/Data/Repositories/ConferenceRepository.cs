using ConferenceManagerService.Models;

namespace ConferenceManagerService.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private ConferenceManagerDbContext _context;

        public ConferenceRepository(ConferenceManagerDbContext context)
        {
            _context = context;
        }
        public void CreateConference(Conference conference)
        {
            if (conference == null)
            {
                throw new System.ArgumentNullException(nameof(conference));
            }
            _context.Conferences.Add(conference);
        }

        public void DeleteConference(Conference conference)
        {
            if (conference == null)
            {
                throw new System.ArgumentNullException(nameof(conference));
            }
            _context.Conferences.Remove(conference);
        }

        public IEnumerable<Conference> GetAllConferences()
        {
            return _context.Conferences;
        }

        public Conference GetConferenceById(int id)
        {
            var conference = _context.Conferences.Find(id);
            if (conference == null)
            {
                throw new System.ArgumentNullException(nameof(conference));
            }
            return conference;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateConference(int id, Conference conference)
        {
            if (conference == null)
            {
                throw new System.ArgumentNullException(nameof(conference));
            }
            var existingConference = _context.Conferences.FirstOrDefault(p => p.Id == id);
            if (existingConference != null)
            {
                existingConference.Name = conference.Name;
                existingConference.Image = conference.Image;
                existingConference.Description = conference.Description;
                existingConference.Price = conference.Price;
                existingConference.Date = conference.Date;
                existingConference.Time = conference.Time;
                existingConference.Location = conference.Location;
                existingConference.UserId = conference.UserId;
            }
        }
    }
}
