class Program
{
    public static Car? myCar;
    public static void Main()
    {
        Console.WriteLine("GPA's CLI car factory simulator \nFor simulating the concept of interfaces\n\n");

        while (true)
        {
            ConsoleKeyInfo option;
            Console.WriteLine
            (
                "\nSelect an action: \n" +
                "1. Get a new Car \n" +
                "2. Drive your car \n" +
                "3. Refuel/Recharge your car \n" +
                "4. Quit"
            );

            option = Console.ReadKey(intercept: true);

            if (option.Key == ConsoleKey.D1)
            {
                GetNewCarUI();
            }
            else if (option.Key == ConsoleKey.D2)
            {
                DriveCarUI();
            }
            else if (option.Key == ConsoleKey.D3)
            {
                RefreshCarUI();
            }
            else if (option.Key == ConsoleKey.D4)
            {
                break;
            }
        }

    }

    public static void GetNewCarUI()
    {
        Console.WriteLine
        (
            "\nSelect your car type: \n" +
            "1. Internal Combustion Vehicle \n" +
            "2. Electric Vehicle \n" +
            "3. Hybrid Vehicle"
        );
        ConsoleKeyInfo option = Console.ReadKey(intercept: true);

        switch (option.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("Internal Combustion Vehicle Selected \n");
                myCar = CarFactory.GetCar(CarType.ICE);
                break;
            case ConsoleKey.D2:
                Console.WriteLine("Electric Vehicle Selected \n");
                myCar = CarFactory.GetCar(CarType.EV);
                break;
            case ConsoleKey.D3:
                Console.WriteLine("Hybrid Vehicle Selected \n");
                myCar = CarFactory.GetCar(CarType.Hybrid);
                break;
        }
    }

    public static void DriveCarUI()
    {
        if (myCar is null)
        {
            Console.WriteLine("You have not picked your car yet");
        }
        else
        {
            myCar.Drive();
        }
    }

    public static void RefreshCarUI()
    {
        if (myCar is null)
        {
            Console.WriteLine("You have not picked your car yet");
        }
        else if (myCar is IElectricVehicle vehicle)
        {
            SendCarToChargingStation(vehicle);
        }
        else if (myCar is IInternalCombustionVehicle vehicle1)
        {
            SendCarToGasStation(vehicle1);
        }
    }
    public static void SendCarToChargingStation(IElectricVehicle EV)
    {
        EV.Recharge();
    }

    public static void SendCarToGasStation(IInternalCombustionVehicle ICE)
    {
        ICE.Refuel();
    }
}