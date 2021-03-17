/*
 * Unsorted
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
    class Unsorted : Sort
    {
        // The override method of DoSort
        public override List<Band> DoSort(List<Band> bands)
        {
            return bands; // Return the unsorted list of bands
        }
    }
}
