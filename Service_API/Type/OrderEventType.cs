using GraphQL.Types;
using Service_API.Models;

namespace Service_API.Type
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