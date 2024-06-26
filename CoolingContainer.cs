using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conteners
{
    public class CoolingContainer : Container
    {
        public string ProductType { get; set; }
        public double Temperature { get; set; }


        public CoolingContainer(int weightInKg, int capacity, int heightInCm, int depthInCm, string productType, double temperature)
         : base(weightInKg, capacity, heightInCm, depthInCm)
        {
            SerialNumber = $"KON-C-{nextSerialNumber++}";
            ProductType = productType;
            Temperature = temperature;
        }

        public void LoadContainerCargo(int massWeight, string productType, double temperature) {
            if (Capacity < massWeight) {
                throw new OverfillException(SerialNumber);
            }

            if (productType != ProductType) {
                System.Console.WriteLine("product types aren't equal - container " + SerialNumber + " has not been loaded");
                return;
            }
            if (temperature > Temperature) {
                System.Console.WriteLine("product temperature is too high - container " + SerialNumber + " has not been loaded");
                return;
            }
            CargoMassInKg = massWeight;
            WeightInKg += massWeight;
        }

        public override void PrintContainerInfo() 
        {
            System.Console.WriteLine("\ncontainer serial number = " + SerialNumber);
            System.Console.WriteLine("container weight in kg = " + WeightInKg);
            System.Console.WriteLine("container capacity = " + Capacity);
            System.Console.WriteLine("container height in cm = " + HeightInCm);
            System.Console.WriteLine("container depth in cm = " + DepthInCm);
            System.Console.WriteLine("container product type = " + ProductType);
            System.Console.WriteLine("container temperature = " + Temperature);
        }


    }
}