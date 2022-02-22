using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class DirectionRepositoryFixture : RepositoryFixture<DirectionRepository>, IDisposable
    {
        public int DirectionId { get; private set; }

        protected override DirectionRepository CreateRepository() => new DirectionRepository(Context);

        protected override void InitDatabase()
        {
            var entry = Context.Directions.Add(new Direction()
            {
                Name = "Test Name",
                Description = "Test Description"
            });
            DirectionId = entry.Entity.DirectionId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}
