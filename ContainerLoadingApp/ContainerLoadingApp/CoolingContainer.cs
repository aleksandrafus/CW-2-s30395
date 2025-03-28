
namespace ContainerLoadingApp;

public class CoolingContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    
    
    public CoolingContainer(double height, double weight, double depth, double maxCapacity, string productType, double temperature)
        : base(height, weight, depth, maxCapacity, "C")  
    {
        ProductType = productType;
        Temperature = temperature;
        
        if(!IsTemperatureValid())
            throw new ArgumentException("Invalid product type. The temperature is not suitable for this product.");
    }
    
    
    public override void LoadCargo(Product product)
    {
        if (product.Weight + CargoMass > MaxCapacity)
        {
            throw new OverfillException();
        }
        else if (product.ProductType != ProductType)
        {
            throw new ArgumentException($"Product must be of type: {ProductType}");
        }
        
        CargoMass += product.Weight;
    }

    private bool IsTemperatureValid()
    {
        return ProductType switch
        {
            "Bananas" => Temperature >= 13.3,
            "Chocolate" => Temperature >= 18,
            "Fish" => Temperature >= 2,
            "Meat" => Temperature >= -15,
            "Ice cream" => Temperature >= -18,
            "Frozen pizza" => Temperature >= -30,
            "Cheese" => Temperature >= 7.2,
            "Sausages" => Temperature >= 5,
            "Butter" => Temperature >= 20.5,
            "Eggs" => Temperature >= 19,
            _ => false
        };
    }
    
    public override string ToString()
    {
        return $"""
                Container {SerialNumber}
                   Height: {Height}
                   Weight: {Weight}
                   Depth: {Depth}
                   MaxCapacity: {MaxCapacity}
                   Type: {Type}
                   Temperature: {Temperature}
                   ProductType: {ProductType}
                   Current CargoMass: {CargoMass}
                """;
    }
}