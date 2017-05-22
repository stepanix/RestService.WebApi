

namespace RestService.WebApi.RequestIdentity
{
    public interface IRequestIdentityProvider
    {
        string UserId { get; set; }
        string UserName { get; }
    }
}
