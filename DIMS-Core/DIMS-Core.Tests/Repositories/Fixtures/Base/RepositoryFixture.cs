using DIMS_Core.DataAccessLayer.Context;
using System;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class RepositoryFixture<TRepository> : IDisposable
    {
        public DimsContext Context { get; }
        public TRepository Repository { get; }

        protected RepositoryFixture()
        {
            Context = ContextCreator.ContextCreator.CreateContext();
            Repository = CreateRepository();
            InitDatabase();
        }

        protected abstract void InitDatabase();

        protected abstract TRepository CreateRepository();

        public void Dispose() => Context.Dispose();
    }
}
