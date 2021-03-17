/*
 * ListOfBands
 * Hank Yang 
 * January 6, 2020
 * ICS4U_Period_2
 * This class holds the list of bands & the list of favourite bands
 * Consist of multiple subprograms that are called by the main form in order to perform all the available functions in the program
 */
using System.Collections.Generic;

namespace KpopBandDatabase
{
    class ListOfBands
    {
        // Declare the list of bands & the list of favourite bands
        private List<Band> bands = new List<Band>();
        private List<Band> favBands = new List<Band>();

        public ListOfBands() // Default constructor, does nothing
        {

        }

        public bool AddBand(Band aBand) // Add a band into the list of bads, takes in a class object (Band) as parameter
        {
            // if band is already in the list of bands, don't add
            if (bands.Contains(aBand))
            {
                return false;
            }
            // band is new, add to the list of bands
            else
            {
                bands.Add(aBand);
                return true;
            }
        }

        public bool RemoveBand(int currentBandIndex) // Remove a band from the list of bands, takes in the current index of the band as parameter
        {
            // list of bands has more number of bands than the current index that is passed in
            if (bands.Count > currentBandIndex)
            {
                bands.RemoveAt(currentBandIndex); // Remove the band
                return true;
            }
            // list of bands does not have more bands than the current index
            else
            {
                return false;
            }
        }
        public void EditBand(Band tempBand, int currentBandIndex) // Edit a band's information, takes in a class object (Band) & the index of the band as parameters
        {
            // Updates all the band's information with the information that the user inputs in
            bands[currentBandIndex].Name = tempBand.Name;
            bands[currentBandIndex].DebutDate = tempBand.DebutDate;
            bands[currentBandIndex].Gender = tempBand.Gender;
            bands[currentBandIndex].NumOfMember = tempBand.NumOfMember;
            bands[currentBandIndex].Company = tempBand.Company;
        }

        public Band GetBand (int index) // Alllow other classes to access the list of bands at certain index
        {
            // if the index is valid, return the Band at index
            if (index >= 0 && index < bands.Count)
            {
                return bands[index];
            }
            // invalid index cuases null return
            return null;
        }

        public List<Band> GetBandList // Allow other classes to access the list of bands
        {
            get
            {
                return bands;
            }
        }

        public bool AddFavBand(Band aBand) // Add a band into the list of favourite bads, takes in a class object (Band) as parameter
        {
            /*
            for (int i = 0; i < favBands.Count; i++)
            {
                // if band is already in the list of favourite bands, don't add
                if (aBand.Name == favBands[i].Name && aBand.DebutDate == favBands[i].DebutDate && aBand.Gender == favBands[i].Gender
                    && aBand.NumOfMember == favBands[i].NumOfMember && aBand.Company == favBands[i].Company)
                {
                    return false;
                }
            }
            favBands.Add(aBand);
            return true;
            */
            if (favBands.Contains(aBand))
            {
                return false;
            }
            // band is new, add to the list of favourite bands
            else
            {
                favBands.Add(aBand);
                return true;
            }
            
        }

        public bool RemoveFavBand(int currentFavBandIndex) // Remove a band from the list of favourite bands, takes in current index of the band as parameter
        {
            // list of favourite bands has more number of bands than the current favourite band index that is passed in
            if (favBands.Count > currentFavBandIndex)
            {
                favBands.RemoveAt(currentFavBandIndex); // Remove the favourite band
                return true;
            }
            // list of favourite bands does not have more bands than the current favourite band index
            else
            {
                return false;
            }
        }
        public List<Band> GetFavBandList // Allow other classes to access the list of favourite bands
        {
            get
            {
                return favBands;
            }
        }


        public void SortBandByGender() // Sort the list of bands in the order of gender, male then female, then others
        {
            List<Band> tempBands = new List<Band>(); // Create a list of temporary bands

            for (int i = 0; i < bands.Count; i++) // Add all the male bands into the temporary array 
            {
                if (bands[i].Gender == "Male") // Check if the band gender is Male
                {
                    tempBands.Add(bands[i]); // If yes, add 
                }
            }
            for (int i = 0; i < bands.Count; i++) // Add all the female bands into the temporary array
            {
                if (bands[i].Gender == "Female") // Check if the band gender is Female
                {
                    tempBands.Add(bands[i]); // If yes, add
                }
            }
            for (int i = 0; i < bands.Count; i++) // Add all the other gender bands into the temporary array
            {
                if (bands[i].Gender != "Male" && bands[i].Gender != "Female") // Check if the band gender is not Male nor Female
                {
                    tempBands.Add(bands[i]); // If not Male nor Female, add
                }
            }

            bands = tempBands; // Set the bands array equal to the temporary array
        }

        public void SortBandByDate() // Sort the list of bands in the order of debut date, male then female, then others
        {
            int previousMax, maxIndex = 0;
            for (int i = 0; i < bands.Count - 1; i++)
            {
                maxIndex = i;
                previousMax = bands[i].DebutDate; // Update the previous Max to the element starting after the one that is already sorted
                for (int k = i; k < bands.Count; k++)
                {
                    if (bands[k].DebutDate > previousMax)
                    {
                        previousMax = bands[k].DebutDate; // store the current previous max after comparing
                        maxIndex = k;        // store the index where the max occurs
                    }
                }
                // Swap the values
                Band tempBand = bands[maxIndex];
                bands[maxIndex] = bands[i];
                bands[i] = tempBand;
            }
        }

        public void SortBandByAlpha() // Sort the list of bands in alphabetical order from A to Z
        {
            /*List<string> bandNames = new List<string>(); // Create a temporary list of bands
            
            for (int i = 0; i < bands.Count; i++)
            {
                bandNames.Add(bands[i].Name); // Add in all the bands' names into the temporary array
            }
            
            

            // Make sure the information attached to each band are all getting sorted alongside with the band's name
            for (int i = 0; i < bandNames.Count; i++)
            {
                int theRestOfInfoIndex = 0;
                for (int k = 0; k < bands.Count; i++)
                {
                    if (bands[k].Name == bandNames[i])
                    {
                        theRestOfInfoIndex = k;
                    }
                }
                Band tempBand = bands[i];
                bands[i] = bands[theRestOfInfoIndex];
                bands[theRestOfInfoIndex] = tempBand;
            }
            */
            bands.Sort(delegate (Band a, Band b)
            {
                return a.Name.CompareTo(b.Name);
            }); // Sort the names by alphabetical order
        }

        public int SearchBandAndDisplay(string toSearch) // Search for a certain band, takes in a string parameter
        {
            string formattedToSearch;
            formattedToSearch = toSearch.ToLower();
            formattedToSearch = formattedToSearch.Substring(0, 1).ToUpper() + formattedToSearch.Substring(1); // Format the toSearch string
            int toSearchIndex = -1 ;

            for (int i = 0; i < bands.Count; i++) // Run through the list
            {
                if(bands[i].Name == formattedToSearch) // Check if toSearch matches any of the band's name
                {
                    toSearchIndex = i; // If yes, store the index
                    break;
                }
            }
            return toSearchIndex; // If found, return index, if not, return -1
        }
    }
}
