/*
 * SortNameByAlpha
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
    class SortNameByAlpha : Sort
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

            // Sort the names by alphabetical order
            tempBands.Sort(delegate (Band a, Band b)
            {
                return a.Name.CompareTo(b.Name);
            }); 

            return tempBands; // return the list of bands sorted in alphabetical order
        }
    }
}
