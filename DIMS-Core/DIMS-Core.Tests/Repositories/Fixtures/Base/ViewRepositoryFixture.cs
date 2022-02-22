using DIMS_Core.DataAccessLayer.Context;
using System;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class ViewRepositoryFixture<TRepository> : IDisposable
    {
        public DimsContext Context { get; }
        public TRepository Repository { get; }

        protected ViewRepositoryFixture()
        {
            Context = ContextCreator.ContextCreator.CreateContext();
            Repository = CreateRepository();
        }

        protected abstract TRepository CreateRepository();

        public void Dispose() => Context.Dispose();
    }
}
