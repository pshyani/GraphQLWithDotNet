using GraphQL.Types;
using GraphQL.Subscription;
using GraphQL.Resolvers;
using Service_API.Services;
using Service_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using Service_API.Type;
using GraphQL;
//using GraphQL;

namespace Service_API.Query
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