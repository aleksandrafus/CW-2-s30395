namespace ContainerLoadingApp;

public class LiquidContainer(double height, double weight, double depth, double maxCapacity, bool isHazardous) 
    : Container(height, weight, depth, maxCapacity, "L") , IIHazardNotifier
{

    public bool IsHazardous { get; } = isHazardous;
    
    public void NotifyAboutDanger() => Console.WriteLine($"Warning! Dangerous situation happened! Container number:{SerialNumber}");

    public override void LoadCargo(double cargoMass)
    {
        double limit = isHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
        if (cargoMass > limit)
            throw new OverfillException($"Liquid cargo exceeded allowed limit of {limit}kg.");
    }
    
}