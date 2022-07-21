using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task<HelloArrayReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var result = new HelloArrayReply();
            result.Familly = "hassanabadi";
            result.Name = "mohammad";
            result.Mob = "0912";

            return result;
        }
    }
}