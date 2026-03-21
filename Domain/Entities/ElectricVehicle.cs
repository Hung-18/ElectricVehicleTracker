using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ElectricVehicle
    {
        [Key]
        public Guid ElectricVehicleId { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public double BatteryCapacity { get; private set; }
        public double RangePerCharge { get; private set; }
        public double ChargingTime { get; private set; }
        public int StateOfHealth { get; private set; }
        public int CurrentOdometer { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public bool IsActive { get; private set; }
        public User User { get; private set; }
        public Guid TypeId { get; private set; }
        public Guid UserId {  get; private set; }
        public ElectricVehicleType Type { get; private set; }
        public ICollection<RepairHistory> RepairHistories { get; private set; }

        public ElectricVehicle()
        {
        }

        public ElectricVehicle(Guid electricVehicleId, string brand, string model, int year, double batteryCapacity, double rangePerCharge, double chargingTime, int stateOfHealth, int currentOdometer, DateTime createAt, DateTime updateAt)
        {
            ElectricVehicleId = Guid.NewGuid();

            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentException("Brand cannot be empty.");
            }
            Brand = brand;
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException("Model cannot be empty.");
            }
            Model = model;
            if (year > DateTime.Now.Year)
            {
                throw new ArgumentException("Year cannot be in the future.");
            }
            Year = year;
            if (batteryCapacity <= 0)
            {
                throw new ArgumentException("Battery capacity must be greater than zero.");
            }
            BatteryCapacity = batteryCapacity;
            if (rangePerCharge <= 0)
            {
                throw new ArgumentException("Range per charge must be greater than zero.");
            }
            RangePerCharge = rangePerCharge;
            if (chargingTime <= 0)
            {
                throw new ArgumentException("Charging time must be greater than zero.");
            }
            ChargingTime = chargingTime;
            if (stateOfHealth < 0 || stateOfHealth > 100)
            {
                throw new ArgumentException("State of health must be between 0 and 100.");
            }
            StateOfHealth = stateOfHealth;
            if (currentOdometer < 0)
            {
                throw new ArgumentException("Current odometer cannot be negative.");
            }
            CurrentOdometer = currentOdometer;
            CreatedAt = createAt;
            UpdatedAt = updateAt;
            IsActive = true;
        }
    }
}
