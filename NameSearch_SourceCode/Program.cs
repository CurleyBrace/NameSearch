using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSearch
{
    class NameSearch
    {

        static void Main(string[] args)
        {
            List<string> names = new List<string> { "John", "Sarah", "Timothy", "Michael", "Robert" };  //Creating List of Names to Search for
            string textChunk = "I remember last year when Kasey, Sarah and I went to the beach house together for the summer " +
                            "we met quite a few other people around our age and continued to hang out with them for the remainder" +
                            " of our time there, inviting them over several times for cookouts and party games. A few of their " +
                            "names that I can remember were Timothy, Thomas, Michael and Samantha. ";   //Creating Text Chunk to Search Through

            string outputText = SearchText(textChunk, names);                                           //Calling the Search Text Method and sending both a String and List<string>              
            Console.WriteLine(outputText);                                                              //Displaying the String returned in the Line of Code
            Console.ReadLine();
        }

        private static string SearchText(string textChunk, List<string> names)                          //Takes a String and List<string> and returns a string
        {
            string[] textArray = textChunk.Split(" ");                                                  //Splitting textChunk into String Array at each space
            foreach (string name in names)                                                              //Parsing through names List
            {                                                                                           
                for (int i = 0; i < textArray.Length; i++)                                              //Parsing through text Array
                {                                                                               
                    string currentWord = textArray[i].ToLower();                                        //Temporary container for String from Current Array Position
                    string trimmedEnd = "";

                    //char[] charExceptions = { ',', '.', '?', '!', '\n' };                             //Changes made after submission to make the program function more cleanly and to increase scalability
                    //foreach(char exceptions in charExceptions)                                        //This allows you to set different character exceptions when parsing through text chunk data
                    //{                                                                                 //to ensure that everything is properly added back after the comparison between the current text
                    //    if (currentWord.Contains(exceptions)) {                                       //and the name that it is comparing to
                    //        trimmedEnd += exceptions;
                    //        currentWord.Trim(exceptions);
                    //        break;
                    //    }
                    //}
                    if (currentWord.Contains(",") == true || currentWord.Contains("."))                 //Checking temporary container for commas
                    {
                        trimmedEnd = (currentWord.Contains(",") == true) ? "," : ".";                   //Ternary Operator to check which symbol it contains and store that symbol between periods or commas
                        currentWord = currentWord.Trim(',', '.');                                       //Will trim either period or comma from the name
                    }
                    if (name.ToLower() == currentWord)                                                  //Checking name against trimmed word in current position of array
                    {
                        string replaceName = "";                                                        //Temporary Variable to hold 'X's
                        for (int x = 0; x < name.Length; x++)                                           //Traveling through the name
                        {
                            replaceName += "X";                                                         //Adding 'X' to our temporary value for each character in name
                        }
                        replaceName += trimmedEnd;                                                      //Adding whatever was trimmed off of our temporary container currentWord
                        textArray[i] = replaceName;                                                     //Replacing the current position in the array with our altered name
                    }
                }
            }
            return string.Join(" ", textArray);                                                         //Joining our array into a single string seperated by spaces and returning it
        }

    }
}
