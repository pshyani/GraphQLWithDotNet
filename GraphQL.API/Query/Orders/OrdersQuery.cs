using GraphQL;
using GraphQL.Types;
using GraphQl.API.Services;
using GraphQl.API.Type;

namespace GraphQl.API.Query
{
    public class OrdersQuery : ObjectGraphType
    {
        public OrdersQuery(IOrderService orders)
        {      
            Name = "OrderQuery";    
            Field<ListGraphType<OrderType>>(
                name: "orders",                
                resolve: context => orders.GetOrdersAsync()
            );

            Field<OrderType>(
                "ordersById",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => {
                     var id = context.GetArgument<string>("id");
                     return orders.GetOrderByIdAsync(id);
                }
            );
        }
    }
}