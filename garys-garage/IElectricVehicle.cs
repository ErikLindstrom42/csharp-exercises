namespace garys_garage {
    public interface IElectricVehicle
    {
        int CurrentChargePercentage {get;set;}

        public void ChargeBattery() {
            CurrentChargePercentage = 100;
        }
    }

}