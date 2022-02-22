using DIMS_Core.Tests.Repositories.Fixtures;
using System;

namespace DIMS_Core.Tests.Repositories
{
    public class VUSerProgressRepositoryTests: IDisposable
    {
        private readonly VUserProgressRepositoryFixture _fixture;

        public VUSerProgressRepositoryTests()
        {
            _fixture = new VUserProgressRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
