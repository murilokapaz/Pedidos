using System;
using System.Collections.Generic;
using System.Text;
using DLLPedidos.Entities.Enums;
using System.Globalization;

namespace DLLPedidos.Entities {
    class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();


        public Order() {}

        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item) {
            OrderItem.Add(item);
        }
        public void RemoveItem(OrderItem item) {
            OrderItem.Remove(item);
        }
        public double Total() {
            double total = new double();
            foreach(OrderItem o in OrderItem) {
                total += o.SubTotal();
            }
            return total;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order Moment: {Moment.ToLongDateString()}");
            sb.AppendLine($"Order Status: {Status}");
            sb.AppendLine($"Client: {Client.Name}   ({Client.BirthDate.ToShortDateString()}) - {Client.Email}");
            sb.AppendLine("Order Items:");
            foreach (OrderItem o in OrderItem) {
                sb.AppendLine($"{o.Product.Name}, R${o.Price}, Quantity: {o.Quantity}, SubTotal: R${o.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }
            return sb.ToString();
        }
    }
}
