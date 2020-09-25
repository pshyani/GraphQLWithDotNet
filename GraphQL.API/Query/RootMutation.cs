using System;
using GraphQL;
using GraphQL.Types;
using GraphQl.API.Models;
using GraphQl.API.Services;
using GraphQl.API.Type;

namespace GraphQl.API.Schema
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