using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class UserProfileRepositoryFixture : RepositoryFixture<IRepository<UserProfile>>
    {
        public int UserProfileId { get; private set; }

        protected override UserProfileRepository CreateRepository() => new UserProfileRepository(Context);

        protected override void InitDatabase()
        {
            var entry = Context.UserProfiles.Add(new UserProfile()
            {
                Email = "Test Email",
                FirstName = "Test First Name",
                LastName = "Test Last Name"
            });
            UserProfileId = entry.Entity.UserId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}
