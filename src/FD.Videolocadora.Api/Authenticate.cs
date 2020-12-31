using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FD.Videolocadora.Api
{
    public class Authenticate : DelegatingHandler
    {
        public string Key { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage message)
        {
            var senhas = message.Headers.Where(a => a.Key == "ApiKey").FirstOrDefault();
            string senha = senhas.Value.FirstOrDefault();
            string Token = "senha";
            return (senha == Token);
        }
    }
}

