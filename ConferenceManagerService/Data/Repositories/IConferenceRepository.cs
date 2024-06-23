using ConferenceManagerService.Models;

namespace ConferenceManagerService.Data.Repositories
{
    public interface IConferenceRepository
    {
        bool SaveChanges();
        IEnumerable<Conference> GetAllConferences();
        Conference GetConferenceById(int id);
        void CreateConference(Conference conference);
        void UpdateConference(int id, Conference conference);
        void DeleteConference(Conference conference);
    }
}
