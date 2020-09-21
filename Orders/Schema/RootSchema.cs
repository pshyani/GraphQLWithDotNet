using GraphQL;
using GraphQL.Types;
using Orders.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Orders.Query;

namespace Orders.Schema
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider provider) : base(provider)
        {
            Query = new RootQuery();            
            Mutation = new RootMutation();           
            Subscription = new RootSubscription();  
        }
    }
}