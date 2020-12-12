using System;
using Cars.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cars.Test.Integration
{
    public class IntegrationTest : IDisposable
    {
        protected readonly DatabaseContext db;
        
        public IntegrationTest()
        {
            this.db = SetUpContext();
        }

        DatabaseContext SetUpContext() =>
            new DatabaseContext(
                new DbContextOptionsBuilder<DatabaseContext>()
                    .UseInMemoryDatabase("Integration")
                    .Options);

        public void Dispose()
        {
            this.db.Database.EnsureDeleted();
            this.db.Dispose();
        }
    }
}