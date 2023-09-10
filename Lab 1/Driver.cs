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
        //Implement LinQ with Lamda
        /*Use LinQ with embedded lamda function. Lamda function can test if an object meets a certain req. Could then add this object to another smaller list. Then sort this 2nd list alphabetically.*/
        gameList.Sort((x,y) => x.title.CompareTo(y.title));

        //Display newly sorted list
        Console.WriteLine("The following is the result of sorting the video game list in asceding order based on title: \n");
        foreach (VideoGame game in gameList)
        {
            Console.WriteLine(game);
        }


        /*Choose a publisher (e.g., Nintendo) from the dataset and create a list of games from that developer from the list created in the first step. Then sort that list alphabetically and display each item inside.*/
        /*https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions */
   
        List<VideoGame> listPublisher = PublisherData(gameList);

        /*Console.WriteLine("What publisher's video games would you like to display? \n");
        string pubChoice = Console.ReadLine();

        Declaring a new list to store objects that meet a certain requirement into
        List<VideoGame> subListPub = new List<VideoGame>(gameList.FindAll(g => g.publisher == pubChoice));

        foreach (VideoGame game in subListPub)
        {
            Console.WriteLine(game);
        }

        //For whichever publisher you chose, calculate and display the percentage of games that belong to that genre as well as how to many games are from that developer out of the total (e.g., “Out of 500 games, 400 are developed by Nintendo, which is 80%”)
        double totalOverallCount = gameList.Count;
        double subListCount = subListPub.Count;
        double percentage = Math.Round(((subListCount / totalOverallCount) * 100), 2);


        Console.WriteLine($"Out of {gameList.Count} games, {subListPub.Count} are developed by {pubChoice}, which is {percentage}%");*/

        /*Choose a genre (e.g., Role-Playing) and create a list of games of that genre from the list created in the first step. Then sort that list alphabetically and display each item inside.*/

        GenreData(listPublisher);

        /*Console.WriteLine($"What genre of {pubChoice}'s games would you like to populate a list for? \n");
        string genreChoice = Console.ReadLine();

        //Declaring a new list to store objects that meet a certain requirement into
        List<VideoGame> genreList = new List<VideoGame>(gameList.FindAll(g => g.genre == genreChoice));

        //Dispalying this new list
        foreach ( VideoGame game in genreList)
        {
            Console.WriteLine(game);
        }

        /*For whichever genre you chose, calculate and display the percentage of games that belong to that genre as well as how many games belong to that genre out of the total (e.g., “Out of 500 games, 100 are Role-Playing games, which is 20%”)
        subListCount = genreList.Count;
        percentage = Math.Round((subListCount / totalOverallCount) * 100, 2);

        Console.WriteLine($"Out of {gameList.Count} games, {subListPub.Count} are developed by {pubChoice}, which is {percentage}%");*/
    }


    //Loop through whole file size with Stream Reader/ Writer and use parameterized constructor to make object instance. Store object into list.
    /// <summary>
    /// Populating VideoGame List Method - Get the filename from the user and try to open it; read
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


    /// <summary>
    /// PublisherData Method - Take in publisher (e.g., Nintendo) and create a list of games from that developer. Then sort that list alphabetically and display each item inside.Calculate and display the percentage of games that belong to that genre as well as how to many games are from that developer out of the total (e.g., “Out of 500 games, 400 are developed by Nintendo, which is 80%”). Make sure your percentage only has 2 decimal places when output
    /// </summary> 
    private static List<VideoGame> PublisherData(List<VideoGame> list)
    {
        Console.WriteLine("What publisher's video games would you like to display? \n");
        string pubChoice = Console.ReadLine();

        //Declaring a new list to store objects that meet a certain requirement into
        List<VideoGame> subListPub = new List<VideoGame>(list.FindAll(g => g.publisher == pubChoice));

        foreach (VideoGame game in subListPub)
        {
            Console.WriteLine(game);
        }

        //For whichever publisher you chose, calculate and display the percentage of games that belong to that genre as well as how to many games are from that developer out of the total (e.g., “Out of 500 games, 400 are developed by Nintendo, which is 80%”)
        double totalOverallCount = list.Count;
        double subListCount = subListPub.Count;
        double percentage = Math.Round(((subListCount / totalOverallCount) * 100), 2);


        Console.WriteLine($"Out of {list.Count} games, {subListPub.Count} are developed by {pubChoice}, which is {percentage}%");

        return subListPub;
    }


    /// <summary>
    /// GenreData Method - For whichever genre you chose, calculate and display the percentage of games that belong to that genre as well as how many games belong to that genre out of the total (e.g., “Out of 500 games, 100 are Role-Playing games, which is 20%”)*/
    /// </summary> 
    private static void GenreData(List<VideoGame> listPublisher)
    {
        Console.WriteLine($"What genre of your choice publisher's games would you like to populate a list for? \n");
        string genreChoice = Console.ReadLine();

        //Declaring a new list to store objects that meet a certain requirement into
        List<VideoGame> genreList = new List<VideoGame>(listPublisher.FindAll(g => g.genre == genreChoice));

        //Dispalying this new list
        foreach (VideoGame game in genreList)
        {
            Console.WriteLine(game);
        }

        /*For whichever genre you chose, calculate and display the percentage of games that belong to that genre as well as how many games belong to that genre out of the total (e.g., “Out of 500 games, 100 are Role-Playing games, which is 20%”)*/
        double totalPublisherCount = listPublisher.Count;
        double subListCount = genreList.Count;
        double percentage = Math.Round((subListCount / totalPublisherCount) * 100, 2);

        Console.WriteLine($"Out of {totalPublisherCount} games, {subListCount} are in the genre of your choice, which is {percentage}%");
    }

    /* Will the methods that work with the list itself also be in the driver? It does not seem like they could go elsewhere? Function that allows user input and then alphabetically sorts.*/


}
