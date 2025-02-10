namespace Core.Persistence.Repository;

public interface IQuery<T>
{
    IQueryable<T> Query();
}