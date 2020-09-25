using GraphQL;
using GraphQL.Types;
using Service_API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Service_API.Query;

namespace Service_API.Schema
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