using GrpcService;
using static GrpcService.Greeter;

namespace Micro.Services.ACC.GrpcServices
{
    public class GreatGrpcService
    {
        private readonly GreeterClient _GreeterClient;

        public GreatGrpcService(GreeterClient GreeterClient)
        {
            _GreeterClient = GreeterClient;
        }

        public async Task<HelloArrayReply> SayHello(string request)
        {
            var param = new HelloRequest() { Name = request };
            return _GreeterClient.SayHello(param);
        }
      
    }
}
