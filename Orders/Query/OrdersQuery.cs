using GraphQL.Types;
using Orders.Services;
using Orders.Type;

namespace Orders.Query
{
    public class OrdersQuery : ObjectGraphType
    {
        public OrdersQuery(IOrderService orders)
        {           
            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => orders.GetOrdersAsync()
            );
        }
    }
}