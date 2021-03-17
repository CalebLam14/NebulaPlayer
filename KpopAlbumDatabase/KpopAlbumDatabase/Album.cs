/*
 * Joycelyn Wong
 * November 14, 2019
 * This project is to create a kpopdatabase for user to store album's information
 * This class is to create an album and its information variable
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace KpopAlbumDatabase
{
    abstract class Album
    {
        // create a list of songs
        protected List<Songs> songs = new List<Songs>();

        // create variables and store the information of an album
        protected string title, artist, category, description, albumType;
        protected Image albumImage;
        protected int year;

        // default constructor
        public Album()
        { }

        /// <summary>
        /// Create a new album
        /// </summary>
        /// <param name="title"></param>
        /// <param name="artist"></param>
        /// <param name="year"></param>
        /// <param name="categary"></param>
        /// <param name="description"></param>
        public Album(string title, string artist, int year, string category, string description, Image albumImage, string albumType)
        {
            // create an album
            this.title = title;
            this.artist = artist;
            this.year = year;
            this.category = category;
            this.description = description;
            this.albumImage = albumImage;
            this.albumType = albumType;
        }

        /// <summary>
        ///  Adds song to this particular album that they are not already existed
        /// </summary>
        /// <param name="song"></param>
        /// <returns>>true if song was uniqe, false if already existed</returns>
        public abstract bool AddSongs(Songs song);

        public abstract bool AddSongs(string songName);


        /// <summary>
        /// Removes unwanted song from this album
        /// </summary>
        /// <param name="song"></param>
        /// <returns>true if song was existed, false if not existed</returns>
        public virtual bool RemoveSongs(Songs song)
        {
            // song is in the album, remove them
            if (songs.Contains(song))
            {
                songs.Remove(song);
                return true;
            }
            // song is not in the album
            else
            {
                return false;
            }
        }

        public abstract Songs GetSong(int index);

        /// <summary>
        /// get or set the title
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// get or set the Artist
        /// </summary>
        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }

        /// <summary>
        /// get or set the year
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        /// <summary>
        /// get or set the category
        /// </summary>
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        /// <summary>
        /// get or set the description
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// get or set the album albumImage
        /// </summary>
        public Image AlbumImage
        {
            get
            {
                return albumImage;
            }
            set
            {
                albumImage = value;
            }
        }

        /// <summary>
        /// get or set the album type
        /// </summary>
        public string AlbumType
        {
            get
            {
                return albumType;
            }
            set
            {
                albumType = value;
            }
        }
        /// <summary>
        /// Get the song list
        /// </summary>
        public List<Songs> SongList
        {
            get
            {
                return songs;
            }

        }

    }
}
