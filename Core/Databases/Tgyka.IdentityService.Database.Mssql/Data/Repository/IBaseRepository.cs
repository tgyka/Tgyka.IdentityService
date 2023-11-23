using Tgyka.IdentityService.Database.Mssql.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tgyka.IdentityService.Database.Mssql.Data.Enum;
using Tgyka.IdentityService.Database.Mssql.Model;

namespace Tgyka.IdentityService.Database.Mssql.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        int Count(Expression<Func<TEntity, bool>> predicate = null, List<Expression<Func<TEntity, object>>> includes = null, Expression<Func<TEntity, object>> orderBySelector = null, bool isDescending = false);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, List<Expression<Func<TEntity, object>>> includes = null, Expression<Func<TEntity, object>> orderBySelector = null, bool isDescending = false, int page = 0, int size = 0);
        PaginationModel<TMapped> GetAllMapped<TMapped>(Expression<Func<TEntity, bool>> predicate = null, List<Expression<Func<TEntity, object>>> includes = null, Expression<Func<TEntity, object>> orderBySelector = null, bool isDescending = false, int page = 0, int size = 0);
        TEntity GetOne(Expression<Func<TEntity, bool>> predicate = null, List<Expression<Func<TEntity, object>>> includes = null, Expression<Func<TEntity, object>> orderBySelector = null, bool isDescending = false);
        TMapped GetOneMapped<TMapped>(Expression<Func<TEntity, bool>> predicate = null, List<Expression<Func<TEntity, object>>> includes = null, Expression<Func<TEntity, object>> orderBySelector = null, bool isDescending = false);
        IQueryable<TEntity> Query();
        Task<TMapped> SetAndCommit<TRequest, TMapped>(TRequest request, EntityCommandType type, int? userId = null);
        Task<List<TMapped>> SetAndCommit<TRequest, TMapped>(List<TRequest> requests, EntityCommandType type, int? userId = null);
        void SetEntityState(TEntity entity, EntityCommandType type, int? userId = null);
        void SetEntityState(IEnumerable<TEntity> entitites, EntityCommandType type, int? userId = null);
    }
}
