using System;

namespace JurassicPark3
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public double Weight { get; set; }
        public double EnclosureNumber { get; set; }



        public void Description()
        {
            Console.WriteLine($"{Name} dietType is {DietType}. {Name} is in enclosure number {EnclosureNumber} and weighs {Weight} pounds. It was acquired at {WhenAcquired}");
        }

    }
}