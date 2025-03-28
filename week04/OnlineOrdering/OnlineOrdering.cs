using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetShippingAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;
    private bool isGift;
    private string giftMessage;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
        this.isGift = false;
        this.giftMessage = "";
    }

    public void SetGiftWrap(bool isGift, string giftMessage = "")
    {
        this.isGift = isGift;
        this.giftMessage = giftMessage;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35; 
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        if (isGift)
        {
            label += "\n-- Gift Wrapped Order --\n";
            if (!string.IsNullOrEmpty(giftMessage))
            {
                label += $"Gift Message: {giftMessage}\n";
            }
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetShippingAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT123", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "MS456", 19.99, 2));
        order1.SetGiftWrap(true, "Happy Birthday, enjoy your new tech!");

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "TBL789", 299.99, 1));
        order2.AddProduct(new Product("Keyboard", "KB101", 49.99, 1));
        order2.AddProduct(new Product("USB Cable", "USB202", 9.99, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
