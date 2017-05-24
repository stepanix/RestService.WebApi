using RestService.Domain.Core;
using RestService.Domain.Entity.Base;
using System;


namespace RestService.Domain.Entity
{
    public class BaseEntity : Entity<int>, ISoftDelete
    {
        public BaseEntity()
        {
            AddedDate = DateTime.UtcNow;
            IsActive = true;
            IsDeleted = false;
        }

        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
