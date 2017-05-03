using RestService.Domain.Core;
using RestService.Domain.Entity.Base;
using System;


namespace RestService.Domain.Entity
{
    public abstract class BaseEntity : Entity<int>, ISoftDelete
    {
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
