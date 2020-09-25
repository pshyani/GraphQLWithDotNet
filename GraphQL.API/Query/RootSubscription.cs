using GraphQL.Types;
using GraphQL.Subscription;
using GraphQL.Resolvers;
using GraphQl.API.Services;
using GraphQl.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using GraphQl.API.Type;
using GraphQL;
//using GraphQL;

namespace GraphQl.API.Query
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