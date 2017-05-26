

namespace RestService.Domain.Core
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
