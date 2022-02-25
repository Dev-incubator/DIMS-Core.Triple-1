using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserProgressRepositoryFixture : RepositoryFixture<IReadOnlyRepository<VUserProgress>>
    {
        public int VUserProgressId { get; private set; }

        protected override VUserProgressRepository CreateRepository() => new VUserProgressRepository(Context);

        protected override void InitDatabase()
        {
            var entry = Context.VUserProgresses.Add(new VUserProgress()
            {
                TaskName = "Test Name"
            });
            VUserProgressId = entry.Entity.UserId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}
