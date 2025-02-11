using System.Linq.Expressions;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repository;

public interface IRepository<TEntity,TEntityId>:IQuery<TEntity>
where TEntity : Entity<TEntityId>
{
    TEntity Get(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool withDeleted = false,
        bool enableTracking = true
        );

    Paginate<TEntity> GetList(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true
        );

    Paginate<TEntity> GetListByDynamic(
        DynamicQuery dynamicQuery,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true
        );
    
    bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true);
    TEntity Add(TEntity entity);
    IList<TEntity> AddRange(IList<TEntity> entities);
    TEntity Update(TEntity entity);
    IList<TEntity> UpdateRange(IList<TEntity> entities);
    TEntity Delete(TEntity entity);
    IList<TEntity> DeleteRange(IList<TEntity> entities);
}