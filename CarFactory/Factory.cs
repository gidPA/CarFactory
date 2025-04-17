enum CarType
{
    EV,
    ICE,
    Hybrid
}

interface IElectricVehicle
{
    void Recharge();
}

interface IInternalCombustionVehicle
{
    void Refuel();
}

class Car
{
    public virtual void Drive()
    {

    }
    public void Honk()
    {
        Console.WriteLine("Honk Honk!");
    }
}

static class CarFactory
{
    class RealCarICE : Car, IInternalCombustionVehicle
    {
        private int FuelPercentage = 100;

        public void Refuel()
        {
            FuelPercentage = 100;
            Console.WriteLine("Your car is now refueled");
        }

        public override void Drive()
        {
            if (FuelPercentage <= 0)
            {
                Console.WriteLine("You're running out of fuel");
            }
            else
            {
                FuelPercentage -= 25;
                Console.WriteLine("Vroom....");
                Console.WriteLine("Your Fuel Percentage is: {0}", FuelPercentage);
            }

        }
    }

    class RealCarEV : Car, IElectricVehicle
    {
        private int BatteryPercentage = 100;

        public void Recharge()
        {
            BatteryPercentage = 100;
            Console.WriteLine("Your car is now fully charged");
        }

        public override void Drive()
        {
            if (BatteryPercentage <= 0)
            {
                Console.WriteLine("You're running out of battery power.");
            }
            else
            {
                BatteryPercentage -= 25;
                Console.WriteLine("Woosh....");
                Console.WriteLine("Your Battery Percentage is: {0}", BatteryPercentage);
            }

        }
    }

    class RealCarHybrid : Car, IElectricVehicle, IInternalCombustionVehicle
    {
        private int FuelPercentage = 100;
        private int BatteryPercentage = 100;

        public void Refuel()
        {
            Console.WriteLine("Your car is now refueled");
            FuelPercentage = 100;
        }

        public void Recharge()
        {
            Console.WriteLine("Your car is now fully charged");
            BatteryPercentage = 100;
        }

        public override void Drive()
        {
            if (BatteryPercentage <= 0 && FuelPercentage <= 0)
            {
                Console.WriteLine("You're running out of fuel and battery power");
            }
            else if (BatteryPercentage <= 0)
            {
                FuelPercentage -= 25;
                Console.WriteLine("Vroom....");
                Console.WriteLine("Your Fuel Percentage is: {0}", FuelPercentage);
            }
            else
            {
                BatteryPercentage -= 25;
                Console.WriteLine("Woosh....");
                Console.WriteLine("Your Battery Percentage is: {0}", BatteryPercentage);
            }
        }
    }

    public static Car? GetCar(CarType type)
    {
        return type switch
        {
            CarType.ICE => new RealCarICE(),
            CarType.EV => new RealCarEV(),
            CarType.Hybrid => new RealCarHybrid(),
            _ => null,
        };

    }

}