/*
 * Joycelyn Wong
 * November 14, 2019
 * This project is to create a kpopdatabase for user to store album's information
 * This class is to create a song and its information variable
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopAlbumDatabase
{
    //***************PRESERVED FOR CULMINATING PROJECT**********************
    class Songs
    {
        // create a variable
        protected string song;

        public Songs()
        { }

        public Songs(string song)
        {
            this.song = song;
        }

        /// <summary>
        /// get and change the song's name
        /// </summary>
        public string SongsName
        {
            get
            {
                return song;
            }
            set
            {
                song = value; 
            }
        }

    }
    //***************PRESERVED FOR CULMINATING PROJECT**********************
}
