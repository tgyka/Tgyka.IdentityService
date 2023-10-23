namespace Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
