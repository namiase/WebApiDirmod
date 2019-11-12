using System.Net.Http;
using System.Web;

namespace Common.Extensions
{
    public static class HeaderExtensions
    {
        public static HttpRequestMessage CopyHeadersFrom(HttpRequestBase request)
        {
            System.Net.Http.HttpRequestMessage message = new System.Net.Http.HttpRequestMessage();
            if (request != null)
            {
                foreach (string headerName in request.Headers)
                {
                    string[] headerValues = request.Headers.GetValues(headerName);
                    if (!message.Headers.TryAddWithoutValidation(headerName, headerValues))
                    {
                        if (message.Content != null)
                            message.Content.Headers.TryAddWithoutValidation(headerName, headerValues);
                    }
                }
                foreach (string cookieName in request.Cookies)
                {
                    HttpCookie cookieValues = request.Cookies[cookieName];

                    if (!message.Headers.TryAddWithoutValidation(cookieName, cookieValues.Value))
                    {
                        if (message.Content != null)
                            message.Content.Headers.TryAddWithoutValidation(cookieName, cookieValues.Value);
                    }
                }
            }
            return message;
        }
    }
}
