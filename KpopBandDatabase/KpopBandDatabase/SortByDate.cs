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
    class SortByDate : Sort
    {
        // The override method of DoSort
        public override List<Band> DoSort(List<Band> bands)
        {
            // Create a copy of the list of bands passed in
            List<Band> tempBands = new List<Band>();
            for (int i = 0; i < bands.Count; i++)
            {
                tempBands.Add(bands[i]);
            }

            // Declare integer variables
            int previousMax, maxIndex = 0;
            for (int i = 0; i < tempBands.Count - 1; i++) // Loop through tempBands
            {
                maxIndex = i;
                previousMax = tempBands[i].DebutDate; // Update the previous Max to the element starting after the one that is already sorted
                for (int k = i; k < tempBands.Count; k++)
                {
                    if (tempBands[k].DebutDate > previousMax) // Check if the debut date of tempBands at index k is greater than previousMax
                    {
                        previousMax = tempBands[k].DebutDate; // store the current previous max after comparing
                        maxIndex = k;        // store the index where the max occurs
                    }
                }
                // Swap the values
                Band tempBand = tempBands[maxIndex];
                tempBands[maxIndex] = tempBands[i];
                tempBands[i] = tempBand;
            }
            return tempBands; // Return the list of bands sorted by date
        }
    }
}
