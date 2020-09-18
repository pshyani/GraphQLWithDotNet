using GraphQL;
using GraphQL.Types;
using Orders.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Orders.Query;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(IOrderService order, IOrderEventService eventService, IServiceProvider provider) : base(provider)
        {
            Query = new OrdersQuery(order);
            Mutation = new OrdersMutation(order);           
            Subscription = new OrdersSubscription(eventService);           
        }
    }
}