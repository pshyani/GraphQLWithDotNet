using GraphQL.Types;
using Service_API.Models;

namespace Service_API.Type
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