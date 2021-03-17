/*
 * Caleb Lam
 * PlayMediaArgs
 * Updated: Jan. 9, 2020
 * Code for the class PlayMediasArgs. (See summary of class for details.)
 */

using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// This is used in the PlayMediaCommand. It supplies info about which media to play in the Player page.
    /// </summary>
    class PlayMediasArgs
    {
        public Page FromPage { get; } // We need the page that created this class to know where to look for the main page.

        public List<NBMedia> Medias { get; } // List of media to play.

        /// <summary>
        /// Constructor using the invoking page and a single media.
        /// </summary>
        /// <param name="fromPage">The page that created this object.</param>
        /// <param name="media">The media to play.</param>
        public PlayMediasArgs(Page fromPage, NBMedia media)
            : this(fromPage, new List<NBMedia>() { media })
        {
            
        }

        /// <summary>
        /// Constructor using the invoking page and a list of media.
        /// </summary>
        /// <param name="fromPage">The page that created this object.</param>
        /// <param name="medias">The list of media to play.</param>
        public PlayMediasArgs(Page fromPage, List<NBMedia> medias)
        {
            FromPage = fromPage;
            Medias = medias;
        }
    }
}
