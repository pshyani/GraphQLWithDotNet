using GraphQL;
using GraphQL.Types;
using Orders.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(IOrderService order,  IServiceProvider provider) : base(provider)
        {
            Query = new OrdersQuery(order);
            //Mutation = new ChatMutation(chat);
            //Subscription = new ChatSubscriptions(chat);
        }
    }
}