using System.Threading.Tasks;
using MassTransit;
using TestTemplate11.Core.Events;

namespace TestTemplate11.WorkerServices.FooService
{
    public class FooConsumer : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context) =>
            Task.CompletedTask;
    }
}
