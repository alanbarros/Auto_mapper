using AutoMapper;
using System;

namespace CMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDto>()
                   .ReverseMap();
            });

            var mapper = configuration.CreateMapper();

            var customer = new Customer
            {
                Name = "Bob"
            };

            var order = new Order
            {
                Customer = customer,
                Total = 15.8m
            };

            var orderDto = mapper.Map<Order, OrderDto>(order);

            orderDto.CustomerName = "Joe";

            mapper.Map(orderDto, order);
        }
    }
    public class Order
    {
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
    public class OrderDto
    {
        public decimal Total { get; set; }
        public string CustomerName { get; set; }
    }
}
