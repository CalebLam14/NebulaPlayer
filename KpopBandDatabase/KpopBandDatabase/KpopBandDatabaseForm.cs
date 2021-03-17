/*
 * KpopBandDatabaseForm
 * Hank Yang 
 * January 6, 2020
 * ICS4U_Period_2
 * This program is a database dedicated to kpop bands, the user may perform multiple functions with the bands
 * The KpopBandDataBaseForm  mainly consists of the operations directly related to the tools in the user interface
 * Calls the subprogram needed in other classes in order to perform multipl functions with the bands
 * These functions include add, edit, remove, search, recommend, add to favoruite, remove from favourite, various sorts, a save button & a load button
 *
 */
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
using System.Resources;
using System.Drawing.Imaging;
using System.Reflection;
using System.Security.Permissions;


namespace KpopBandDatabase
{
    public partial class KpopBandDatabaseForm : Form
    {
        // Declare integer variables needed to keep track of the indexes
        private int currentBandIndex = 0, currentFavBandIndex = 0;
        private int currentSingerIndex = 0;
        // Declare a variable of the "ListOfBands" data type
        private ListOfBands theListOfBands = new ListOfBands();
        // Random number generator
        private Random random = new Random();
        // Declare a list needed to store the band Id of the bands that are removed 
        private List<string> deletedBandId = new List<string>();

        // Declare a list needed to store the list of sorts
        private List<Sort> displayMode = new List<Sort>();
        // Declare an integer variable for the displayMode index
        private int displayIndex = 0;

        // Declare a list of bands needed to store the list of bands sorted in certain way according to the current display mode
        private List<Band> sortedBand = new List<Band>();
        // Decalre an integer variable for the current index for the sortedBand
        private int currentIndexSortedBand = 0;

        // Declare a list of bands needed to store the list of bands that is sorted in alphabetical order
        private List<Band> sortedBandByAlpha = new List<Band>();
        // Declare an integer variable for the current index for the List, sortedBandByAlpha
        private int currentIndexSortedByAlpha = 0;

        // Declare a list of bands needed to store the list of bands that is sorted by date
        private List<Band> sortedBandByDate = new List<Band>();
        // Declare an integer variable for the current index for the List, sortedBandByDate
        private int currentIndexSortedByDate = 0;

        // Declare a list of bands needed to store the list of bands that is sorted by gender
        private List<Band> sortedBandByGender = new List<Band>();
        // Declare an integer variable for the current index for the List, sortedBandByGender
        private int currentIndexSortedByGender = 0;

        // Declare a boolean variable to determine whether the program is displaying singers
        private bool singerMode = false;

        // File paths
        string bandFilePath = Application.UserAppDataPath + "\\bandListInfo.txt";
        string favBandFilePath = Application.UserAppDataPath + "\\favBandListInfo.txt";
        string bandImageFilePath = Application.UserAppDataPath + "\\bandImage.txt";
        string favBandImageFilePath = Application.UserAppDataPath + "\\favBandImage.txt";
        string singerFilePath = Application.UserAppDataPath + "\\singerListInfo.txt";
        string favSingerFilePath = Application.UserAppDataPath + "\\favBandListInfo.txt";

        public KpopBandDatabaseForm()
        {
            InitializeComponent();

            // Create new Sort variables that have each child class's datatype
            Sort unsorted = new Unsorted();
            Sort sortNameByAlpha = new SortNameByAlpha();
            Sort sortByDate = new SortByDate();
            Sort sortByGender = new SortByGender();

            // Add in each Sort variables into the list of Sort, displayMode
            displayMode.Add(unsorted);
            displayMode.Add(sortNameByAlpha);
            displayMode.Add(sortByDate);
            displayMode.Add(sortByGender);

            // Add in 4 default bands
            theListOfBands.AddBand(new Band("Bts", 20150714, "Male", 7, "ibighit"));
            theListOfBands.GetBandList[0].BandId = random.Next(10000000, 100000000).ToString();
            theListOfBands.AddBand(new Band("Black Pink", 20181104, "Female", 4, "YG"));
            theListOfBands.GetBandList[1].BandId = random.Next(10000000, 100000000).ToString();
            theListOfBands.AddBand(new Band("Exo", 20190507, "Male", 9, "SM"));
            theListOfBands.GetBandList[2].BandId = random.Next(10000000, 100000000).ToString();
            theListOfBands.AddBand(new Band("Twice", 20161205, "Female", 9, "JYP"));
            theListOfBands.GetBandList[3].BandId = random.Next(10000000, 100000000).ToString();

            btnGoBackToBand.Hide(); // Hide the button

            btnSortByAlpha.Hide(); // Hide the button
            btnSortByDate.Hide(); // Hide the buttone
            btnSortByGender.Hide(); // Hide the button

            lblRecommendBand.Hide(); // Hide the label
            DisplayBand(); // Display band
            DisplayFavBand(); // Display Favourite band

            // hide labels, textboxes, buttons related to singers 
            lblSingerName.Hide();
            txtSingerName.Hide();
            btnAddSinger.Hide();
            btnPreviousSinger.Hide();
            btnNextSinger.Hide();
            lblDisplaySinger.Hide();
        }

