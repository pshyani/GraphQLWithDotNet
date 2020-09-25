using GraphQL.Types;

namespace GraphQl.API.Type
{
    public class OrderCreateInputType : InputObjectGraphType
    {
        public OrderCreateInputType()
        {
            Name="OrderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<IntGraphType>>("customerId");
            Field<NonNullGraphType<DateTimeGraphType>>("created");           
        }
    }
}