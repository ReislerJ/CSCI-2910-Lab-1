﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class VideoGame
    {
        //Attributes
        /* Do these names follow correct naming standards?*/
        private string name { get; set; }
        private string platform { get; set; }
        private int year { get; set; }

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
            this.name = "Exmaple Game Title";
            this.platform = "Example Platform Type";
            this.year = 1999;
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
        public VideoGame(string name, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            //Setting the information that was taken in from program user as an object instances values. 
            this.name=name;
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

            displayForm = $"Title: {this.name} \nGame Platform: {this.platform} \nRelease Year: {this.year} \nGenre: {this.genre} \nPublisher:  {this.publisher} \nNA Sales: {this.naSales} \nEU Sales: {this.euSales} \nJP Sales: {this.jpSales} \nOther Sales: {this.otherSales} \nGlobal Sales: {this.globalSales}";

            return displayForm;
        }
    }
}
