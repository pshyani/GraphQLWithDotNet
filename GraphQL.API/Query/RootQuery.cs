using GraphQL;
using GraphQL.Types;
using GraphQl.API.Services;
using GraphQl.API.Type;

namespace GraphQl.API.Query
{
    public class RootQuery : ObjectGraphType
    {
         public RootQuery()
        {           
            Name = "RootQuery";
            Field<OrdersQuery>("orders", resolve: context => new {});
            Field<CustomerQuery>("customers", resolve: context => new {});
        }
    }
}