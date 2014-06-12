using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace txtTest
{
    class Program
    {
        //Variables
        static string fileName = "newTextFile"; // string to be used as the file name for the text file
        static List<string> list = new List<string>(); /* This is mainly used in PopulateList function, but is static
                                                        * so that it can be used externally once populated.*/
        static bool fileExists = File.Exists(fileName + ".txt"); // Boolean value used to determine if the text file exists.
        
        static void Main(string[] args)
        {
            debugTryLines();
            InitializeFile();
            PopulateList();
            debugPrintListItem();
            PromptSuccess();
        }

        static void CreateFile() // This function creates an empty text file.
        {
            // 1: Write single line to new file
            using (StreamWriter writer = new StreamWriter(fileName + ".txt", true))
            {
                writer.Write("");
            }
        }

        static void InitializeFile()
        {
            if (!fileExists) // Code only executes if the file has not been created yet.
            {
                int lineCount = 0; // I used a while loop instead of a for loop, making this int necessary.
                        
                CreateFile(); // Creates the empty file.

                while (lineCount < 10) // Populate the file with 10 lines of text.
                {
                    lineCount++;

                    using (StreamWriter writer = new StreamWriter(fileName + ".txt", true))
                    {
                        writer.WriteLine("Line " + lineCount + ":");
                    }

                }
                        
            }
        }

        static void PromptForFileName() // Unused function; can be used to allow user to choose file name.
        {
            Console.WriteLine("Please enter a name for the file.");
            fileName = Console.ReadLine();
        }
        
        static void PromptSuccess() // This just makes the program less boring, and confirms execution.
        {
            Console.Clear();
            Console.WriteLine("Success!  Press enter to exit the program.");
            Console.ReadLine();
        }

        static void PopulateList() // Populates the static list with contents of text file.
        {
            using (StreamReader reader = new StreamReader(fileName + ".txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.                    
                }
            }
        }

        static void debugPrintListItem() // Prints a specific line from the populated list.
        {
            Console.WriteLine(list[7]);
            Console.ReadLine();
        }

        static void debugTryLines() /* This edits a specific line, but doesn't use list variable or StreamReader or 
                                     * Streamwriter to do it.*/
        {
            if (fileExists) // ensures code runs only if the file has already been created.
            {
                string[] lines = File.ReadAllLines(fileName + ".txt"); /* Creates a string array "lines" and
                                                                        populates it with contents of the text file.*/
                lines[7] = "This line should be edited"; /* Edits specific line from lines array */
                File.WriteAllLines(fileName + ".txt", lines); /* Replaces entire file with updated array*/
            }
            
        }
    }
}
