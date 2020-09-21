using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;
using Orders.Type;

namespace Orders.Schema
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