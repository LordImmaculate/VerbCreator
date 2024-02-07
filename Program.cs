using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace YourNamespace {
    class Program {
        static void Main(string[] args) {
            // Define the list of irregular verbs
            // Create a list to store pairs of strings
            List<(string, string)> stringPairs = new List<(string, string)>();

            // Display instructions to the user
            Console.WriteLine("Enter pairs of strings (press Enter after each pair):");
            Console.WriteLine("Format: <string1>,<string2>");
            Console.WriteLine("Enter 'exit' to stop entering pairs.");

            // Keep accepting input until the user enters 'exit'
            while (true) {
                // Read user input
                string input = Console.ReadLine();

                // Check if the user wants to exit
                if (input.ToLower() == "exit")
                    break;

                // Split the input into two strings
                string[] pair = input.Split(',');

                // Check if the input has exactly two parts
                if (pair.Length == 2) {
                    // Add the pair to the list
                    stringPairs.Add((pair[0], pair[1]));
                }
                else {
                    Console.WriteLine("Invalid input! Please enter two strings separated by a comma.");
                }
            }

            // Display the list of pairs
            Console.WriteLine("\nList of string pairs:");
            foreach (var pair in stringPairs) {
                Console.WriteLine(pair.Item1 + ", " + pair.Item2);
            }
            // Create the XML document
            XElement root = new XElement("stringPairs");

            // Iterate through each irregular verb and add it to the XML document
            foreach (var verb in stringPairs) {
                XElement verbElement = new XElement("verb",
                    new XElement("baseForm", verb.Item1),
                    new XElement("pastSimple", verb.Item2));

                root.Add(verbElement);
            }

            XDocument xmlDoc = new XDocument(root);

            // Save the XML document to a file
            Console.WriteLine("\nEnter the name of the XML file to save: ");
            string xmlFilePath = Console.ReadLine() + ".xml";
            xmlDoc.Save(xmlFilePath);

            Console.WriteLine($"XML file saved to {xmlFilePath}");
        }
    }
}