        public void AddBand() // Add a band
        {
            // Create a temporary Band with the user inputs in textboxes
            int tempDebutDate, tempNumOfMember;
            int.TryParse(txtBandDebutDate.Text, out tempDebutDate); // Convert string to int, store it
            int.TryParse(txtBandNumOfMem.Text, out tempNumOfMember); // Convert string to int, store it

            if (int.TryParse(txtBandDebutDate.Text, out tempDebutDate) == true && txtBandDebutDate.Text.Trim().Length == 8) // Check if the user inputted valid debut date
            {
                // Create a new temporary band with the information that the user inputted
                Band tempBand = new Band(txtBandName.Text, tempDebutDate, txtBandGender.Text, tempNumOfMember, txtBandCompany.Text);

                // Check if the user succesffully added the band in
                if (theListOfBands.AddBand(tempBand) == true)
                {
                    currentBandIndex = theListOfBands.GetBandList.Count - 1; // Update current index
                    theListOfBands.GetBandList[currentBandIndex].BandId = random.Next(10000000, 100000000).ToString(); // Generate a random band id
                    MessageBox.Show("Band added successfully"); // Display message
                }
                else
                {
                    MessageBox.Show("Band already exist"); // Display message
                }
                // Clear all the textboxes
                txtBandName.Clear();
                txtBandDebutDate.Clear();
                txtBandGender.Clear();
                txtBandNumOfMem.Clear();
                txtBandCompany.Clear();
            }
            else
            {
                MessageBox.Show("Please input valid debut date"); // Display message
            }
            DisplayBand(); // Display band
            DisplayFavBand(); // Display favourite band
        }
        public void EditBand() // Edit a band
        {

            if (theListOfBands.GetBandList.Count > 0) // Check if there's any bands in the list
            {
                // create a temporary band for the band at current index
                Band tempBand = theListOfBands.GetBandList[currentBandIndex];


                string tempName, tempGender, tempCompany; // Create temporary string variables
                int tempDebutDate, tempNumOfMember; // Create temporary integer variables

                if (txtBandName.Text.Trim().Length > 0) // Check if the user inputted a name
                {
                    // To make sure no extra files are created
                    /*
                    if (File.Exists(tempBand.Name + tempBand.Company + ".png"))
                    {
                        File.Move(tempBand.Name + tempBand.Company + ".png", txtBandName.Text + tempBand.Company + ".png");
                    }
                    */
                    tempName = txtBandName.Text; // store it
                }
                else // if not, use the name that the band currently has
                {
                    tempName = tempBand.Name;
                }
                if (txtBandDebutDate.Text.Trim().Length == 0) // Check if the user inputted a debut date, if not use the debut date the band currently has
                {
                    tempDebutDate = tempBand.DebutDate;
                }
                else if (txtBandDebutDate.Text.Trim().Length == 8 && int.TryParse(txtBandDebutDate.Text, out tempDebutDate) == true) // Check if the user inputted a valid debut date
                {
                    int.TryParse(txtBandDebutDate.Text, out tempDebutDate); // store it
                }
                else // if not, use the debut date that the band currently has
                {
                    MessageBox.Show("Please input valid debut date");
                    return;
                }
                if (txtBandGender.Text.Trim().Length > 0) // Check if the user inputted a gender
                {
                    tempGender = txtBandGender.Text; // store it
                }
                else // If not, use the gender that the band currently has
                {
                    tempGender = tempBand.Gender;
                }
                if (txtBandNumOfMem.Text.Trim().Length > 0) // Check if the user inputted the number of members
                {
                    int.TryParse(txtBandNumOfMem.Text, out tempNumOfMember); // store it
                }
                else // If not, use the number of members that the band currently has
                {
                    tempNumOfMember = tempBand.NumOfMember;
                }
                if (txtBandCompany.Text.Trim().Length > 0) // Check if the user inputted the company name
                {
                    tempCompany = txtBandCompany.Text; // Store it
                }
                else // if not, use the company name that the band currently has
                {
                    tempCompany = tempBand.Company;
                }
                // Create a new temporary band using the information inputted by the user
                Band tempBand2 = new Band(tempName, tempDebutDate, tempGender, tempNumOfMember, tempCompany);
                // Edit the band that is at current index
                theListOfBands.EditBand(tempBand2, currentBandIndex);
                MessageBox.Show("Band edited successfully"); // Display message
                // Clear all the textboxes
                txtBandName.Clear();
                txtBandDebutDate.Clear();
                txtBandGender.Clear();
                txtBandNumOfMem.Clear();
                txtBandCompany.Clear();
                DisplayBand();
                DisplayFavBand();
            }
            else // if there are no bands to edit
            {
                MessageBox.Show("There are no bands to edit"); // Display message
            }
        }
        public void RemoveBand() // Remove a band
        {
            if (theListOfBands.GetBandList.Count <= 0) // if there's nothing in the list of bands, exist the subprogram
            {
                MessageBox.Show("There are no bands to remove"); // Display message
                return;
            }
            // Make sure that the band gets removed in the favourite list of bands too
            if (theListOfBands.GetFavBandList.Contains(theListOfBands.GetBandList[currentBandIndex]) == true)
            {
                int tempIndex = 0; // Create a temporary integer variable
                for (int i = 0; i < theListOfBands.GetFavBandList.Count; i++)
                {
                    // Find the index where band in favourite list of bands is equal to the band that exist at current band index within the list of bands
                    if (theListOfBands.GetFavBandList[i] == theListOfBands.GetBandList[currentBandIndex])
                    {
                        tempIndex = i; // Store the index where favourite band should also be removed
                        break;
                    }
                }
                if (theListOfBands.RemoveFavBand(tempIndex) == true) // Remove the favourite band that is at the temp band index
                {
                    MessageBox.Show("Band removed from my favourite Successfully"); // Display message
                }
                else
                {
                    MessageBox.Show("Band removal from my favourite failed"); // Display message
                }
                currentFavBandIndex--; // Decrease current favourite band index by one
                if (currentFavBandIndex < 0) // Make sure favourite band index does not go into the negative
                {
                    currentFavBandIndex = 0;
                }
                DisplayFavBand(); // Display favourite band
            }
            // To potentially store the band that will be removed, in order to delete image files accordingly when the save button is clicked
            Band tempRemovedBand = theListOfBands.GetBandList[currentBandIndex];

            // The actual removal of the band from the regular list of bands
            if (theListOfBands.RemoveBand(currentBandIndex) == true) // Remove the band that is at the current index
            {
                // store the id of the bands that are removed
                deletedBandId.Add(tempRemovedBand.BandId);

                MessageBox.Show("Band removed Successfully"); // Display message
            }
            else
            {
                MessageBox.Show("Band removal failed"); // Display message
            }
            currentBandIndex--; // Decrease current band index by one
            if (currentBandIndex < 0) // Make sure band index does not go into the negative
            {
                currentBandIndex = 0;
            }
            DisplayBand(); // Display band
        }


        public void DisplayBand() // Display the current band's information
        {
            if (theListOfBands.GetBandList.Count == 0) // If there are no bands, display nothing
            {
                lblDisplayBand.Text = "";
                picBand.Image = null;
            }
            else 
            {
                Band tempBand = theListOfBands.GetBandList[currentBandIndex]; // Get the specific band at the current index 
                                                                              // Print out all the band's information onto label
                lblDisplayBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picBand.Image = theListOfBands.GetBandList[currentBandIndex].BandPfp; // Display image
            }
        }
        
