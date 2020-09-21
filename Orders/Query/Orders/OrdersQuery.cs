using GraphQL;
using GraphQL.Types;
using Orders.Services;
using Orders.Type;

namespace Orders.Query
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