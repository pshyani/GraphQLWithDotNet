using GraphQL;
using GraphQL.Types;
using Orders.Services;
using Orders.Type;

namespace Orders.Query
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