        public void DisplaySortedBand()
        {
            if (sortedBand.Count == 0) // If there are no bands, display nothing
            {
                lblDisplayBand.Text = "";
                picBand.Image = null;
            }
            else
            {
                Band tempBand = sortedBand[currentIndexSortedBand]; // Get the specific band at the currentIndexSortedBand
                                                                              // Print out all the band's information onto label
                lblDisplayBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picBand.Image = sortedBand[currentIndexSortedBand].BandPfp; // Display image
            }
        }

        public void DisplayBandSortedByAlpha() // Display the current band's information in alphabetical order
        {
            if (sortedBandByAlpha.Count == 0) // If there are no bands, display nothing
            {
                lblDisplayBand.Text = "";
                picBand.Image = null;
            }
            else
            {
                Band tempBand = sortedBandByAlpha[currentIndexSortedByAlpha]; // Get the specific band at the current index of the list of band sorted in alphabetical order
                                                                              // Print out all the band's information onto label
                lblDisplayBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picBand.Image = sortedBandByAlpha[currentIndexSortedByAlpha].BandPfp; // Display image
            }
        }

        public void DisplayBandSortedByDate() // Display the current band's information in order by date from recent to old
        {
            if (sortedBandByDate.Count == 0) // If there are no bands, display nothing
            {
                lblDisplayBand.Text = "";
                picBand.Image = null;
            }
            else
            {
                Band tempBand = sortedBandByDate[currentIndexSortedByDate]; // Get the specific band at the current index of the list of bands sorted by date
                                                                              // Print out all the band's information onto label
                lblDisplayBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picBand.Image = sortedBandByDate[currentIndexSortedByDate].BandPfp; // Display image
            }
        }

        public void DisplayBandSortedByGender() // Display the current band's information in order by gender (male, female, other)
        {
            if (sortedBandByGender.Count == 0) // If there are no bands, display nothing
            {
                lblDisplayBand.Text = "";
                picBand.Image = null;
            }
            else
            {
                Band tempBand = sortedBandByGender[currentIndexSortedByGender]; // Get the specific band at the current index of the list of bands sorted by gender
                                                                            // Print out all the band's information onto label
                lblDisplayBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picBand.Image = sortedBandByGender[currentIndexSortedByGender].BandPfp; // Display image
            }
        }

        public void SortBandByGender() // Sort the list of bands in the order of gender, male then female, then others
        {
            theListOfBands.SortBandByGender();
            currentBandIndex = 0; // Reset index
            DisplayBand(); // Display band
        }
        public void SortBandByDate() // Sort the list of bands in the order of debut date, male then female, then others
        {
            theListOfBands.SortBandByDate();
            currentBandIndex = 0; // Reset index
            DisplayBand(); // Display band
        }
        public void SortBandByAlpha() // Sort the list of bands in alphabetical order from A to Z
        {
            theListOfBands.SortBandByAlpha();
            currentBandIndex = 0; // Reset index 
            DisplayBand(); // Display band
        }

        public void AddFavBand() // Add a band to my favourite
        {
            if (theListOfBands.GetBandList.Count > 0) // Check if there's any bands in the list
            {
                Band tempBand = theListOfBands.GetBandList[currentBandIndex]; // Get the specific band at the current index 
                                                                              // Check if the user succesffully added the band into my favourite
                if (theListOfBands.AddFavBand(tempBand) == true)
                {
                    currentFavBandIndex = theListOfBands.GetFavBandList.Count - 1; // Changes the current favourite band index to the one that is just added
                    MessageBox.Show("Band added to my favourite successfully"); // Display message
                }
                else
                {
                    MessageBox.Show("Band already exist in my favourite"); // Display message
                }
                DisplayFavBand(); // Display favourite band
            }
            else // if there are no bands in the list for the user to add to my favourite
            {
                MessageBox.Show("No bands to add to my favourite"); // Display message
            }
            
        }
        public void RemoveFavBand() // Remove a band from my favourite
        {
            if (theListOfBands.GetFavBandList.Count == 0) // if there's nothing in the list of favourite bands, exist the subprogram
            {
                MessageBox.Show("There are no bands in my favourite to remove"); // Display message
                return;
            }
            if (theListOfBands.RemoveFavBand(currentFavBandIndex) == true) // Remove the favourite band that is at the current favourite band index
            {
                MessageBox.Show("Band removed from my favourite Successfully"); // Display message
            }
            else
            {
                MessageBox.Show("Band removal from my favourite failed"); // Display message
            }
            currentFavBandIndex--; // Decrease current favourite band index by one
            if (currentFavBandIndex < 0) // Make sure favourite band index does not go into the negative
            {
                currentFavBandIndex = 0;
            }
            DisplayFavBand(); // Display favourite band
        }
        public void DisplayFavBand() //Display favourite bands
        {
            if (theListOfBands.GetFavBandList.Count == 0) // If there are no favourite bands, display nothing
            {
                lblDisplayFavBand.Text = "";
                picFavBand.Image = null;
            }
            else
            {
                Band tempBand = theListOfBands.GetFavBandList[currentFavBandIndex]; // Get the specific band at the current index 
                                                                                    // Print out all the favourite band's information onto label
                lblDisplayFavBand.Text = "Name: " + tempBand.Name + "\r\nDebut Date: " + tempBand.DebutDate + "\r\nGender: " + tempBand.Gender + "\r\n# of Members: " + tempBand.NumOfMember + "\r\nCompany Name: " + tempBand.Company;
                picFavBand.Image = theListOfBands.GetFavBandList[currentFavBandIndex].BandPfp; // Display image
            }
        }

        // Search band function
        public void SearchBandAndDisplay()
        {
            displayIndex = 0; // reset display index
            if (txtSearchBand.Text.Trim().Length > 0) // Check if the user inputted anything into the serach box
            {
                int tempIndex = theListOfBands.SearchBandAndDisplay(txtSearchBand.Text); // Store the return value of SearchBandAndDisplay (normal index or -1)
                if (tempIndex == -1) // If the band does not exist
                {
                    MessageBox.Show("Cannot find this band"); // Display message
                }
                else
                {
                    currentBandIndex = tempIndex; // Switches current index to where the band was found
                    MessageBox.Show("Band found"); // Display message
                    DisplayBand(); // Display band
                }
            }
            else
            {
                MessageBox.Show("Please input something into the search box"); // Display error message
            }
        }

