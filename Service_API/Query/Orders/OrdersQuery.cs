using GraphQL;
using GraphQL.Types;
using Service_API.Services;
using Service_API.Type;

namespace Service_API.Query
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