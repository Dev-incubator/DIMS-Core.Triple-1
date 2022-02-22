using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUSerProfileRepositoryFixture : RepositoryFixture<VUserProfileRepository>
    {
        public int VUserProfileId { get; private set; }

        protected override VUserProfileRepository CreateRepository() => new VUserProfileRepository(Context);

        protected override void InitDatabase()
        {
            var entry = Context.VUserProfiles.Add(new VUserProfile()
            {
                Email = "Test Email",
                FullName = "Test Full Name"
            });
            VUserProfileId = entry.Entity.UserId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}
