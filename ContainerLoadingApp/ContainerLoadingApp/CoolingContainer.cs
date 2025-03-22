using System.Diagnostics;

namespace ContainerLoadingApp;

public class CoolingContainer(double height, double weight, double depth, double maxCapacity, string productType, double temperature) 
    : Container(height, weight, depth, maxCapacity, "C") 
{
    public string ProductType { get; set; } = productType;
    public double Temperature { get; set; } = temperature;
    
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
        else if (IsTemperatureValid(product))
        {
            CargoMass += product.Weight;
        }
        else if (!IsTemperatureValid(product))
        {
            throw new ArgumentException($"Product needs different temperature. This containers temperature is {Temperature}");
        }
    }

    private bool IsTemperatureValid(Product product)
    {
        switch (product.ProductType)
        {
            case "Bananas":
                return Temperature >= 13.3;
            case "Chocolate":
                return Temperature >= 18;
            case "Fish":    
                return Temperature >= 2;
            case "Meat":
                return Temperature >= -15;
            case "Ice cream":
                return Temperature >= -18;
            case "Frozen pizza":
                return Temperature >= -30;
            case "Cheese":
                return Temperature >= 7.2;
            case "Sausages":
                return Temperature >= 5;
            case "Butter":
                return Temperature >= 20.5;
            case "Eggs":
                return Temperature >= 19;
            default:
                return false;
            
        };
        
    }
}