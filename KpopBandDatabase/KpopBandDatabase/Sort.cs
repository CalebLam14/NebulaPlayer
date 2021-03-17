/*
 * Sort
 * Hank Yang 
 * Janurary 6, 2020
 * ICS4U_Period_2
 * This class is the mother class of Unsorted, SortNameByAlpha, SortByDate & SortByGender
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopBandDatabase
{
    abstract class Sort
    {
        // Abstract method of DoSort
        public abstract List<Band> DoSort(List<Band> bands);
    }
}
