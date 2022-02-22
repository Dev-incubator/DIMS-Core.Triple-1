using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUSerProfileRepositoryFixture : ViewRepositoryFixture<VUserProfileRepository>
    {
        public int VUserProfileId { get; private set; }

        protected override VUserProfileRepository CreateRepository() => new VUserProfileRepository(Context);
    }
}
