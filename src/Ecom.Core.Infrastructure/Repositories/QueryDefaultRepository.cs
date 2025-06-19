using EfCore.Repositories;
using Shared.Entities;
using Ecom.Core.Infrastructure.Persistence.EfCore;

namespace Ecom.Core.Infrastructure.Repositories;
public class QueryDefaultRepository<TEntity, TKey>(ApplicationDbContext dbContext)
    : QueryRepository<TEntity, TKey>(dbContext)
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
}
