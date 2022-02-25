using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class SampleRepositoryFixture : RepositoryFixture<IRepository<Sample>>
    {
        public int SampleId { get; private set; }

        protected override SampleRepository CreateRepository() => new SampleRepository(Context);

        protected override void InitDatabase()
        {
            var entry = Context.Samples.Add(new Sample()
            {
                Name = "Test Name",
                Description = "Test Description"
            });
            SampleId = entry.Entity.SampleId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}