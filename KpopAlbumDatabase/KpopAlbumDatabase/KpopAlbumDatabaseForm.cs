/*
 * Joycelyn Wong
 * November 14, 2019
 * This project is to create a kpopdatabase for user to store album's information
 * This class is to create the interface and interconnet it with subprograms in other classes
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KpopAlbumDatabase
{
    public partial class KpopAlbumDatabaseForm : Form
    {
        // the list
        ListOfAlbum database = new ListOfAlbum();

        // Index that keep count on albums
        int searchAlbumIndex;
        int albumIndex = -1;
        int albumCounter = 0;
        int songIndex = -1;
        int favAlbumIndex = -1;

        public KpopAlbumDatabaseForm()
        {
            InitializeComponent();
            // to hide unnecessary buttons that won't be used at the first
            btnAlbumSave.Hide();
            btnCancelSearch.Hide();
            btnCancelDisplayFav.Hide();
            btnRemoveFromFav.Hide();
        }

        /// <summary>
        /// To add a new album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // change the type of "year" to load into the album
            int.TryParse(txtYear.Text, out int year);

            if (txtTitle.Text == null || txtArtist.Text == null || txtYear.Text == null || txtCategory.Text == null || txtDescription.Text == null || txtAlbumType.Text == null || picPreview.Image == null)
            {
                MessageBox.Show("Please enter ALL the information");
            }
            else
            {
                // create a new album
                bool check = database.AddAlbum(txtTitle.Text, txtArtist.Text, year, txtCategory.Text, txtDescription.Text, picPreview.Image, txtAlbumType.Text.ToLower());

                if (check == false)
                {
                    MessageBox.Show("Please enter the valid album type");
                }
                else
                {
                    // let the user know that album has been added
                    MessageBox.Show(txtTitle.Text + " has been added to your database.");

                    // clear the information after entering 
                    txtTitle.Text = "";
                    txtArtist.Text = "";
                    txtYear.Text = "";
                    txtCategory.Text = "";
                    txtDescription.Text = "";
                    txtAlbumType.Text = "";
                    picPreview.Image = null;

                    // keep count of the number of album
                    albumCounter += 1;
                    albumIndex = albumIndex + 1;
                    songIndex = -1;

                    // display added album information
                    DisplayCurrentAlbum();
                }
            }
        }

        /// <summary>
        /// To create new album image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // variable that is used to store image location laer
            String imageLocation = "";

            // to open the image file
            OpenFileDialog dialog = new OpenFileDialog();

            // only below image formats are allowed yo upload 
            dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

            // to load the image to picPreview
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // save image location
                imageLocation = dialog.FileName;

                // set picPreview to image
                picPreview.ImageLocation = imageLocation;
            }
        }
       
        /// <summary>
        /// To edit ablum which is on the display label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // show the save button and hide the edit button
            btnAlbumSave.Show();
            btnEdit.Hide();

            // user have no access to remove function when editing
            btnRemoveAlbum.Hide();

            // load the wanted album information back to the textbox
            txtTitle.Text = database.GetAlbum(albumIndex).Title;
            txtArtist.Text = database.GetAlbum(albumIndex).Artist;
            txtYear.Text = database.GetAlbum(albumIndex).Year.ToString();
            txtCategory.Text = database.GetAlbum(albumIndex).Category;
            txtDescription.Text = database.GetAlbum(albumIndex).Description;
            picPreview.Image = database.GetAlbum(albumIndex).AlbumImage;

        }

        /// <summary>
        /// To save the edited information in the album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlbumSave_Click(object sender, EventArgs e)
        {
            // hide the save button and show the edit button
            btnAlbumSave.Hide();
            btnEdit.Show();

            // user get access to remove function
            btnRemoveAlbum.Show();

            // change the type of variable
            int.TryParse(txtYear.Text, out int year);

            // load the new information back
            database.GetAlbum(albumIndex).Title = txtTitle.Text;
            database.GetAlbum(albumIndex).Artist = txtArtist.Text;
            database.GetAlbum(albumIndex).Year = year;
            database.GetAlbum(albumIndex).Category = txtCategory.Text;
            database.GetAlbum(albumIndex).Description = txtDescription.Text;
            database.GetAlbum(albumIndex).AlbumImage = picPreview.Image;

            // clear the information in textboxes and image box
            txtTitle.Text = "";
            txtArtist.Text = "";
            txtYear.Text = "";
            txtCategory.Text = "";
            txtDescription.Text = "";
            picPreview.Image = null;

            // display current album information
            DisplayCurrentAlbum();

            // let the user know that album has been changed
            MessageBox.Show(database.GetAlbum(albumIndex).Title + " has been changed.");
        }

        /// <summary>
        /// To remove album that is on the display label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                // let the user know that album has been removed
                MessageBox.Show(database.GetAlbum(albumIndex).Title + " has been removed");

                if (albumIndex == 0)
                {
                    DisplayAlbumFormat(database.GetAlbum(database.AlbumList.Count - 2));
                }
                else
                {
                    // display previous album
                    DisplayAlbumFormat(database.GetAlbum(albumIndex - 1));
                }

                // remove album
                database.RemoveAlbum(database.GetAlbum(albumIndex));

                // decrease the counter
                albumCounter -= 1;
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }


        /// <summary>
        /// Adding song to the album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                // add song into particular album
                bool valid = database.GetAlbum(albumIndex).AddSongs(txtSong.Text);

                // if it is false, tell the user
                if (valid == false)
                {
                    MessageBox.Show("Song amount has reached maximum or minimum");
                }
                // true then show related information
                else
                {
                    // keep count of number of songs in particular album
                    songIndex += 1;

                    // display the song information
                    for (int i = 0; i < database.GetAlbum(albumIndex).SongList.Count; i++)
                    {
                        lblDisplySongInfo.Text = database.GetAlbum(albumIndex).GetSong(i).SongsName;
                    }

                    // clear the textbox
                    txtSong.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        /// <summary>
        /// remove song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            try
            {
                // save the variable 
                string remove = database.GetAlbum(albumIndex).GetSong(songIndex).SongsName;

                // if it is removable
                if (database.GetAlbum(albumIndex).RemoveSongs(database.GetAlbum(albumIndex).GetSong(songIndex)) == true)
                {
                    // let the user know that album has been removed
                    MessageBox.Show(remove + " has been removed");
                    // remove song
                    database.GetAlbum(albumIndex).RemoveSongs(database.GetAlbum(albumIndex).GetSong(songIndex));
                    // go to latest song
                    songIndex -= 1;
                }
                // if it is nont
                else
                {
                    MessageBox.Show("Cannot be removed. It is the minimum amount of an album.");
                }

                // display song
                DisplayCurrentSong(database.GetAlbum(albumIndex));
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }

        /// <summary>
        /// display song
        /// </summary>
        /// <param name="album"></param>
        private void DisplayCurrentSong(Album album)
        {
            try
            {
                if (songIndex == -1)
                {
                    lblDisplySongInfo.Text = "";
                }
                else
                {
                    lblDisplySongInfo.Text = album.GetSong(songIndex).SongsName;
                }
            }
            catch
            {
                lblDisplySongInfo.Text = "";
            }
        }

        /// <summary>
        /// move to the previous song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousSong_Click(object sender, EventArgs e)
        {
            // move to previous regular album song
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // move to the previous song's index
                songIndex -= 1;

                // when the songIndex reaches the lowest limit
                if (songIndex <= -1)
                {
                    songIndex = database.GetAlbum(albumIndex).SongList.Count - 1;
                }

                // display song
                DisplayCurrentSong(database.GetAlbum(albumIndex));
            }
            // not applicable in search result
            else if (btnDisplayFav.Visible == true)
            {
                lblDisplySongInfo.Text = "";
            }

            // move to previous favourite album song
            else if (btnDisplayFav.Visible == false && btnCancelDisplayFav.Visible == true)
            {
                // move to the previous song's index
                songIndex -= 1;

                // when the songIndex reaches the lowest limit
                if (songIndex <= -1)
                {
                    songIndex = database.GetFavAlbum(favAlbumIndex).SongList.Count - 1;
                }

                // display song
                DisplayCurrentSong(database.GetFavAlbum(favAlbumIndex));
            }            
        }

        /// <summary>
        ///  move to the next song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextSong_Click(object sender, EventArgs e)
        {
            // move to previous regular album's song
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // move to the previous song's index
                songIndex += 1;

                //when the songIndex reaches the lowest limit
                if (songIndex >= database.GetAlbum(albumIndex).SongList.Count)
                {
                    songIndex = 0;
                }

                // display song
                DisplayCurrentSong(database.GetAlbum(albumIndex));
            }
            // not applicable in search result
            else if (btnDisplayFav.Visible == true)
            {
                lblDisplySongInfo.Text = "";
            }

            // move to previous favourite album's song
            else if (btnDisplayFav.Visible == false && btnCancelDisplayFav.Visible == true)
            {
                // move to the previous song's index
                songIndex += 1;

                //when the songIndex reaches the lowest limit
                if (songIndex >= database.GetFavAlbum(favAlbumIndex).SongList.Count)
                {
                    songIndex = 0;
                }

                // display song
                DisplayCurrentSong(database.GetFavAlbum(favAlbumIndex));
            }

        }

        /// <summary>
        /// To display the corresponding album
        /// </summary>
        private void DisplayCurrentAlbum()
        {
            // display regular album
            if (database.AlbumList != null && btnDisplayFav.Visible == true && btnCancelSearch.Visible == false)
            {
                DisplayAlbumFormat(database.GetAlbum(albumIndex));
                //DisplayCurrentSong(database.GetAlbum(albumIndex));
            }
            // display searh album
            else if (btnDisplayFav.Visible == true)
            {
                DisplayAlbumFormat(database.SearchEngine(txtSearchingBar.Text)[searchAlbumIndex]);
            }
            // display favourite album
            else if (btnDisplayFav.Visible == false)
            {
                DisplayAlbumFormat(database.GetFavAlbum(favAlbumIndex));
                //DisplayCurrentSong(database.GetFavAlbum(favAlbumIndex));
            }
            // display nothing if there's an error
            else
            {
                lblDisplayAlbumInfo.Text = "Title: " + "\r\n" + "Artist: " + "\r\n" +
                                  "Released Year: " + "\r\n" + "Category: "
                                  + "\r\n" + "Description: " + "\r\n" + "Album Type:";
            }

        }

        /// <summary>
        /// To display in format
        /// </summary>
        /// <param name="album">to pick the right format for passed in album</param>
        private void DisplayAlbumFormat(Album album)
        {
            try
            {
                // regular album
                if (database.GetAlbum(0) != null && btnDisplayFav.Visible == true && btnCancelSearch.Visible == false)
                {
                    lblDisplayAlbumInfo.Text = "Title: " + album.Title + "\r\n" + "Artist: " + album.Artist + "\r\n" +
                                                      "Released Year: " + album.Year.ToString() + "\r\n" + "Category: " + album.Category
                                                      + "\r\n" + "Description: " + album.Description + "\r\n" + "Album type: " + album.AlbumType;
                    picAlbum.Image = album.AlbumImage;
                }
                // search album
                else if (btnSearch.Visible == false && btnCancelSearch.Visible == true && btnDisplayFav.Visible == true)
                {
                    lblDisplayAlbumInfo.Text = "Search Result: " + "\r\n" + "Title: " + album.Title + "\r\n" + "Artist: " + album.Artist + "\r\n" +
                                      "Released Year: " + album.Year.ToString() + "\r\n" + "Category: " + album.Category
                                      + "\r\n" + "Description: " + album.Description + "\r\n" + "Album type: " + album.AlbumType;

                    picAlbum.Image = album.AlbumImage;
                }
                // favourite abum
                else if (btnDisplayFav.Visible == false)
                {
                    lblDisplayAlbumInfo.Text = "MY FAVOURITE: " + "\r\n" + "Title: " + album.Title + "\r\n" + "Artist: " + album.Artist + "\r\n" +
                          "Released Year: " + album.Year.ToString() + "\r\n" + "Category: " + album.Category
                          + "\r\n" + "Description: " + album.Description + "\r\n" + "Album type: " + album.AlbumType;

                    picAlbum.Image = album.AlbumImage;
                }
                // display nothing if there's an error
                else
                {
                    lblDisplayAlbumInfo.Text = "Title: " + "\r\n" + "Artist: " + "\r\n" +
                                      "Released Year: " + "\r\n" + "Category: "
                                      + "\r\n" + "Description: ";
                }
            }
            catch
            {
                lblDisplayAlbumInfo.Text = "";
                picAlbum.Image = null; 
            }
        }

        /// <summary>
        /// To move to previous album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousAlbum_Click(object sender, EventArgs e)
        {
            // move to previous regular album
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // move to the previous album's index
                albumIndex -= 1;

                //when the searchAlbumIndex reaches the lowest limit
                if (albumIndex <= -1)
                {
                    albumIndex = database.AlbumList.Count - 1;
                }

            }
            // move to previous search result
            else if (btnDisplayFav.Visible == true)
            {
                // move to the previous album's index
                searchAlbumIndex -= 1;

                // when the searchAlbumIndex reaches the lowest limit
                if (searchAlbumIndex <= -1)
                {
                    searchAlbumIndex = database.SearchEngine(txtSearchingBar.Text).Count - 1;
                }

            }

            // move to previous favourite album
            else if (btnDisplayFav.Visible == false && btnCancelDisplayFav.Visible == true)
            {
                // move to the previous album's index
                favAlbumIndex -= 1;

                //when the searchAlbumIndex reaches the lowest limit
                if (favAlbumIndex <= -1)
                {
                    favAlbumIndex = database.FavAlbumList.Count - 1;
                }

            }

            // display album in label
            DisplayCurrentAlbum();
            // display songlist
            DisplayCurrentSong(database.GetAlbum(albumIndex));
            songIndex = 0;
        }

        /// <summary>
        /// To move to next album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextAlbum_Click(object sender, EventArgs e)
        {
            // move to next regular album
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // move to the previous album's index
                albumIndex += 1;

                //when the searchAlbumIndex reaches the lowest limit
                if (albumIndex >= database.AlbumList.Count)
                {
                    albumIndex = 0;
                }

            }
            // move to next search result
            else if (btnCancelSearch.Visible == true && btnDisplayFav.Visible == true)
            {
                // move to the next album's index
                searchAlbumIndex += 1;

                // when the searchAlbumIndex reaches the highest limit
                if (searchAlbumIndex >= database.SearchEngine(txtSearchingBar.Text).Count)
                {
                    searchAlbumIndex = 0;
                }
            }
            // move to next favourite album
            else if (btnDisplayFav.Visible == false && btnCancelDisplayFav.Visible == true)
            {
                // move to the previous album's index
                favAlbumIndex += 1;

                //when the searchAlbumIndex reaches the lowest limit
                if (favAlbumIndex >= database.FavAlbumList.Count)
                {
                    favAlbumIndex = 0;
                }
            }

            // display in label
            DisplayCurrentAlbum();         

            // display songlist
            DisplayCurrentSong(database.GetAlbum(albumIndex));
            songIndex = 0;
        }

        /// <summary>
        /// To recommend random albums to user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecommend_Click(object sender, EventArgs e)
        {
            // store the random album
            Album random = database.Recommendation();

            // display random album's title
            lblDisplayRecommendation.Text = "Why don't you listen to " + random.Title;

            // display random album's information
            DisplayAlbumFormat(random);
        }

        /// <summary>
        /// To sort album in alphabetical order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortedbyAlphabet_Click(object sender, EventArgs e)
        {
            // if user is displaying regular album, sort regular album
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // pass in the right list and call the constructor and sort
                database.SortedByTitleAlphabet(database.AlbumList);

                // display from first sorted album
                albumIndex = 0;

                // let the user know that album has been sorted
                MessageBox.Show("Albums are sorted by alphabetical order.");
            }
            // if user is displaying favourite album, sort favourite album
            else
            {
                // pass in the right list and call the constructor and sort
                database.SortedByTitleAlphabet(database.FavAlbumList);

                // display from first sorted album
                favAlbumIndex = 0;

                // let the user know that album has been sorted
                MessageBox.Show("Favourite Albums are sorted by alphabetical order.");
            }

            // display in label
            DisplayCurrentAlbum();
        }

        /// <summary>
        /// To sort albums by released year(oldest to most recent)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortedByYear_Click(object sender, EventArgs e)
        {
            // if user is displaying regular album, sort regular album
            if (btnSearch.Visible == true && btnCancelSearch.Visible == false && btnDisplayFav.Visible == true)
            {
                // pass in the right list and call the constructor and sort
                database.SortedByYear(database.AlbumList);

                // display from first sorted album
                albumIndex = 0;

                // let the user know that album has been sorted
                MessageBox.Show("Albums are sorted by released year.");
            }
            // if user is displaying favourite album, sort favourite album
            else
            {
                // pass in the right list and call the constructor and sort
                database.SortedByYear(database.FavAlbumList);

                // display from first sorted album
                favAlbumIndex = 0;

                // let the user know that album has been sorted
                MessageBox.Show("Favourite Albums is sorted by released year.");
            }

            // display in label
            DisplayCurrentAlbum();
        }

        /// <summary>
        /// To search album that contains keyword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // favourite and sorting functions are denied under searching progress
            btnSortedbyAlphabet.Hide();
            btnSortedByYear.Hide();
            btnAddToFav.Hide();

            // to show cancel search button and hide search button
            btnCancelSearch.Show();
            btnSearch.Hide();

            // result will be shown if searched item is included
            try
            {
                // to pass in the keyword
                database.SearchEngine(txtSearchingBar.Text);

                // display result in label
                searchAlbumIndex = 0;
                DisplayCurrentAlbum();
            }
            // error will be shown if searched item is not included
            catch
            {
                MessageBox.Show("Searched item is not found.");
            }

            lblDisplySongInfo.Text = "";
        }
        
        /// <summary>
        /// To clear searhed result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            // favourite and sorting functions are recovered
            btnSortedbyAlphabet.Show();
            btnSortedByYear.Show();
            btnAddToFav.Show();

            // to show search button and hide cancel search button
            btnCancelSearch.Hide();
            btnSearch.Show();

            // clear the searching bar
            txtSearchingBar.Text = "";
            
            // display regular albums
            albumIndex = 0;
            DisplayCurrentAlbum();
            DisplayCurrentSong(database.GetAlbum(albumIndex));
        }

        /// <summary>
        /// to add album to favourite list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToFav_Click(object sender, EventArgs e)
        {
            // album will be added
            try
            {
                // pass in the wanted album
                database.AddFavAlbum(database.GetAlbum(albumIndex));

                // keep count on number of favourite album
                favAlbumIndex += 1;

                // let the user know that album has been added to favourite
                MessageBox.Show(database.GetFavAlbum(favAlbumIndex).Title + " has been added to ur favourite list.");
            }
            // if there's error, show error message
            catch
            {
                MessageBox.Show("Error loading favourite album.");
            }
        }

        /// <summary>
        /// remove album from favourite list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFromFav_Click(object sender, EventArgs e)
        {
            // remove album
            try
            {
                // let the user know that album has been added to favourite
                MessageBox.Show(database.GetFavAlbum(favAlbumIndex).Title + " has been removed from ur favourite list.");

                // remove the target album
                database.RemoveFavAlbum(database.GetFavAlbum(favAlbumIndex));
                // clear album's information in label
                lblDisplayAlbumInfo.Text = "Title: " + "\r\n" + "Artist: " + "\r\n" +
                                      "Released Year: " + "\r\n" + "Category: "
                                      + "\r\n" + "Description: ";
                picAlbum.Image = null;

                // keep number of favourite album
                favAlbumIndex -= 1;
            }
            // if there's an error, show error message
            catch
            {
                MessageBox.Show("Error removing favourite album.");
            }

        }

        /// <summary>
        /// show favourite albums in label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayFav_Click(object sender, EventArgs e)
        {
            // display favourite albums
            try
            {
                // Edit, remove and recommand is not avaliable while displaying favourite albums
                btnEdit.Hide();
                btnRecommend.Hide();
                btnRemoveAlbum.Hide();
                btnRemoveSong.Hide();

                // to show cancel display, remove album button and hide display button
                btnDisplayFav.Hide();
                btnCancelDisplayFav.Show();
                btnRemoveFromFav.Show();


                // show information in label
                favAlbumIndex = 0;
                DisplayCurrentAlbum();

            }
            // if there's error, show error message
            catch
            {
                
                btnEdit.Show();
                btnDisplayFav.Show();
                MessageBox.Show("Favourite list is null.");
            }
        }

        /// <summary>
        /// to cancel displaying favourite album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelDisplayFav_Click(object sender, EventArgs e)
        {
            // Edit, remove and recommend function is recovered
            btnEdit.Show();
            btnRecommend.Show();
            btnRemoveAlbum.Show();
            btnRemoveSong.Show();

            // to hide cancel display, remove album button and show display button
            btnDisplayFav.Show();
            btnCancelDisplayFav.Hide();
            btnRemoveFromFav.Hide();

            // to show regular album
            DisplayCurrentAlbum();
        }

        /// <summary>
        /// to convert image to string
        /// </summary>
        /// <param name="albumImage"></param>
        /// <returns></returns>
        public string ImageToString(Image albumImage)
        {
            // if there's no image, return null
            if (albumImage == null)
            {
                return String.Empty;
            }

            // convert image to raw format
            MemoryStream stream = new MemoryStream();
            albumImage.Save(stream, albumImage.RawFormat);
            var bytes = stream.ToArray();

            // return converted image string
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// convert string to image
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public Image StringToImage(string base64String)
        {
            // if image equals to null, return null
            if (string.IsNullOrWhiteSpace(base64String))
            {
                return null;
            }

            // convert string to image
            var bytes = Convert.FromBase64String(base64String);
            MemoryStream stream = new MemoryStream(bytes);

            // return image
            return Image.FromStream(stream);
        }

        /// <summary>
        /// to save all information in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            // save information
            try
            {
                string savePath = Application.UserAppDataPath + "\\KpopAlbumDatabase.txt";
                using (StreamWriter file = new StreamWriter(savePath))
                {
                    // write the number of albums
                    file.WriteLine(database.AlbumList.Count);
                    // save albums informations
                    for (int i = 0; i < database.AlbumList.Count; i++)
                    {
                        file.WriteLine(database.AlbumList[i].Title);
                        file.WriteLine(database.AlbumList[i].Artist);
                        file.WriteLine(database.AlbumList[i].Year);
                        file.WriteLine(database.AlbumList[i].Category);
                        file.WriteLine(database.AlbumList[i].Description);
                        file.WriteLine(database.AlbumList[i].AlbumType);
                        // convert image to string
                        string tempImage = ImageToString(database.AlbumList[i].AlbumImage);
                        file.WriteLine(tempImage);

                        file.WriteLine(database.GetAlbum(i).SongList.Count);
                        for (int k = 0; k < database.GetAlbum(i).SongList.Count; k++)
                        {
                            file.WriteLine(database.GetAlbum(i).GetSong(k).SongsName);
                        }
                        file.WriteLine("");
                    }
                    // write the number of favourite albums
                    file.WriteLine(database.FavAlbumList.Count);
                    for (int i = 0; i < database.FavAlbumList.Count; i++)
                    {
                        file.WriteLine(database.FavAlbumList[i].Title);
                        file.WriteLine(database.FavAlbumList[i].Artist);
                        file.WriteLine(database.FavAlbumList[i].Year);
                        file.WriteLine(database.FavAlbumList[i].Category);
                        file.WriteLine(database.FavAlbumList[i].Description);
                        file.WriteLine(database.FavAlbumList[i].AlbumType);
                        // convert image to string
                        string tempFavImage = ImageToString(database.FavAlbumList[i].AlbumImage);
                        file.WriteLine(tempFavImage);
                        file.WriteLine(database.GetFavAlbum(i).SongList.Count);
                        for (int k = 0; k < database.GetFavAlbum(i).SongList.Count; k++)
                        {
                            file.WriteLine(database.GetFavAlbum(i).GetSong(k).SongsName);
                        }
                        file.WriteLine("");
                    }
                }
                // let the user know that it is save
                MessageBox.Show("Information is saved in " + savePath);
            }
            // if there's error, show error message
            catch
            {
                MessageBox.Show("Could not save file! Please try again.");
            }
        }

        /// <summary>
        /// to load saved information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string loadPath = Application.UserAppDataPath + "\\KpopAlbumDatabase.txt";
            // load saved information if there is
            if (File.Exists(loadPath))
            {
                try
                {
                    using (StreamReader file = new StreamReader(loadPath))
                    {
                        // to clear previous information
                        database.AlbumList.Clear();
                   
                        // to get number to loop till
                        int.TryParse(file.ReadLine(), out int num);

                        albumCounter = num;

                        // load regular album information
                        for (int i = 0; i < num; i++)
                        {
                            string title = file.ReadLine();
                            string artist = file.ReadLine();
                            int.TryParse(file.ReadLine(), out int year);
                            string category = file.ReadLine();
                            string description = file.ReadLine();
                            string albumType = file.ReadLine();
                            string image = file.ReadLine();

                            // convert string to image
                            Image tempImage = StringToImage(image);

                            // add the album list
                            database.AddAlbum(title, artist, year, category, description, tempImage, albumType);

                            // song list
                            int.TryParse(file.ReadLine(), out int albumNum);
                            for (int k = 0; k < albumNum; k++)
                            {
                                database.GetAlbum(i).AddSongs(file.ReadLine());
                            }
                            file.ReadLine();
                        }

                        // to clear previous favourtie albums information
                        database.FavAlbumList.Clear();

                        // to get number to loop till
                        int.TryParse(file.ReadLine(), out int favNum);

                        // load favourite album information
                        for (int i = 0; i < favNum; i++)
                        {
                            string title = file.ReadLine();
                            string artist = file.ReadLine();
                            int.TryParse(file.ReadLine(), out int year);
                            string category = file.ReadLine();
                            string description = file.ReadLine();
                            string albumType = file.ReadLine();
                            string image = file.ReadLine();
                            

                            Image tempFavImage = StringToImage(image);

                            database.AddFavAlbum(title, artist, year, category, description, tempFavImage, albumType);
                            // song list
                            int.TryParse(file.ReadLine(), out int albumNum);
                            for (int k = 0; k < albumNum; k++)
                            {
                                database.GetFavAlbum(i).AddSongs(file.ReadLine());
                            }

                            file.ReadLine();
                        }

                    }
                    // let the user know information is loaded
                    MessageBox.Show("Information is loaded!");

                    // displat information in label
                    albumIndex = 0;
                    songIndex = 0;
                    DisplayCurrentAlbum();
                    DisplayCurrentSong(database.GetAlbum(0));
                
                }
                // if there's error, show error message
                catch
                {
                    MessageBox.Show("Error loading file.");
                }
                
            }
            // if there's no saved information previoisly, show "The file could not be found"
            else
            {
                MessageBox.Show("The file could not be found");
            }
        }

    }
}
