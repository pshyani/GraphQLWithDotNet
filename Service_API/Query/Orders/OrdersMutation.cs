using System;
using GraphQL;
using GraphQL.Types;
using Service_API.Models;
using Service_API.Services;
using Service_API.Type;

namespace Service_API.Schema
{
    public class OrdersMutation : ObjectGraphType
    {
        public OrdersMutation(IOrderService orderService)
        {
            Name="Mutation";
            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>>{ Name = "order"}),
                resolve: context => {
                    var orderInput = context.GetArgument<OrderCreateInput> ("order");
                    var id = Guid.NewGuid().ToString();
                    var order = new Order(orderInput.Name, orderInput.Description, 
                                          orderInput.Created, orderInput.CustomerId, id);
                    return orderService.CreateAsync(order);
                }
            );

            FieldAsync<OrderType>(
                "startOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name="orderId"}),
                resolve: async context => {
                    var orderId = context.GetArgument<string>("orderId");
                    return await orderService.StartAsync(orderId);
                    // return await context.TryAsyncResolve(
                    //     async c => await orderService.StartAsync(orderId)
                    // );
                }
            );
        }
    }
}