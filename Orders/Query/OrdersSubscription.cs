using GraphQL.Types;
using GraphQL.Subscription;
using GraphQL.Resolvers;
using Orders.Services;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using Orders.Type;
//using GraphQL;

namespace Orders.Query
{
    public class OrdersSubscription : ObjectGraphType
    {
        private readonly IOrderEventService _events;

        public OrdersSubscription(IOrderEventService events)
        {
            _events = events;
           // Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "orderStatusEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<OrderStatusesEnum>>
                {
                    Name = "statuses"
                }),
                Type = typeof(OrderEventType),
                Resolver = new FuncFieldResolver<OrderEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<OrderEvent>(Subscribe)
            });
        }

        private OrderEvent ResolveEvent(IResolveFieldContext context)
        {
            var orderEvent = context.Source as OrderEvent;
            return orderEvent;
        }

        private IObservable<OrderEvent> Subscribe(IResolveEventStreamContext context)
        {
            // var statusList = context.GetArgument<IList<OrderStatuses>>("statuses", new List<OrderStatuses>());
            
            // if (statusList.Count > 0)
            // {
            //     OrderStatuses statuses = 0;

            //     foreach(var status in statusList)
            //     {
            //         statuses = statuses | status;
            //     }
            //     return _events.EventStream().Where(e => (e.Status & statuses) == e.Status);
            // }
            // else
            // {
            //     return _events.EventStream();
            // }

            return _events.EventStream().Where(e => (e.Status & 0) == e.Status);
        }
     
    }
}