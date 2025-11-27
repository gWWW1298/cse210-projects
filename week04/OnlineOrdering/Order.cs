using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }

    public double TotalCost()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.TotalCost();
        }

        // Add shipping
        total += _customer.LivesInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");

        foreach (Product p in _products)
        {
            sb.AppendLine($"Product: {p.GetName()} (ID: {p.GetID()})");
        }

        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
