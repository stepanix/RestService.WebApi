
using RestService.Domain.Core;
using System;

namespace RestService.Domain.Entity.Base
{
    public abstract class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>, ISoftDelete
    {
        public virtual TPrimaryKey Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }       
        public bool IsDeleted { get; set; }
        private bool IsActive { get; set; }
    }
}
