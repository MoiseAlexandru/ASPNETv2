using ASPNETv2.Data;
using ASPNETv2.Models;

namespace ASPNETv2.Helper.Seeders
{
    public class ProfileSeeder
    {
        public readonly DatabaseContext _databaseContext;
        public ProfileSeeder(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void SeedInitialProfiles()
        {
            if(!_databaseContext.Profiles.Any())
            {
                var profile1 = new Profile
                {
                    Username = "moise_alexandru",
                    FirstName = "Moise",
                    LastName = "Alexandru"
                };
                var profile2 = new Profile
                {
                    Username = "popescuandrei"
                    FirstName = "Popescu",
                    LastName = "Andrei"
                };
                _databaseContext.Add(profile1);
                _databaseContext.Add(profile2);
                _databaseContext.SaveChanges();
            }
        }
    }
}
