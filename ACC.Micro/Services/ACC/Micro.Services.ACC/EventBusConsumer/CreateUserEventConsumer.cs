using ACC.Bus.Common.Events;
using MassTransit;

namespace Micro.Services.ACC.EventBusConsumer
{
    public class CreateUserEventConsumer : IConsumer<UserCreateEvent>
    {
        public async Task Consume(ConsumeContext<UserCreateEvent> context)
        {

        }
    }
}
