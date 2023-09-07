using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class VideoGame : IComparable
    {
        //Attributes
        /* Do these names follow correct naming standards?*/
        public string title { get; }
        private string platform { get; set; }
        private string year { get; set; }

        //Would this be an enum?
        private string genre { get; set; }

        private string publisher { get; set; }

        private double naSales{ get; set; } 
        private double euSales { get; set; }
        private double jpSales { get; set; }
        private double otherSales { get; set; }
        private double globalSales { get; set; }

        /****Constructors****/

        /// <summary>
        /// Default Constructor - called to make a basic, default set video game. 
        /// </summary>
        /* NOTES - Need to make this in same order as param constructor for neatness */
        public VideoGame()
        {
            this.title = "Exmaple Game Title";
            this.platform = "Example Platform Type";
            this.year = "9999";
            this.genre = "Example Genre";
            this.publisher = "Ubisoft";
            this.naSales = 0.0;
            this.euSales = 0.0;
            this.jpSales = 0.0;
            this.otherSales = 0.0;
            this.globalSales = 0.0;
        }

        /// <summary>
        /// Parameterized Constructor - Used to make a video game object with specific values upon creation. 
        /// </summary>
        public VideoGame(string title, string platform, string year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            //Setting the information that was taken in from program user as an object instances values. 
            this.title=title;
            this.platform=platform;
            this.year = year;
            this.genre=genre;
            this.publisher=publisher;
            this.naSales = naSales;
            this.euSales=euSales;
            this.jpSales=jpSales;
            this.otherSales=otherSales;
            this.globalSales=globalSales;
        }

        /****Methods****/

        /// <summary>
        /// To String Method - outputs proper worded format of object instances. 
        /// </summary>
        public override string ToString()
        {
            //A string variable to hold the display format of the object 
            string displayForm;

            displayForm = $"Title: {this.title}\tGame Platform: {this.platform}\tRelease Year: {this.year}\tGenre: {this.genre}\tPublisher:  {this.publisher}\tNA Sales: {this.naSales}\tEU Sales: {this.euSales}\tJP Sales: {this.jpSales}\tOther Sales: {this.otherSales}\tGlobal Sales: {this.globalSales} \n";

            return displayForm;
        }

        /// <summary>
        /// CompareTo Method - Implements the IComparale interface which allows users to compare objects  
        /// </summary>
        public int CompareTo(Object obj)
        {
            //Storing parameter object in temp variable of VideoGame class type
            VideoGame passedVideoGame = obj as VideoGame;

            /*Reference: https://www.geeksforgeeks.org/c-sharp-program-to-implement-icomparable-interface/#
             * returns 0, if the current instance’s property is equal to the temporary variable’s property
             * returns 1, if the current instance’s property is greater than the temporary variable’s property
             * returns -1, if the current instance’s property is less than the temporary variable’s property */
            return this.title.CompareTo(passedVideoGame.title);
        }
    }
}
