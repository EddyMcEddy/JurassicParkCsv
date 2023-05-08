using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace JurassicPark3
{
    public class DinosaurDatabase
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();

        public void LoadDinosaurs()
        {
            if (File.Exists("dinosaurs.csv"))
            {

                var fileReader = new StreamReader("dinosaurs.csv");
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                dinosaurs = csvReader.GetRecords<Dinosaur>().ToList();
                fileReader.Close();
            }

        }


        public void SaveDinosaurs()
        {

            var fileWriter = new StreamWriter("dinosaurs.csv");

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(dinosaurs);

            fileWriter.Close();


        }

        public void ViewDinosaur(string orderBy)
        {
            if (dinosaurs.Count == 0)
            {
                Console.WriteLine("There are currently no Dinosaurs in the database");
                return;
            }
            else if (orderBy == "Name")
            {
                dinosaurs = dinosaurs.OrderBy(value => value.Name).ToList<Dinosaur>();
            }
            else
            if (orderBy == "Enclosure")
            {
                dinosaurs = dinosaurs.OrderBy(value => value.EnclosureNumber).ToList<Dinosaur>();
            }

            dinosaurs.ForEach(value => value.Description());
        }
    }
}