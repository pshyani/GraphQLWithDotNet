using GraphQL.Types;
using GraphQl.API.Models;

namespace GraphQl.API.Type
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field( c => c.Id);
            Field( c => c.Name);
        }
    }
}