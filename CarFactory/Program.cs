class Program{
    public static void Main(){
        Car myNewCar = CarFactory.GetCar(CarType.Hybrid);

        myNewCar.Drive();
        myNewCar.Drive();
        myNewCar.Drive();
        myNewCar.Drive();
        myNewCar.Drive();
        myNewCar.Honk();
        SendCarToChargingStation((IElectricVehicle) myNewCar);
        myNewCar.Drive();
    }

    public static void SendCarToChargingStation(IElectricVehicle EV){
        EV.Recharge();
    }

    public static void SendCarToGasStation(IInternalCombustionVehicle ICE){
        ICE.Refuel();
    }
}