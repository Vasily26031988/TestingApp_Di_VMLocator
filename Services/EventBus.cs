using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp_Di_VMLocator.Services
{
    public interface IEvent
	{

	}

    public class EventBus
    {
        private ConcurrentDictionary<EventSubscriber, Func<IEvent, Task>> _subscribers;

        public EventBus()
		{
            _subscribers = new ConcurrentDictionary<EventSubscriber, Func<IEvent, Task>>();
		}

        public IDisposable Subscribe<T>(Func <T, Task> handler) where T : IEvent
		{
            var disposer = new EventSubscriber(typeof(T), s => _subscribers.TryRemove(s, out var _));
            _subscribers.TryAdd(disposer, (item) => handler((T)item));
            return disposer;
		}

        public async Task Publish<T>(T message) where T : IEvent
		{
            var messageType = typeof(T);

            var handlers = _subscribers
                .Where(s => s.Key.MessageType == messageType)
                .Select(s => s.Value(message));

            await Task.WhenAll(handlers);
		}
    }

	class EventSubscriber : IDisposable
	{
        private readonly Action<EventSubscriber> _action;

        public Type MessageType { get; }

        public EventSubscriber(Type messageType, Action<EventSubscriber> action)
		{
            MessageType = messageType;
            _action = action;
		}

		public void Dispose()
		{
            _action?.Invoke(this);
		}
	}

 //   class MessageSubscriber : IDisposable
	//{
 //       private readonly Action<MessageSubscriber> _action;

 //       public Type ReceiverType { get; }
 //       public Type MessageType { get; }

 //       public MessageSubscriber(Type receiverType, Type messageType, Action<MessageSubscriber> action)
	//	{
 //           ReceiverType = receiverType;
 //           MessageType = messageType;
 //           _action = action;
	//	}

 //       public void Dispose() 
 //       {
 //           _action?.Invoke(this); 
 //       }
	//}
}