        private void btnAddBand_Click(object sender, EventArgs e)
        {
            currentSingerIndex = 0; // reset current singer index to zero
            AddBand(); // Calls AddBand subprogram
        }
        private void btnRemoveBand_Click(object sender, EventArgs e)
        {
            currentSingerIndex = 0; // reset current singer index to zero
            RemoveBand(); // Calls RemoveBand subprogram
        }
        private void btnEditBand_Click(object sender, EventArgs e)
        {
            EditBand(); // Calls EditBand subprogram
        }
        private void btnAddFavBand_Click(object sender, EventArgs e)
        {
            AddFavBand(); // Calls AddFavBand subprogram
        }
        private void btnRemoveFavBand_Click(object sender, EventArgs e)
        {
            RemoveFavBand(); // Calls RemoveFavBand subprogram
        }
        private void btnSortByAlpha_Click(object sender, EventArgs e)
        {
            SortBandByAlpha(); // Calls SortBandByAlpha subprogram
        }
        private void btnSortByDate_Click(object sender, EventArgs e)
        {
            SortBandByDate(); // Calls SortBandByDate subprogram
        }
        private void btnSortByGender_Click(object sender, EventArgs e)
        {
            SortBandByGender(); // Calls SortBandByGender subprogram
        }
        private void btnSearchBand_Click(object sender, EventArgs e)
        {
            currentSingerIndex = 0; // reset current singer index to zero
            SearchBandAndDisplay(); // Calls SearchBandAndDisplay subprogram
            txtSearchBand.Clear(); // Clear the search textbox
        }

        private void btnPreviousBand_Click(object sender, EventArgs e) // Move to the previous band
        {
            currentSingerIndex = 0; // reset current singer index to zero
            if (displayMode[displayIndex] is Unsorted) // Check if the current display mode is Unsorted
            {
                currentBandIndex--; // Subtract one from current band index
                if ((currentBandIndex >= 0) && (currentBandIndex < theListOfBands.GetBandList.Count)) // Check if the current band index >= 0 & less than the length of the bands list
                {
                    DisplayBand(); // Display band
                }
                else
                {
                    currentBandIndex = 0; // Reset the current band index back to ZERO
                }
            }
            else
            {
                currentIndexSortedBand--; // Subtract one from currentIndexSortedBand
                if ((currentIndexSortedBand >= 0) && (currentIndexSortedBand < sortedBand.Count)) // Check if currentIndexSortedBand >= 0 & less than the length of the bands list
                {
                    DisplaySortedBand(); // Display band
                }
                else
                {
                    currentIndexSortedBand = 0; // Reset currentIndexSortedBand back to ZERO
                }
            }
            
        }

        private void btnNextBand_Click(object sender, EventArgs e) // Move to the next band
        {
            currentSingerIndex = 0; // reset current singer index to zero
            if (theListOfBands.GetBandList.Count != 0) // Check if there's no bands in the list
            {
                if (displayMode[displayIndex] is Unsorted) // Check if the current display mode is Unsorted
                {
                    currentBandIndex++; // Add one to current band index
                    if (currentBandIndex >= 0 && (currentBandIndex < theListOfBands.GetBandList.Count)) // Check if the current band index >= 0 & less than the length of the bands list
                    {
                        DisplayBand(); // Display band
                    }
                    else
                    {
                        currentBandIndex = theListOfBands.GetBandList.Count - 1; // Reset the current band index back to the largest index of the bands list
                    }
                }
                else
                {
                    currentIndexSortedBand++; // Add one to currentIndexSortedBand
                    if (currentIndexSortedBand >= 0 && (currentIndexSortedBand < sortedBand.Count)) // Check if currentIndexSortedBand >= 0 & less than the length of the bands list
                    {
                        DisplaySortedBand(); // Display band
                    }
                    else
                    {
                        currentIndexSortedBand = sortedBand.Count - 1; // Reset currentIndexSortedBand back to the largest index of the bands list
                    }
                }
                
            }
        }

        private void btnPreviousFavBand_Click(object sender, EventArgs e) // Move to the previous favourite band
        {
            if (theListOfBands.GetFavBandList.Count != 0) // Check if there's no bands in the list
            {
                currentFavBandIndex--; // Subtract one from current favourite band index
                if ((currentFavBandIndex >= 0) && (currentFavBandIndex < theListOfBands.GetFavBandList.Count)) // Check if the index >= 0 & less than the length of the favourite bands list
                {
                    DisplayFavBand(); // Display favourite band
                }
                else
                {
                    currentFavBandIndex = 0; // Reset the current favourite band index back to ZERO
                }
            }
            
        }

        private void btnNextFavBand_Click(object sender, EventArgs e) // Move to the next favourite band
        {
            if (theListOfBands.GetFavBandList.Count != 0) // Check if there's no bands in the my favourite band list
            {
                currentFavBandIndex++; // Add one from current favourite band index
                if ((currentFavBandIndex >= 0) && (currentFavBandIndex < theListOfBands.GetFavBandList.Count)) // Check if the current favourite band index >= 0 & less than the length of the favourite band list
                {
                    DisplayFavBand(); // Display favourite
                }
                else
                    currentFavBandIndex = theListOfBands.GetFavBandList.Count - 1; // Reset the current favourite band index back to the largest index of the favourite band list
            }
        }

        private void btnRecommendBand_Click(object sender, EventArgs e) // Shows a band recommendation
        {
            currentSingerIndex = 0; // reset current singer index to zero
            displayIndex = 0; // Reset display mode index
            if (theListOfBands.GetBandList.Count <= 0) // Check if there are any bands
            {
                MessageBox.Show("Sorry, there are no bands to be recommended"); // Display message
                return;
            }
            lblRecommendBand.Show(); // Show the label
            currentBandIndex = random.Next(0, theListOfBands.GetBandList.Count); // Generates a random number, sets the current band index as the random number
            // Display the message
            lblRecommendBand.Text = theListOfBands.GetBandList[currentBandIndex].Name + " is one of the hottest kpop band right now!";
            DisplayBand(); // Display band
        }

