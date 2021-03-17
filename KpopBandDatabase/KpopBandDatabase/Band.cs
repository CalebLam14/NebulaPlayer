/*
 * Band
 * Hank Yang 
 * January 6, 2020
 * ICS4U_Period_2
 * This class takes care of the contruction of a band, as well as various variable infromation attached to each band
 * Consists of the get & set of each variable attached to a band which allows other class to access and edit these data
 * Includes numerous singer fucntions that are yet to be used
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace KpopBandDatabase
{
    class Band // : IComparable<Band>
    {
        private List<Singer> singers = new List<Singer>(); // Declare a list of individual singers
        private List<Singer> favSingers = new List<Singer>(); // Declare a list of favourite individual singers
        private string name, gender, company; // Declare string variables used by the Band class
        private int debutDate, numOfMember; // Declare integer variables used by the Band class

        // Delcare a bitmap variable which is the profile picture of the band
        private Bitmap bandPfp = null;
        // Create string variable to store the band ID
        private string bandId = "";

        // Constructor that takes in all variable info that a band consists of
        // Saves all the information passed in, into each individual band
        public Band(string name, int debutDate, string gender, int numOfMember, string company)
        {
            this.name = name;
            this.debutDate = debutDate;
            this.gender = gender;
            this.numOfMember = numOfMember;
            this.company = company;
        }
        /*
        public bool AddSinger(string name, string gender, int age, int height, int weight, string hobbies, Image pfp) 
        {
            Singer aSinger = new Singer (name, gender, age, height, weight, hobbies, pfp);
            singers.Add(aSinger);

            return AddSinger(aSinger);
        }
        */
        public bool AddSinger(Singer aSinger) // Add a singer into a band, takes in a class object (Singer) as parameter
        {
            // if singer is already in the band, don't add
            if (singers.Contains(aSinger))
            {
                return false;
            }
            // singer is new, add to this band
            else
            {
                singers.Add(aSinger);
                return true;
            }
        }
        public bool RemoveSinger(int currentSingerIndex) // Remove a singer from the list of singers, takes in the current index of the singer as parameter
        {
            // list of singers has more number of singers than the current index that is passed in
            if (singers.Count > currentSingerIndex)
            {
                singers.RemoveAt(currentSingerIndex); // Remove the singer
                return true;
            }
            // list of singers does not have more singers than the current index
            else
            {
                return false;
            }
        }

        public void EditSinger(Singer tempSinger, int singerIndex) // Edit a singer's information, takes in a class object (Singer) & the index of the singer as parameters
        {
            // Updates all the singer's information with the information that the user inputs in
            singers[singerIndex].Name = tempSinger.Name;
            singers[singerIndex].Gender = tempSinger.Gender;
            singers[singerIndex].Age = tempSinger.Age;
            singers[singerIndex].Height = tempSinger.Height;
            singers[singerIndex].Weight = tempSinger.Weight;
            singers[singerIndex].Hobbies = tempSinger.Hobbies;
            singers[singerIndex].SingerPfp = tempSinger.SingerPfp;
        }
        public Singer GetSinger(int index) // Get the Singer in the list of singers at certain index
        {
            // if the index is valid, return the Singer at index
            if (index >= 0 && index < singers.Count)
            {
                return singers[index];
            }
            // invalid index cuases null return
            return null;
        }
        public List<Singer> GetSingerList // Get the list of singers
        {
            get
            {
                return singers;
            }
        }
        public bool AddFavSinger(Singer aSinger)  // Add a singer into the list of favourite singers, takes in a class object (Singer) as parameter
        {
            // if singer is already in the list of favourite singers, don't add
            if (favSingers.Contains(aSinger))
            {
                return false;
            }
            // singer is new, add to the list of favourite singers
            else
            {
                favSingers.Add(aSinger);
                return true;
            }
        }
        public bool RemoveFavSinger(Singer theSinger) // Remove a singer from the list of favourite singers, takes in a class object (Singer) as parameter
        {
            // singer is in the list of favourite singers, remove it
            if (favSingers.Contains(theSinger))
            {
                favSingers.Remove(theSinger);
                return true;
            }
            // singer was not in the list of favourite singers
            else
            {
                return false;
            }
        }
        public List<Singer> GetFavSingers // Get the list of favourite singers
        {
            get
            {
                return favSingers;
            }
        }
        public void SortSingerByAge() // Sort the list of singers with their age in descending order
        {
            int previousMax, maxIndex = 0;
            for (int i = 0; i < singers.Count - 1; i++)
            {
                maxIndex = i;
                previousMax = singers[i].Age; // Update the previous Max to the element starting after the one that is already sorted
                for (int k = i; k < singers.Count; k++)
                {
                    if (singers[k].Age > previousMax) 
                    {
                        previousMax = singers[k].Age; // store the current previous max after comparing
                        maxIndex = k;        // store the index where the max occurs
                    }
                }
                // Swap the values
                singers[maxIndex] = singers[i];
                singers[i].Age = previousMax;
            }
        }
        public void SortSingerByHeight() // Sort the list of singers with their height in descending order
        {
            int previousMax, maxIndex = 0;
            for (int i = 0; i < singers.Count - 1; i++)
            {
                maxIndex = i;
                previousMax = singers[i].Height; // Update the previous Max to the element starting after the one that is already sorted
                for (int k = i; k < singers.Count; k++)
                {
                    if (singers[k].Height > previousMax) 
                    {
                        previousMax = singers[k].Height; // store the current previous max after comparing
                        maxIndex = k;        // store the index where the max occurs
                    }
                }
                // Swap the values
                singers[maxIndex] = singers[i];
                singers[i].Height = previousMax;
            }
        }
        public void SortSingerByWeight() // Sort the list of singers with their weight in descending order
        {
            int previousMax, maxIndex = 0;
            for (int i = 0; i < singers.Count - 1; i++)
            {
                maxIndex = i;
                previousMax = singers[i].Weight; // Update the previous Max to the element starting after the one that is already sorted
                for (int k = i; k < singers.Count; k++)
                {
                    if (singers[k].Weight > previousMax)
                    {
                        previousMax = singers[k].Weight; // store the current previous max after comparing
                        maxIndex = k;        // store the index where the max occurs
                    }
                }
                // Swap the values
                singers[maxIndex] = singers[i];
                singers[i].Weight = previousMax;
            }
        }

        public int SearchSingerAndDisplay(string toSearch)
        {
            string formattedToSearch;
            formattedToSearch = toSearch.ToLower();
            formattedToSearch = formattedToSearch.Substring(0, 1).ToUpper() + formattedToSearch.Substring(1);
            int toSearchIndex = 0;

            for (int i = 0; i < singers.Count; i++)
            {
                if (singers[i].Name == formattedToSearch)
                {
                    toSearchIndex = i;
                    break;
                }
            }
            return toSearchIndex;
        }

        /*
        public int CompareTo(Band obj) // Allow bands to be compared
        {
            return Name.CompareTo(obj.Name); // Compare band names
        }
        */

        public string Name // Allow the other class to have acces and edit name information
        {
            get
            {
                string formattedName = name;
                formattedName = formattedName.ToLower();
                formattedName =  formattedName.Substring(0, 1).ToUpper() + formattedName.Substring(1);
                name = formattedName; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
                return name;
            }
            set
            {
                string formattedName = value;
                formattedName = formattedName.ToLower();
                formattedName = formattedName.Substring(0, 1).ToUpper() + formattedName.Substring(1);
                name = formattedName; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
            }
        }
        public int DebutDate // Allow other class to have access and edit debutdate information
        {
            get
            {
                return debutDate;
            }
            set
            {
                debutDate = value;
            }
        }
        public string Gender // Allow other class to have access and edit gender information
        {
            get
            {
                string formatteGender = gender;
                formatteGender = formatteGender.ToLower();
                formatteGender = formatteGender.Substring(0, 1).ToUpper() + formatteGender.Substring(1);
                gender = formatteGender; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
                return gender;
            }
            set
            {
                string formatteGender = value;
                formatteGender = formatteGender.ToLower();
                formatteGender = formatteGender.Substring(0, 1).ToUpper() + formatteGender.Substring(1);
                gender = formatteGender; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
            }
        }
        public int NumOfMember // Allow other class to have access and edit number of member information
        {
            get
            {
                return numOfMember;
            }
            set
            {
                numOfMember = value;
            }
        }
        public string Company // Allow other class to have access and edit company information
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public Bitmap BandPfp // Allow the other class to have access and edit profile picture information
        {
            get
            {
                return bandPfp;
            }
            set
            {
                bandPfp = value;
            }
        }
        public string BandId // Allow the other class to have access and edit the band id
        {
            get
            {
                return bandId;
            }
            set
            {
                bandId = value;
            }
        }
    }
}
