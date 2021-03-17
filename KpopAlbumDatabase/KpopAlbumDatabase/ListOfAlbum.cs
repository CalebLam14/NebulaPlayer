/*
 * Joycelyn Wong
 * November 14, 2019
 * This project is to create a kpopdatabase for user to store album's information
 * This class is to build functions of a database
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
    class ListOfAlbum
    {
        // create list of albums
        protected List<Album> albums = new List<Album>();

        // create list of favourite albums
        protected List<Album> favAlbums = new List<Album>();

        /// <summary>
        ///  Adds albums to ListofAlbums if they are not already existed
        /// </summary>
        /// <param name="anAlbum"></param>
        /// <returns>true and add if album was uniqe, false if already existed</returns>
        public bool AddAlbum(Album anAlbum)
        {
            // if album is already existed, dont add
            if (albums.Contains(anAlbum))
            {
                return false;
            }
            // if album is new, add to this list
            else
            {
                albums.Add(anAlbum);
                return true;
            }
        }

        /// <summary>
        /// Create new album
        /// </summary>
        /// <param name="title">album's title</param>
        /// <param name="artist">album's artist</param>
        /// <param name="year">album released year</param>
        /// <param name="categary">album's categary</param>
        /// <param name="description">album's description</param>
        /// <param name="albumImage">album's image</param>
        /// <returns>new album</returns>
        public bool AddAlbum(string title, string artist, int year, string categary, string description, Image albumImage, string albumType)
        {
            if (albumType == "regular")
            {
                Album anAlbum = new Regular(title, artist, year, categary, description, albumImage, albumType);
                return AddAlbum(anAlbum);
            }
            else if (albumType == "single")
            {
                Album anAlbum = new Single(title, artist, year, categary, description, albumImage, albumType);
                return AddAlbum(anAlbum);
            }
            else if (albumType == "ep")
            {
                Album anAlbum = new EP(title, artist, year, categary, description, albumImage, albumType);
                return AddAlbum(anAlbum);
            }
            else if (albumType == "studio album")
            {
                Album anAlbum = new StudioAlbum(title, artist, year, categary, description, albumImage, albumType);
                return AddAlbum(anAlbum);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if album is existed
        /// </summary>
        /// <param name="album"></param>
        /// <returns>true and remove album if album was uniqe, false if already existed</returns>
        public bool RemoveAlbum(Album album)
        {
            // album is in the course, remove it
            if (albums.Contains(album))
            {
                albums.Remove(album);
                return true;
            }
            // student was not in the course
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Adds albums to ListofAlbums if they are not already existed
        /// </summary>
        /// <param name="favAlbum"></param>
        /// <returns>true and add if album was uniqe in favourite list, false if already existed</returns>
        public bool AddFavAlbum(Album favAlbum)
        {
            // if album is already existed, dont add
            if (favAlbums.Contains(favAlbum))
            {
                return false;
            }
            // if album is new, add to this list
            else
            {
                favAlbums.Add(favAlbum);
                return true;
            }
        }

        /// <summary>
        /// Create new album
        /// </summary>
        /// <param name="title">album's title</param>
        /// <param name="artist">album's artist</param>
        /// <param name="year">album released year</param>
        /// <param name="categary">album's categary</param>
        /// <param name="description">album's description</param>
        /// <param name="albumImage">album's image</param>
        /// <returns>new album</returns>
        public bool AddFavAlbum(string title, string artist, int year, string categary, string description, Image albumImage, string albumType)
        {
            if (albumType == "regular")
            {
                Album anAlbum = new Regular(title, artist, year, categary, description, albumImage, albumType);
                return AddFavAlbum(anAlbum);
            }
            else if (albumType == "single")
            {
                Album anAlbum = new Single(title, artist, year, categary, description, albumImage, albumType);
                return AddFavAlbum(anAlbum);
            }
            else if (albumType == "ep")
            {
                Album anAlbum = new EP(title, artist, year, categary, description, albumImage, albumType);
                return AddFavAlbum(anAlbum);
            }
            else if (albumType == "studio album")
            {
                Album anAlbum = new StudioAlbum(title, artist, year, categary, description, albumImage, albumType);
                return AddFavAlbum(anAlbum);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if album is existed
        /// </summary>
        /// <param name="album"></param>
        /// <returns>true and remove album if favourite album was uniqe, false if already existed</returns>
        public bool RemoveFavAlbum(Album favAlbum)
        {
            // album is in , remove it
            if (favAlbums.Contains(favAlbum))
            {
                favAlbums.Remove(favAlbum);
                return true;
            }
            // alum was not in 
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get and return the album index
        /// </summary>
        /// <param name="index">should equal or bigger than 0 and no bigger than the number of albums</param>
        /// <returns>album's index if valid, null if not valid</returns>
        public Album GetAlbum(int index)
        {
            // if the index is valid, return the student at index
            if (index >= 0 && index < albums.Count)
            {
                return albums[index];
            }

            // invalid index causes null return
            return null;
        }

        /// <summary>
        /// get and return the favourite album index
        /// </summary>
        /// <param name="index">should equal or bigger than 0 and no bigger than the number of albums</param>
        /// <returns>album's index if valid, null if not valid</returns>
        public Album GetFavAlbum(int index)
        {
            // if the index is valid, return the student at index
            if (index >= 0 && index < favAlbums.Count)
            {
                return favAlbums[index];
            }

            // invalid index causes null return
            return null;
        }

        /// <summary>
        /// get and set album list
        /// </summary>
        public List<Album> AlbumList
        {
            get
            {
                return albums;
            }
            set
            {
                albums = value;
            }
        }

        /// <summary>
        /// get and set favourite album list
        /// </summary>
        public List<Album> FavAlbumList
        {
            get
            {
                return favAlbums;
            }
            set
            {
                favAlbums = value;
            }
        }

        /// <summary>
        /// Return sorted album by year
        /// </summary>
        /// <param name="toBeSortedList"></param>
        public void SortedByYear(List<Album> toBeSortedList)
        {
            toBeSortedList.Sort(delegate (Album a, Album b)
            {
                return a.Year.CompareTo(b.Year);
            });
        }

        /// <summary>
        /// Return sorted album by title alphabet
        /// </summary>
        /// <param name="toBeSortedList"></param>
        public void SortedByTitleAlphabet(List<Album> toBeSortedList)
        {
            toBeSortedList.Sort(delegate (Album a, Album b)
            {
                return a.Title.CompareTo(b.Title);
            });
        }
        
        /// <summary>
        ///  recommand random album to the user
        /// </summary>
        /// <returns>random albums</returns>
        public Album Recommendation()
        {
            // create a random maker
            Random recommendationMaker = new Random();

            // pick a random album
            int randomAlbum = recommendationMaker.Next(0, albums.Count);

            // return the random album
            return albums[randomAlbum];
        }

        /// <summary>
        /// To search albums that contains keywords which is typed by user 
        /// </summary>
        /// <param name="searchKeywords"></param>
        /// <returns>albums that conatins keyword</returns>
        public List<Album> SearchEngine(string searchKeywords)
        {
            //string keyword = searchKeywords.ToLower();

            List<Album> searchAlbums = new List<Album>();

            for (int i = 0; i < albums.Count; i++)
            {
                if (albums[i].Title.Contains(searchKeywords) || albums[i].Artist.Contains(searchKeywords) ||
                   albums[i].Year.ToString().Contains(searchKeywords) || albums[i].Category.Contains(searchKeywords) ||
                   albums[i].Description.Contains(searchKeywords))
                {
                    searchAlbums.Add(albums[i]);
                }
            }

            return searchAlbums;
        }
    }
}