        private void btnSave_Click(object sender, EventArgs e) // Save all the bands information inputted into the program
        {
            // To make sure there are no extra images created
            // Delete the image files that match the names stored in the list of deleted bands' ids
            for (int i = 0; i < deletedBandId.Count; i++) // Loop through the the list of deleted band ids
            {
                if (File.Exists(deletedBandId[i] + ".png")) // Check if the deleted band id exist
                {
                    File.Delete(deletedBandId[i] + ".png"); // If it exist, delete the file
                }
            }

            // Saves the list of bands
            try
            {
                if (!File.Exists(bandFilePath))
                {
                    File.Create(bandFilePath);
                }
                using (StreamWriter file = new StreamWriter(bandFilePath)) // Method for file output
                {
                    file.WriteLine(theListOfBands.GetBandList.Count); // Save the number of bands
                    for (int i = 0; i < theListOfBands.GetBandList.Count; i++) // Loop through the list of bands
                    {
                        // Write out all the bands information into a txt file
                        file.WriteLine(theListOfBands.GetBandList[i].Name);
                        file.WriteLine(theListOfBands.GetBandList[i].DebutDate);
                        file.WriteLine(theListOfBands.GetBandList[i].Gender);
                        file.WriteLine(theListOfBands.GetBandList[i].NumOfMember);
                        file.WriteLine(theListOfBands.GetBandList[i].Company);
                    }
                }
                if (theListOfBands.GetBandList.Count <= 0) // Check if the band list has NOTHING in there
                {
                    MessageBox.Show("You saved a list of band with no information in there"); // Display message
                }
                else
                {
                    MessageBox.Show("list of bands saved"); // Display message
                }
            }
            catch
            {
                MessageBox.Show("Couldn't save the list of bands"); // Display message
            }

            // Saves name of band images 
            try
            {
                if (!File.Exists(bandImageFilePath)) // Check if the file name exist
                {
                    File.Create(bandImageFilePath);
                }
                using (StreamWriter file = new StreamWriter(bandImageFilePath)) // Method for file output
                {
                    file.WriteLine(theListOfBands.GetBandList.Count); // Save the number of bands
                    for (int i = 0; i < theListOfBands.GetBandList.Count; i++) // Loop through the list of bands
                    {
                        Band tempBand = theListOfBands.GetBandList[i]; // Create a temporary band at index i
                        if (tempBand.BandPfp == null) // Check if the temporary band has an image
                        {
                            file.WriteLine(""); // if it does not have an image, write a blank line
                        }
                        else
                        {
                            // Update the images
                            tempBand.BandPfp.Save( tempBand.BandId + ".png", ImageFormat.Png); 
                            // Write out all the names of band images
                            file.WriteLine(tempBand.BandId + ".png");
                        }
                    }
                    if (theListOfBands.GetBandList.Count <= 0) // Check if the band list has NOTHING in there
                    {
                        MessageBox.Show("You saved a list of band with no images in there"); // Display message
                    }
                    else
                    {
                        MessageBox.Show("Images of the list of bands saved"); // Display message
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error when saving the images of the list of bands"); // Display error message
            }

            // Saves the list of favourite bands
            try
            {
                if (!File.Exists(favBandFilePath))
                {
                    File.Create(favBandFilePath);
                }
                using (StreamWriter file = new StreamWriter(favBandFilePath)) // Method for file output
                {
                    file.WriteLine(theListOfBands.GetFavBandList.Count); // Save the number of favourite bands
                    for (int i = 0; i < theListOfBands.GetFavBandList.Count; i++) // Loop through the list favourite band=s
                    {
                        // Write out all the favourite bands information into a txt file
                        file.WriteLine(theListOfBands.GetFavBandList[i].Name);
                        file.WriteLine(theListOfBands.GetFavBandList[i].DebutDate);
                        file.WriteLine(theListOfBands.GetFavBandList[i].Gender);
                        file.WriteLine(theListOfBands.GetFavBandList[i].NumOfMember);
                        file.WriteLine(theListOfBands.GetFavBandList[i].Company);
                    }
                }
                if (theListOfBands.GetFavBandList.Count <= 0) // Check if the favourite bands list has NOTHING in it
                {
                    MessageBox.Show("You saved a list of favourite band with no information in there"); // Display message
                }
                else
                {
                    MessageBox.Show("list of favourite bands saved"); // Display message
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Couldn't save the list of favourite bands: " + ex.Message); // Display message
            }

            // Saves the name of favourite band images
            try
            {
                if (!File.Exists(favBandImageFilePath))
                {
                    File.Create(favBandImageFilePath);
                }
                using (StreamWriter file = new StreamWriter(favBandImageFilePath)) // Method for file output
                {
                    file.WriteLine(theListOfBands.GetFavBandList.Count); // Save the number of favourite bands
                    for (int i = 0; i < theListOfBands.GetFavBandList.Count; i++) // Loop through the list of favourite bands
                    {
                        Band tempBand = theListOfBands.GetFavBandList[i]; // Create a temporary favourite band at index i
                        if (tempBand.BandPfp == null) // Check if the temporary band has an image
                        {
                            file.WriteLine(""); // If it does not have an image, write a blank line
                        }
                        else
                        {
                            // Update the images
                            tempBand.BandPfp.Save(tempBand.BandId + ".png", ImageFormat.Png);
                            // Save all the names of band images
                            file.WriteLine(tempBand.BandId + ".png");
                        }
                    }
                    if (theListOfBands.GetFavBandList.Count <= 0) // Check if the favourite bands list has NOTHING in it
                    {
                        MessageBox.Show("You saved a list of favourite band with no images in there"); // Display message
                    }
                    else
                    {
                        MessageBox.Show("Images of the list of favourite bands saved"); // Display message
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when saving the images of the list of favourite bands: " + ex.Message); // Display message
            }

            // Saves the list of singers  
            try
            {
                if (!File.Exists(singerFilePath))
                {
                    File.Create(singerFilePath);
                }
                using (StreamWriter file = new StreamWriter(singerFilePath)) // Method for file output
                {
                    file.WriteLine(theListOfBands.GetBandList.Count); // Save the number of bands
                    for (int i = 0; i < theListOfBands.GetBandList.Count; i++) // Loop through the list of bands
                    {
                        file.WriteLine(theListOfBands.GetBand(i).GetSingerList.Count); // Save the number of singers
                        for (int k = 0; k < theListOfBands.GetBand(i).GetSingerList.Count; k++) // Loop through  the list of singers
                        {
                            file.WriteLine(theListOfBands.GetBand(i).GetSinger(k).Name); // Print out the singer name
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Couldn't save the list of singers: " + ex.Message); // Display message
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) // Load the bands information previously saved
        {
            // To load the information for the list of bands
            try
            {
                using (StreamReader file = new StreamReader(bandFilePath)) // Method for file input
                {
                    int numOfSavedBands; // Declare an integer variable
                    int.TryParse(file.ReadLine(), out numOfSavedBands); // To check how many bands were saved in the file
                    if (numOfSavedBands == 0) // If there are no bands to load, exist the subprogram
                    {
                        MessageBox.Show("There are no bands information to load"); // Display message
                        return;
                    }
                    int numOfCurrentBands = theListOfBands.GetBandList.Count; // Store the number of bands needed to be wiped out
                    for (int i = 0; i < numOfCurrentBands; i++) // Wipe out all the information in the list of bands
                    {
                        RemoveBand();
                    }
                    // keep reading lines one at a time until it reaches the end of the file
                    while (file.Peek() != -1)
                    {
                        for (int i = 0; i < numOfSavedBands; i++) // Repeat as many times as the number of saved bands
                        {
                            // Load all the bands information
                            // Re-adds all the saved bands information back to the list of bands
                            string tempName = file.ReadLine();
                            int tempDebutDate;
                            int.TryParse(file.ReadLine(), out tempDebutDate);
                            string tempGender = file.ReadLine();
                            int tempNumOfMem;
                            int.TryParse(file.ReadLine(), out tempNumOfMem);
                            string tempCompany = file.ReadLine();
                            // Add a new band using the previously saved information
                            theListOfBands.AddBand(new Band(tempName, tempDebutDate, tempGender, tempNumOfMem, tempCompany));
                        }
                    }
                }
                MessageBox.Show("List of bands loaded successfully"); // Display message
                currentBandIndex = 0; // Reset the index to the start
                DisplayBand(); // Display the loaded result for the list of bands
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured when loading the list of bands: " + ex.Message); // Display error message
            }
            

            try
            {
                using (StreamReader file = new StreamReader(bandImageFilePath)) // Method for file input
                {
                    int numOfSavedBands; // Declare an integer variable
                    int.TryParse(file.ReadLine(), out numOfSavedBands); // To check how many bands were saved in the file
                    if (numOfSavedBands == 0) // If there are no bands to load, exist the subprogram
                    {
                        // do nothing
                    }
                    else
                    {
                        for (int i = 0; i < numOfSavedBands; i++) // Loop up to the number of saved bands
                        {
                            string tempFileName = file.ReadLine(); // Creates a temporary string varaible that saves the line that is being read
                            if (tempFileName != "") // Check if the line being read is a blank line
                            {
                                // If the line does not have a blank line(meaning there is an image)
                                // Add in the band image using the previously saved image
                                theListOfBands.GetBandList[i].BandPfp = new Bitmap(tempFileName);
                            }
                        }
                        DisplayBand(); // Display band
                        MessageBox.Show("Images of the list of bands loaded successfully"); // Display message
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured when loading the images of the list of bands: " + ex.Message); // Display error message
            }

            // To load the information for the list of singers
            try
            {
                using (StreamReader file = new StreamReader(singerFilePath)) // Method for file input
                {
                    int numOfSavedBands; // Declare an integer variable
                    int.TryParse(file.ReadLine(), out numOfSavedBands); // To check how many bands were saved in the file
                    // keep reading lines one at a time until it reaches the end of the file
                    while (file.Peek() != -1)
                    {
                        for (int i = 0; i < numOfSavedBands; i++) // Repeat as many times as the number of saved bands
                        {
                            int numOfSavedSingers; // Declare an integer variable
                            int.TryParse(file.ReadLine(), out numOfSavedSingers); // To check how many singers were saved in the file

                            for (int k = 0; k < numOfSavedSingers; k++) // Repeat as many times as the number of saved singers
                            {
                                theListOfBands.GetBand(i).AddSinger(new Singer(file.ReadLine())); // Load back singer data
                            }
                        }
                    }
                }
                DisplaySinger(); // Display the loaded result for the list of bands

            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured when loading the list of singers: " + ex.Message); // Display error message
            }

            // To load the information for the list of favourite bands
            try
            {
                using (StreamReader file = new StreamReader(favSingerFilePath)) // Method for file input
                {
                    int numOfSavedFavBands; // Declare an integer variable
                    int.TryParse(file.ReadLine(), out numOfSavedFavBands); // To check how many bands were saved in the file
                    if (numOfSavedFavBands == 0) // If there are no bands to load, exist the subprogram
                    {
                        MessageBox.Show("There are no favourite bands information to load"); // Display message
                        return;
                    }
                    int numOfCurrentFavBands = theListOfBands.GetFavBandList.Count; // Store the number of favourite bands needed to be wiped out
                    for (int i = 0; i < numOfCurrentFavBands; i++) // Wipe out all the information in the list of favourite bands
                    {
                        RemoveFavBand();
                    }
                    // keep reading lines one at a time until it reaches the end of the file
                    while (file.Peek() != -1)
                    {
                        for (int i = 0; i < numOfSavedFavBands; i++) // Repeat as many times as the number of saved favoutite bands
                        {
                            // Load all the favourite bands information
                            // Re-adds all the saved favourite bands information back to the list of favourite bands
                            string tempName = file.ReadLine();
                            int tempDebutDate;
                            int.TryParse(file.ReadLine(), out tempDebutDate);
                            string tempGender = file.ReadLine();
                            int tempNumOfMem;
                            int.TryParse(file.ReadLine(), out tempNumOfMem);
                            string tempCompany = file.ReadLine();
                            theListOfBands.AddFavBand(new Band(tempName, tempDebutDate, tempGender, tempNumOfMem, tempCompany));
                        }
                    }
                }
                MessageBox.Show("List of favourite bands loaded successfully"); // Display message
                currentFavBandIndex = 0; // Reset the favourite band index back to the start
                DisplayFavBand(); // Display the loaded result for the list of favourite bands
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured when loading the list of favourite bands: " + ex.Message); // Display message
            }


            try
            {
                using (StreamReader file = new StreamReader(favBandImageFilePath)) // Method for file input
                {
                    int numOfSavedBands; // Declare an integer variable
                    int.TryParse(file.ReadLine(), out numOfSavedBands); // To check how many bands were saved in the file
                    if (numOfSavedBands == 0) // If there are no bands to load, exist the subprogram
                    {
                        // do nothing
                    }
                    else
                    {
                        for (int i = 0; i < numOfSavedBands; i++) // Loop up to the number of saved bands
                        {
                            string tempFileName = file.ReadLine(); // Creates a temporary string variable that saves the line that is being read
                            if (tempFileName != "") // Check if the line being read is a blank line
                            {
                                // If the line does not have a blank line(meaning there is an image)
                                // Add in the favourite band image using the previously saved image
                                theListOfBands.GetFavBandList[i].BandPfp = new Bitmap(tempFileName);
                            }
                        }
                        DisplayFavBand(); // Display band
                        MessageBox.Show("Images of the list of favourite bands loaded successfully"); // Display message
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured when loading the images of the list of favourite bands: " + ex.Message); // Display error message
            }

            


        }
        private void btnUploadBandPfp_Click(object sender, EventArgs e) // To upload pictures
        {
            if (theListOfBands.GetBandList.Count == 0) // Check if there are no bands, if yes, exist subprogram
            {
                MessageBox.Show("Please Add a band first"); // Display message
                return;
            }
            string fileName = ""; // Creates a string variable
            Band tempBand = theListOfBands.GetBandList[currentBandIndex]; // Create a temporary band that has an index at current band index
            uploadBandPfpDialog.Title = "Upload Band Picture"; // Title of the open dialog window
            if (uploadBandPfpDialog.ShowDialog() == DialogResult.OK)  // Check if user clicks okay on the open dialog window
            {
                // if yes, store the path of the file selected by the user
                fileName = uploadBandPfpDialog.FileName;
                MessageBox.Show(fileName); // Display the path of the file selected
            }
            else // If the user does not click OK, exist subprogram
            {
                return;
            }
            // With the file path, create a new bitmap(picture) and save it as the profile picture of the band that is at current band index
            tempBand.BandPfp = new Bitmap(fileName);
            MessageBox.Show("Picture uploaded successfully"); // Display message
            DisplayBand(); // Display band
            DisplayFavBand(); // Display favourite band
        }


        private void btnSort_Click(object sender, EventArgs e)
        {
            if (displayIndex < displayMode.Count - 1) // Check if the display index is less than the lenght of displayMode - 1
            {
                displayIndex++; // Increment display index
            }
            else if (displayIndex == displayMode.Count - 1) // Check if the display index equales to the legnth of displayMode - 1
            {
                displayIndex = 0; // Reset display index
            }

            if (displayMode[displayIndex] is Unsorted)
            {
                currentBandIndex = 0; // reset current band index
                DisplayBand();
                return;
            }
            else if (displayMode[displayIndex] is SortNameByAlpha)
            {
                sortedBand = displayMode[displayIndex].DoSort(theListOfBands.GetBandList);
                currentIndexSortedBand = 0; // reset current band index of the sorted band
                DisplaySortedBand();
            }
            else if (displayMode[displayIndex] is SortByDate)
            {
                sortedBand = displayMode[displayIndex].DoSort(theListOfBands.GetBandList);
                currentIndexSortedBand = 0; // reset current band index of the sorted band
                DisplaySortedBand();
            }
            else if (displayMode[displayIndex] is SortByGender)
            {
                sortedBand = displayMode[displayIndex].DoSort(theListOfBands.GetBandList);
                currentIndexSortedBand = 0; // reset current band index of the sorted band
                DisplaySortedBand();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // Singer functions
        public void AddSinger()
        {
            
        }
        public void EditSinger()
        {

        }
        public void RemoveSinger()
        {

        }
        /*
        public void DisplaySinger()
        {

        }
        */
        public void SortSingerByAge()
        {

        }
        public void SortSingerByHeight()
        {

        }
        public void SortSingerByWeight()
        {

        }
        // Favourite singer functions
        public void AddFavSinger()
        {

        }
        public void RemoveFavSinger()
        {

        }
        public void DisplayFavSinger()
        {

        }
        // Search singer function
        public void SearchSingerAndDisplay()
        {

        }
        private void btnDisplayBandSingers_Click(object sender, EventArgs e)
        {
            /*
            foreach (var lbl in Controls.OfType<Label>())
                lbl.Hide();

            foreach (var btn in Controls.OfType<Button>())
                btn.Hide();

            foreach (var txt in Controls.OfType<TextBox>())
                txt.Hide();
                */

            DisplaySinger(); // Display singer
            singerMode = true; // Set singer mode to true

            btnDisplayBandSingers.Hide(); // Hide button
            btnGoBackToBand.Show(); // Show button

            // Show labels, textboxes, buttons related to singers
            lblSingerName.Show();
            txtSingerName.Show();
            btnAddSinger.Show();
            btnRemoveSinger.Show();
            btnPreviousSinger.Show();
            btnNextSinger.Show();
            lblDisplaySinger.Show();
        }

        private void btnGoBackToBand_Click(object sender, EventArgs e)
        {
            /*
            foreach (var lbl in Controls.OfType<Label>())
                lbl.Show();

            foreach (var btn in Controls.OfType<Button>())
                btn.Show();

            foreach (var txt in Controls.OfType<TextBox>())
                txt.Show();
                */

            singerMode = false; // Set singer mode to false

            btnGoBackToBand.Hide(); // Hide button
            btnDisplayBandSingers.Show(); // Show button

            // Hide labels, textboxes, buttons related to singers 
            lblSingerName.Hide();
            txtSingerName.Hide();
            btnAddSinger.Hide();
            btnRemoveSinger.Hide();
            btnPreviousSinger.Hide();
            btnNextSinger.Hide();
            lblDisplaySinger.Hide();

            // reset current singer index
            currentSingerIndex = 0;
        }

        public void DisplaySinger() // Display the current singer's information
        {
            // Check if the band list has any element, if not, do nothing
            if (theListOfBands.GetBandList.Count <= 0)
            {
                return;
            }
            if (theListOfBands.GetBandList[currentBandIndex].GetSingerList.Count == 0) // If there are no singers, display nothing
            {
                lblDisplaySinger.Text = "";
            }
            else
            {
                Singer tempSinger = theListOfBands.GetBandList[currentBandIndex].GetSingerList[currentSingerIndex]; // Get the specific Singer at the current index 
                                                                                                                    // Print out all the singer's information onto label
                lblDisplaySinger.Text = "Name: " + tempSinger.Name;
            }
        }

        private void btnAddSinger_Click(object sender, EventArgs e)
        {
            // Create a new temporary singer with the information that the user inputted
            Singer tempSinger = new Singer(txtSingerName.Text);
            // Create a new temporary band at current band index
            Band currentBand = theListOfBands.GetBandList[currentBandIndex];

            // Check if the user succesffully added the band in
            if (currentBand.AddSinger(tempSinger) == true)
            {
                currentSingerIndex = currentBand.GetSingerList.Count - 1; // Update current index
                MessageBox.Show("Singer added successfully"); // Display message
            }
            else
            {
                MessageBox.Show("Singer already exist"); // Display message
            }
            // Clear the textbox
            txtSingerName.Clear();

            DisplaySinger(); // Display singer
        }

        private void btnRemoveSinger_Click(object sender, EventArgs e)
        {
            // Create a new temporary band at current band index
            Band currentBand = theListOfBands.GetBandList[currentBandIndex];

            if (currentBand.GetSingerList.Count <= 0) // if there's nothing in the list of singers, exist the subprogram
            {
                MessageBox.Show("There are no bands to remove"); // Display message
                return;
            }

            // The actual removal of the singer from the regular list of singers
            if (currentBand.RemoveSinger(currentSingerIndex) == true) // Remove the singer that is at the current index
            {
                MessageBox.Show("Singer removed Successfully"); // Display message
            }
            else
            {
                MessageBox.Show("Singer removal failed"); // Display message
            }
            currentSingerIndex--; // Decrease current singer index by one
            if (currentSingerIndex < 0) // Make sure singer index does not go into the negative
            {
                currentSingerIndex = 0;
            }
            DisplaySinger(); // Display singer
        }

        private void btnPreviousSinger_Click(object sender, EventArgs e)
        {
            currentSingerIndex--; // Subtract one from current singer index
            if ((currentSingerIndex >= 0) && (currentSingerIndex < theListOfBands.GetBandList[currentBandIndex].GetSingerList.Count)) // Check if the current singer index >= 0 & less than the length of the singers list
            {
                DisplaySinger(); // Display singer
            }
            else
            {
                currentSingerIndex = 0; // Reset the current singer index back to ZERO
            }
        }

        private void btnNextSinger_Click(object sender, EventArgs e)
        {
            // Store the length of the list of singers
            int singerListCount = theListOfBands.GetBandList[currentBandIndex].GetSingerList.Count;
            if (singerListCount != 0) // Check if there's no singers in the list
            {
                currentSingerIndex++; // Add one to current singer index
                if (currentSingerIndex >= 0 && (currentSingerIndex < singerListCount)) // Check if the current singer index >= 0 & less than the length of the singers list
                {
                    DisplaySinger(); // Display singer
                }
                else
                {
                    currentSingerIndex = singerListCount - 1; // Reset the current singer index back to the largest index of the singers list
                }
            }
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            // To test out my current indexes
            lblTest1.Text = currentBandIndex.ToString();
            lblTest2.Text = currentFavBandIndex.ToString();

            DisplaySinger(); // display singer

            if (displayMode[displayIndex] is Unsorted) // Check if the current display mode is Unsorted
            {
                lblDisplayMode.Text = "Display Mode: Unsorted";// Display text

                // Show all the labels, buttons and textboxes
                lblDisplayFavBand.Show();
                btnPreviousFavBand.Show();
                btnNextFavBand.Show();
                btnRemoveFavBand.Show();

                btnAddBand.Show();
                btnRemoveBand.Show();
                btnEditBand.Show();
                btnUploadBandPfp.Show();
                btnAddFavBand.Show();

                lblBandName.Show();
                lblBandDebutDate.Show();
                lblBandGender.Show();
                lblBandNumOfMem.Show();
                lblCompany.Show();

                txtBandName.Show();
                txtBandDebutDate.Show();
                txtBandGender.Show();
                txtBandNumOfMem.Show();
                txtBandCompany.Show();

                btnSave.Show();
                btnLoad.Show();
                
                if (singerMode == true)
                {
                    btnGoBackToBand.Show(); // Hide button
                    btnDisplayBandSingers.Hide(); // sHOW button

                    // Show labels, textboxes, buttons related to singers 
                    lblSingerName.Show();
                    txtSingerName.Show();
                    btnAddSinger.Show();
                    btnRemoveSinger.Show();
                    btnPreviousSinger.Show();
                    btnNextSinger.Show();
                    lblDisplaySinger.Show();
                }
                else
                {
                    btnGoBackToBand.Hide(); // Show button
                    btnDisplayBandSingers.Show(); // Hide button

                    // Hide labels, textboxes, buttons related to singers 
                    lblSingerName.Hide();
                    txtSingerName.Hide();
                    btnAddSinger.Hide();
                    btnRemoveSinger.Hide();
                    btnPreviousSinger.Hide();
                    btnNextSinger.Hide();
                    lblDisplaySinger.Hide();
                }
            }
            else
            {
                if (displayMode[displayIndex] is SortNameByAlpha) // Check if the current display mode is SortNameByAlpha
                {
                    lblDisplayMode.Text = "Display Mode: Alphabetical Order"; // Display text
                }
                else if (displayMode[displayIndex] is SortByDate) // Check if the current display mode is SortByDate
                {
                    lblDisplayMode.Text = "Display Mode: Date (recent ~ old)"; // Display text
                }
                else if (displayMode[displayIndex] is SortByGender) // Check if the current display mode is SortByGender
                {
                    lblDisplayMode.Text = "Display Mode: Gender (Male, Female, Other)"; // Display text
                }

                // Hide some labels, buttons and textboxes
                lblDisplayFavBand.Hide();
                btnPreviousFavBand.Hide();
                btnNextFavBand.Hide();
                btnRemoveFavBand.Hide();

                btnAddBand.Hide();
                btnRemoveBand.Hide();
                btnEditBand.Hide();
                btnUploadBandPfp.Hide();
                btnAddFavBand.Hide();

                lblBandName.Hide();
                lblBandDebutDate.Hide();
                lblBandGender.Hide();
                lblBandNumOfMem.Hide();
                lblCompany.Hide();

                txtBandName.Hide();
                txtBandDebutDate.Hide();
                txtBandGender.Hide();
                txtBandNumOfMem.Hide();
                txtBandCompany.Hide();

                btnSave.Hide();
                btnLoad.Hide();

                btnGoBackToBand.Hide(); 
                btnDisplayBandSingers.Hide(); 

                // Hide labels, textboxes, buttons related to singers 
                lblSingerName.Hide();
                txtSingerName.Hide();
                btnAddSinger.Hide();
                btnRemoveSinger.Hide();
                btnPreviousSinger.Hide();
                btnNextSinger.Hide();
                lblDisplaySinger.Hide();
            }
            
        }
    }
}
