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
using GraphQL;
//using GraphQL;

namespace Orders.Query
{
    public class RootSubscription : ObjectGraphType
    {
        public RootSubscription()
        {
            Name = "RootSubscription";
            Field<OrdersSubscription>("orders", resolve: context => new {});
        }        
    }
}