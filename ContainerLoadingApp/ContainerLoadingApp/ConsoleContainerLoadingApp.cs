namespace ContainerLoadingApp;

public class ConsoleContainerLoadingApp
{
    private static List<ContainerShip> _containerShips = new List<ContainerShip>();
    private static List<Container> _containers = new List<Container>();
    
    public static void StartApp()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("===============================================");
            Console.Write("\nContainer ship list: ");
            PrintList(_containerShips);
    
            
            Console.Write("\nContainer list: ");
            PrintList(_containers);
            Console.WriteLine();

            PrintPossibleActions();

            
            var userInput = Console.ReadLine();

            switch (userInput?.Trim())
            {
                case "1":
                    AddContainerShip();
                    break;
                
                case "2":
                    if (_containerShips.Count == 0) continue;
                    RemoveContainerShip();
                    break;
                
                case "3":
                    if (_containerShips.Count == 0) continue;
                    AddContainer();
                    break;
                
                case "exit":
                    running = false;
                    break;
                
                default: 
                    Console.WriteLine("\nInvalid input");
                    continue;
            }
            
        }
    }

    private static void PrintList<T>(List<T> list)
    {
        if( list.Count == 0 )
        {
            Console.WriteLine("\nEmpty");
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\n{i+1}  {list[i]}");
            }
        }
    }

    private static void PrintPossibleActions()
    {
        if (_containerShips.Count == 0 && _containers.Count == 0)
        {
            Console.WriteLine("""
                              1 - Add a container ship
                              exit - end the program
                              """);
        }
        else
        {
            Console.WriteLine("""
                              1 - Add a container ship
                              2 - Remove a container ship
                              3 - Add a container
                              exit - end the program
                              """);
        }
    }

    private static void AddContainerShip()
    {
        Console.WriteLine("\nEnter the maximum speed of the container ship: ");
        double.TryParse(Console.ReadLine(), out double maxSpeed);
        Console.WriteLine("\nEnter the maximum capacity of the container ship: ");
        int.TryParse(Console.ReadLine(), out int maxCapacity);
        Console.WriteLine("\nEnter the maximum weight of the container ship: ");
        double.TryParse(Console.ReadLine(), out double maxweight);
        
        _containerShips.Add(new ContainerShip(maxSpeed, maxCapacity, maxweight));
        
        Console.WriteLine("\nContainer ship added");
    }
    
    private static void RemoveContainerShip()
    {
        PrintList(_containerShips);
        Console.WriteLine("\nEnter the number of the container ship you want to remove: ");
        int.TryParse(Console.ReadLine(), out int containerShipNumber);
        
        _containerShips.Remove(_containerShips[containerShipNumber - 1]);
        
        Console.WriteLine("\nContainer ship removed");
    }
    
    private static void AddContainer()
    {
        PrintList(_containerShips);
        
        Console.WriteLine("\nEnter the number of the container ship you want to add a container to: ");
        
        int.TryParse(Console.ReadLine(), out int containerShipNumber);
        
        
        Console.WriteLine("""
                          
                          Enter the type of the container: 
                            Liquid - L
                            Gas - G 
                            Cooling - C 
                          """);
        
        char.TryParse(Console.ReadLine(), out char containerType);

        
        Console.WriteLine("\nEnter the height of the container: ");
        double.TryParse(Console.ReadLine(), out double containerHeight);
        
        Console.WriteLine("\nEnter the weight of the container: ");
        double.TryParse(Console.ReadLine(), out double containerWeight);
        
        Console.WriteLine("\nEnter the depth of the container: ");
        double.TryParse(Console.ReadLine(), out double containerDepth);
        
        Console.WriteLine("\nEnter the maximum capacity of the container: ");
        double.TryParse(Console.ReadLine(), out double maxCapacity);
        
        
        switch (containerType)
        {
            case 'L':
                Console.WriteLine("\nEnter if the container is hazardous (0 - no ; 1 - yes): ");
                int.TryParse(Console.ReadLine(), out int isHazardousInputL);
                
                bool isHazardousL = isHazardousInputL == 1;
                
                _containerShips[containerShipNumber-1].AddContainers(
                    new LiquidContainer(containerHeight, containerWeight, containerDepth, 
                        maxCapacity, isHazardousL)
                    );
            
                break;
            
            case 'G':
                Console.WriteLine("\nEnter the pressure of the container: ");
                double.TryParse(Console.ReadLine(), out double containerPressure);
                
                Console.WriteLine("\nEnter if the container is hazardous (0 - no ; 1 - yes): ");
                int.TryParse(Console.ReadLine(), out int isHazardousInputG);
                
                bool isHazardousG = isHazardousInputG == 1;
                
                _containerShips[containerShipNumber-1].AddContainers(
                    new GasContainer(containerHeight, containerWeight, containerDepth, 
                        maxCapacity, containerPressure, isHazardousG)
                    );
            
                break;
            
            case 'C':
                Console.WriteLine("\nEnter the product type of the container: ");
                string? containerProductType = Console.ReadLine()?.Trim();
                
                Console.WriteLine("\nEnter the temperature of the container: ");
                double.TryParse(Console.ReadLine(), out double containerTemperature);

                _containerShips[containerShipNumber-1].AddContainers(
                    new CoolingContainer(containerHeight, containerWeight, containerDepth, 
                        maxCapacity, containerProductType ?? string.Empty, containerTemperature)
                    );
            
                break;
            
            default:
                Console.WriteLine("\nInvalid input");
                break;
        }
        
    }
    
}