using UserManagerService.Models;

namespace UserManagerService.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly UserManagerDbContext _context;

        public ProfileRepository(UserManagerDbContext context)
        {
            _context = context;
        }
        public Profile CreateProfile(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            _context.Profiles.Add(profile);
            return profile;
        }

        public void DeleteProfile(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            _context.Profiles.Remove(profile);
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile GetProfileById(int id)
        {
            var profile = _context.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            return profile;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProfile(int id, Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            var profileToUpdate = _context.Profiles.FirstOrDefault(p => p.Id == id);
            if (profileToUpdate == null)
            {
                throw new ArgumentNullException(nameof(profileToUpdate));
            }
            profileToUpdate.FullName = profile.FullName;
            profileToUpdate.Bio = profile.Bio;
            profileToUpdate.ProfilePictureUrl = profile.ProfilePictureUrl;
            profileToUpdate.Location = profile.Location;
            profileToUpdate.Website = profile.Website;
            profileToUpdate.Github = profile.Github;
            profileToUpdate.UserId = profile.UserId;
        }
    }
}
