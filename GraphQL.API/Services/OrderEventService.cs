using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GraphQl.API.Models;

namespace GraphQl.API.Services
{
    public interface IOrderEventService
    {
         ConcurrentStack<OrderEvent> AllEvents {get; }
         void AddError(Exception exception);
         OrderEvent AddEvent(OrderEvent orderEvent);
         IObservable<OrderEvent> EventStream();
    }
    public class OrderEventService : IOrderEventService
    {
        private readonly ISubject<OrderEvent> _eventStram = new ReplaySubject<OrderEvent>(1);        
        public ConcurrentStack<OrderEvent> AllEvents {get; }
        public OrderEventService()
        {
            AllEvents = new ConcurrentStack<OrderEvent>();
        }   
        public void AddError(Exception exception)
        {
            _eventStram.OnError(exception);
        }
        public OrderEvent AddEvent(OrderEvent orderEvent)
        {
            AllEvents.Push(orderEvent);
            _eventStram.OnNext(orderEvent);
            return orderEvent;
        }

        public IObservable<OrderEvent> EventStream()
        {
            return _eventStram.AsObservable();
        }
    }
}