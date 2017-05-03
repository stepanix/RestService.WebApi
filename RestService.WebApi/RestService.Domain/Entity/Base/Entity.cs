
using RestService.Domain.Core;

namespace RestService.Domain.Entity.Base
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
