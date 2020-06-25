using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetroConnect.API.Common
{
    public class AuthFailureResult : IHttpActionResult
    {
        public string ResponseMessage { get; }
        public AuthFailureResult(string message)
        {
            ResponseMessage = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                StatusCode = HttpStatusCode.BadRequest,
                ReasonPhrase = ResponseMessage
            });
        }
    }
}
