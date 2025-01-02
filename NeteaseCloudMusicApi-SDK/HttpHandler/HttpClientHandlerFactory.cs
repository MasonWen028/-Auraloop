using System.Net;
using System.Net.Http;

namespace NeteaseCloudMusicApi_SDK.HttpHandler
{
    public class HttpClientHandlerFactory
    {
        public static HttpClientHandler CreateHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
        }
    }
}
