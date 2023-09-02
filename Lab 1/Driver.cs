﻿/////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Lab 1
//	File Name:		Driver.cs
//	Description:	Where actual game runs. Demonstrates use of other class.  
//	Course:			
//	Author:			Jasmine, reisler@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Tuesday, August 29, 2023
//	Copyright:		Jasmine Reisler, 2023
//
/////////////////////////////////////////////////////////////////////////////////////

using Lab_1;

public class driver
{
    public static void Main()
    {
        /* Make a list in the driver to hold video games. Use stream reader and writer to populate the list. Stream only take in one line at a time. Need to write a very specific for loop to read a line, then feed information into parameterized constructor in specfic order. 
        */

        //Declare new list of videogame objects.
        List<VideoGame> gameList = new List<VideoGame>();

        //Loop through whole file size with Stream Reader/ Writer and use parameterized constructor to make object instance. Store object into list.
        /// <summary>
        /// Get the filename from the user and try to open it; read
        /// contents and build library; handle any exceptions 
        /// that occur.
        /// </summary>

        static void InputFile()
        {
            StreamReader reader = null;

            try
            {
                reader = new StreamReader("../../../Game File/videogames.csv");
                while (reader.Peek() != -1) //Peek returns -1 if there is no more text left to process
                {
                    //declaring new string variable "line" which == a line that is read in by stream reader object using read line function
                    string line = reader.ReadLine(); //FIFA 17,PS4,2016,Sports,Electronic Arts,0.28,3.75,0.06,0.69,4.77

                    //Declaring an array of strings in which each field of the array will contain one piece of video game data
                    string[] fields = line.Split(","); //fields[0] = "FIFA", fields[1] = "17", fields[2] = "PS4"
                    
                    //Creating a new video game object using the parameterized constructor in VG class which will be written over in the while loop. Driver will create and then add a new video game to the video game list each iteration on the while loop until there are no more lines available to create VideoGame objects from. Parsed some fields due to differing variable types.
                    VideoGame g = new VideoGame(fields[0], fields[1], fields[2], fields[3], fields[4], double.Parse(fields[5]), double.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8]), double.Parse(fields[9]));

                    //How do I correct this error? Should be adding the new game t the game list. 
                    gameList.Add(g);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read from file.");
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                //How do I fix this error?
                foreach (VideoGame g in gameList)
                {
                    //Does this need to use the ToString function?
                    Console.WriteLine(g);
                }
            }
        }
        

        //Implement Icomaprable

        //Implement LinQ with Lamda

        //Stats

        //PublisherData

        //GenreData


        /* Will the methods that work with the list itself also be in the driver? It does not seem like they could go elsewhere? Function that allows user input and then alphabetically sorts.*/


    }
}
