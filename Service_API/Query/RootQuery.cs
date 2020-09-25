using GraphQL;
using GraphQL.Types;
using Service_API.Services;
using Service_API.Type;

namespace Service_API.Query
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