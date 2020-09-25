using System;
using GraphQL;
using GraphQL.Types;
using Service_API.Models;
using Service_API.Services;
using Service_API.Type;

namespace Service_API.Schema
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Name = "RootMutation";
            Field<OrdersMutation>("orders", resolve: context => new {});
            //Field<CustomerQuery>("customers", resolve: context => new {});
        }        
    }
}