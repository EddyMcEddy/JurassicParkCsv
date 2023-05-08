using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using JurassicPark3;

namespace JurassicPark3
{
    class Program

    {


        public class Prompts
        {

            static string PromptsForString(string prompt)
            {
                Console.WriteLine(prompt);
                var userInput = Console.ReadLine();
                return userInput;
            }


            static double PromptForInteger(string prompt)
            {
                Console.WriteLine(prompt);
                var userInput2 = Convert.ToDouble(Console.ReadLine());
                return userInput2;
            }
            static void greetings()
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Welcome! To Eddie's Jurassic Park");
                Console.WriteLine("Enter and Find your favorite Dinosaurs.");
                Console.WriteLine();
                Console.WriteLine("__________________________________________");
            }
            static void Main(string[] args)
            {

                var dinosaurs = new List<Dinosaur>();

                var database = new DinosaurDatabase();

                database.LoadDinosaurs();














                bool keepMenuGoing = true;
                var carnivore = "CARNIVORE";
                var herbivore = "HERBIVORE";
                //double newEnclsoureNumber = Convert.ToDouble("");




                while (keepMenuGoing)
                {
                    Console.WriteLine();
                    Console.WriteLine("What do you want to do in Jurassic Park Database?:\n(A)Add \n(V)View \n(T)Transfer Enclosure Number \n(R)Remove Dino \n(S)Summary \n(Q)Quit");
                    var userInput = Console.ReadLine().ToUpper();

                    if (userInput == "Q")
                    {
                        keepMenuGoing = false;
                    }
                    else if (userInput == "S")
                    {

                        var herbivore2 = dinosaurs.Where(value => value.DietType.ToUpper().Contains("Herbivore")).ToList().Count();

                        var carnivore2 = dinosaurs.Where(value => value.DietType.ToUpper().Contains("Carnivore")).ToList().Count();


                        Console.WriteLine($"There are {herbivore2} Herbivore's in Ed's Jurassic Park!");
                        Console.WriteLine($"There are {carnivore2} Carnivore's in Ed's Jurassic Park!");


                    }
                    else if (userInput == "R")
                    {
                        var nameToSearch = PromptsForString("What Dino name do you want to Remove?: ");
                        Dinosaur nameRemove = dinosaurs.FirstOrDefault(value => value.Name == nameToSearch);
                        dinosaurs.Remove(nameRemove);


                    }
                    else if (userInput == "T")
                    {

                        var nameToSearch = PromptsForString("What is the Dino's name you like to transfer EnclosureNumber?: ");
                        Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(value => value.Name == nameToSearch);

                        var newEnclosure = PromptForInteger($"What is your Dino {foundDinosaur.Name} new Enclosure Number?: ");
                        foundDinosaur.EnclosureNumber = Convert.ToDouble(newEnclosure);

                        Console.WriteLine($"{foundDinosaur.Name} has been updated to {newEnclosure}");
                    }

                    else if (userInput == "V")
                    {


                        Console.WriteLine("How would you Like to view your Dino's in Order Of?: \n(N)Name \n or \n(E)Enclosure Number");
                        var userView = Console.ReadLine().ToUpper();
                        if (userView == "N")
                        {
                            Console.WriteLine($"Dino In Order by Dino Name");
                            foreach (var dinosaur in dinosaurs = dinosaurs.OrderBy(value => value.Name).ToList())
                            {

                                Console.WriteLine($"Dino {dinosaur.Name} is here and has Enclosure # {dinosaur.EnclosureNumber}");
                            }
                        }
                        else if (userView == "E")
                        {
                            Console.WriteLine($"Dino in Order Of Enclosure # ");
                            foreach (var dinosaur in dinosaurs = dinosaurs.OrderBy(value => value.EnclosureNumber).ToList())
                            {

                                Console.WriteLine($"Dino {dinosaur.Name} is in Enclosure # {dinosaur.EnclosureNumber} ");

                            }
                        }



                    }
                    else
                    {

                        var dinosaur = new Dinosaur() { };

                        dinosaur.Name = PromptsForString("What is your Dino's Name?: ");
                        Console.WriteLine($"What type of Diet does {dinosaur.Name} have?: \n(C)Carnivore \nOR \n(H)Herbivore ");
                        var userDiet = Console.ReadLine().ToUpper();
                        if (userDiet == "C")
                        {
                            dinosaur.DietType = Convert.ToString(carnivore);

                        }
                        else if (userDiet == "H")
                        {
                            dinosaur.DietType = Convert.ToString(herbivore);

                        }

                        dinosaur.EnclosureNumber = PromptForInteger($"What Enclosure Number is Dino {dinosaur.Name} in?: ");
                        dinosaur.Weight = PromptForInteger("How many pounds does your Dino weigh?: ");
                        dinosaur.WhenAcquired = DateTime.Now;


                        Console.WriteLine($"Your Dino {dinosaur.Name} is a {dinosaur.DietType} has a weight of {dinosaur.Weight} and is in Enclosure #{dinosaur.EnclosureNumber} and was created {dinosaur.WhenAcquired}");
                        dinosaurs.Add(dinosaur);
                    }

                    database.SaveDinosaurs();
                }





            }
        }










    }





}




