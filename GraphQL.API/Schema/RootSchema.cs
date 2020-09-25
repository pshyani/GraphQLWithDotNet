using GraphQL;
using GraphQL.Types;
using GraphQl.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using GraphQl.API.Query;

namespace GraphQl.API.Schema
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