using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        
        //1st customer
        Address a1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer c1 = new Customer("John Smith", a1);
        Order order1 = new Order(c1);

        order1.AddProduct(new Product("Laptop", "L100", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M200", 25.50, 2));

        //2nd customer
        Address a2 = new Address("45 Rue de Lyon", "Paris", "Île-de-France", "France");
        Customer c2 = new Customer("Marie Dupont", a2);
        Order order2 = new Order(c2);

        order2.AddProduct(new Product("Headphones", "H300", 85.99, 1));
        order2.AddProduct(new Product("Keyboard", "K400", 45.00, 1));
        order2.AddProduct(new Product("USB Cable", "U500", 8.99, 3));

        //Display all
        Console.WriteLine("ORDER 1: ");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.TotalCost():0.00}\n");

        Console.WriteLine("ORDER 2: ");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.TotalCost():0.00}");
    }
}