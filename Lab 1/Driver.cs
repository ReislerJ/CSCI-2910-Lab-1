/////////////////////////////////////////////////////////////////////////////////////
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
using System.Security.Cryptography.X509Certificates;

public class driver
{
    /* Make a list in the driver to hold video games. Use stream reader and writer to populate the list. Stream only take in one line at a time. Need to write a very specific for loop to read a line, then feed information into parameterized constructor in specfic order. 
      */

    private static void Main(string[] args)
    {

        //Declare global list of video game objects.
        List<VideoGame> gameList = new List<VideoGame>();

        //Populate the list using the file
        gameList = InputFile(gameList);

        //Insert output to test program and know is working 
        Console.WriteLine("The following is the result of populating the list using the file: \n");
        foreach (VideoGame game in gameList)
        {
            Console.WriteLine(game);
        }

        //Sort the list by title in ascending order
        /*Reference https://www.techiedelight.com/sort-list-of-objects-csharp/ */
        gameList.Sort(delegate (VideoGame x, VideoGame y) { return x.title.CompareTo(y.title); });


        //Implement LinQ with Lamda
        /*Use LinQ with embedded lamda function. Lamda function can test if an object meets a certain req. Could then add this object to another smaller list. Then sort this 2nd list alphabetically.*/
    }


    //Loop through whole file size with Stream Reader/ Writer and use parameterized constructor to make object instance. Store object into list.
    /// <summary>
    /// Get the filename from the user and try to open it; read
    /// contents and build library; handle any exceptions 
    /// that occur.
    /// </summary>
    private static List<VideoGame> InputFile(List<VideoGame> list)
    {
            StreamReader reader = null;

            try
            {
                reader = new StreamReader("../../../Game File/videogames.csv");
                
                //Reading the first line, but not saving it to anything
                reader.ReadLine();

                while (reader.Peek() != -1) //Peek returns -1 if there is no more text left to process
                {
                    //declaring new string variable "line" which == a line that is read in by stream reader object using read line function
                    string line = reader.ReadLine(); //FIFA 17,PS4,2016,Sports,Electronic Arts,0.28,3.75,0.06,0.69,4.77

                    //Declaring an array of strings in which each field of the array will contain one piece of video game data
                    string[] fields = line.Split(","); //fields[0] = "FIFA", fields[1] = "17", fields[2] = "PS4"
                    
                    //Creating a new video game object using the parameterized constructor in VG class which will be written over in the while loop. Driver will create and then add a new video game to the video game list each iteration on the while loop until there are no more lines available to create VideoGame objects from. Parsed some fields due to differing variable types.
                    VideoGame g = new VideoGame(fields[0], fields[1], fields[2], fields[3], fields[4], double.Parse(fields[5]), double.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8]), double.Parse(fields[9]));

                    //How do I correct this error? Should be adding the new game t the game list. 
                    list.Add(g);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read from file.");
                throw;
            }

        //Does not have to be in a finally
        reader.Close();
        return list;
    }

    
    //Stats

    //PublisherData Method

    //GenreData Method


    /* Will the methods that work with the list itself also be in the driver? It does not seem like they could go elsewhere? Function that allows user input and then alphabetically sorts.*/


}
