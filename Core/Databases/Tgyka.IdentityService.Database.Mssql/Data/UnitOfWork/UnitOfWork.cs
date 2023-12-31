﻿namespace Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MssqlDbContext _dbContext;

        public UnitOfWork(MssqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CommitAsync() => _dbContext.SaveChangesAsync();

    }
}
