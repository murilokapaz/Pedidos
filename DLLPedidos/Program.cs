using System;
using DLLPedidos.Entities;
using DLLPedidos.Entities.Enums;
using System.Globalization;

namespace DLLPedidos {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter Client Data: ");
            Console.WriteLine("----------------");
            Console.Write($"Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("----------------");
            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            string status = Console.ReadLine();


            OrderStatus s = Enum.Parse<OrderStatus>(status);
            Client client = new Client();
            client.Name = name;
            client.Email = email;
            client.BirthDate = birthDate;

            Order order1 = new Order(DateTime.Now, s , client);


            Console.WriteLine();
            Console.Write("How many items to this order? ");
            int nItems = int.Parse(Console.ReadLine());

            for(int i=1; i<= nItems; i++) {

                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product Name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product();
                product.Name = nameProduct;


                OrderItem item = new OrderItem(quantity, price, product);
                order1.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMARY: ");
            Console.WriteLine(order1);
            Console.WriteLine($"Total: R${order1.Total()}");
        }
    }
}
