public class FoodPackage
{
    public string Name { get; set; }
    public double Price { get; set; }

    public FoodPackage(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name}: ${Price}";
    }
}