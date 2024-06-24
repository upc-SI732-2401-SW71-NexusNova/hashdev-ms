using UserManagerService.Models;

namespace UserManagerService.Data.Repositories
{
    public interface IProfileRepository
    {
        bool SaveChanges();
        IEnumerable<Profile> GetAllProfiles();
        Profile GetProfileById(int id);
        Profile CreateProfile(Profile profile);
        void UpdateProfile(int id, Profile profile);
        void DeleteProfile(Profile profile);
    }
}
