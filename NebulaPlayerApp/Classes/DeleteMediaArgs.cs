/*
 * Caleb Lam
 * DeleteMediaArgs
 * Updated: Jan. 13, 2020
 * Code for the class DeleteMediaArgs. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// This is used in the DeleteMediaCommand. It supplies info about which media to delete from the application's registry.
    /// </summary>
    class DeleteMediaArgs
    {
        public NBMedia TargetMedia { get; } // The target media to delete.

        /// <summary>
        /// A very simple contructor for DeleteMediaArgs. You just need to supply the target media to store it for use later.
        /// </summary>
        /// <param name="media"></param>
        public DeleteMediaArgs(NBMedia media)
        {
            TargetMedia = media;
        }
    }
}
