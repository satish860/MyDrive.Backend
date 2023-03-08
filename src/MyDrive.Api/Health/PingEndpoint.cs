using FastEndpoints;

namespace MyDrive.Api.Health
{
    public class PingEndpoint : Endpoint<EmptyRequest>
    {
        private const string Response = "Pong";

        public override void Configure()
        {
            Get("/api/ping");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            await SendAsync(Response, statusCode: 200, ct);
        }
    }
}
