using System.Reflection;

namespace PinoyCode.Cqrs
{
    public interface IMessageDispatcher
    {
        void AddHandlerFor<TCommand, TAggregate>() where TAggregate : Aggregate;
        void AddSubscriberFor<TEvent>(ISubscribeTo<TEvent> subscriber);
        void ScanAssembly(Assembly ass);
        void ScanInstance(object instance);
        void SendCommand<TCommand>(TCommand c);
    }
}