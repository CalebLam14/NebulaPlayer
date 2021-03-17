/*
 * SortByDate
 * Hank Yang 
 * January 6, 2020
 * ICS4U_Period_2
 * This class is one of the child classes of Sort
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopBandDatabase
{
    class SortByGender : Sort
    {
        // The override method of DoSort
        public override List<Band> DoSort(List<Band> bands)
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

            return tempBands; // Return the list of bands sorted by gender
        }
    }
}
