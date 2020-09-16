using GraphQL.Types;

namespace Orders.Schema
{
    public class OrderStatusesEnum : EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            Name="OrderStatuses";
            AddValue("CREATED", "Order was Created", 2);
            AddValue("PROCESSING", "Order was Processed", 4);
            AddValue("COMPLETED", "Order was Completed", 8);
            AddValue("CANCELLED", "Order was Cancelled", 16);
            AddValue("CLOSED", "Order was Closed", 32);
        }
    }
}