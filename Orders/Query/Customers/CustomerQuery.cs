using GraphQL;
using GraphQL.Types;
using Orders.Services;
using Orders.Type;

namespace Orders.Query
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(ICustomerService customers)
        {           
            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customers.GetCustomersAsync()
            );

            Field<CustomerType>(
                "customersById",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    return customers.GetCustomerByIdAsync(id);
                }
            );
        }
    }
}