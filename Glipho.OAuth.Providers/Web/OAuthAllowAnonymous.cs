namespace Glipho.OAuth.Providers.Web
{
    using System.Web.Http.Filters;

    /// <summary>
    /// Allows anonymous OAuth requests.
    /// </summary>
    public class OAuthAllowAnonymous : ActionFilterAttribute
    {
    }
}
