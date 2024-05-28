namespace TechGamer.Web.Services
{
    public interface IUserService
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAuthenticated();
        HttpContext GetHttpContext();
    }
}
