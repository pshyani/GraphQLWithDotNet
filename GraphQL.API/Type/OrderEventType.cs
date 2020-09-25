using GraphQL.Types;
using GraphQl.API.Models;

namespace GraphQl.API.Type
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.OrderId);
            Field<OrderStatusesEnum>("status", 
                resolve: context => context.Source.Status);
            Field(e => e.Timestamp);
        }
    }
}