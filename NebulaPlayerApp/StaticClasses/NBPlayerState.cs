/*
 * Caleb Lam
 * NBPlayerState
 * Updated: Jan. 9, 2020
 * Code for the class NBPlayerState. (See summary of class for details.)
 */

using NebulaPlayerApp.Classes;
using System;
using System.Collections.Generic;
using Windows.Media.Playback;

namespace NebulaPlayerApp.StaticClasses
{
    /// <summary>
    /// This acts as cache for the Player. The properties are self-explanatory.
    /// </summary>
    class NBPlayerState
    {
        public static MediaPlaybackList CurrentPlaylist { get; set; } // Currently using this playlist. Null when displaying an image.
        public static List<NBMedia> CurrentMediaList { get; set; } // Currently using list of NBMedia. Null when displaying an image.
        public static NBImage CurrentImage { get; set; } // Currently displaying image, null if playing other media types.
        public static int? CurrentSourceIndex { get; set; } = null; // Index of the currently playing media. Null when displaying an image.
        public static TimeSpan CurrentPosition { get; set; } // Current time position of the player. 0s when displaying an image.
    }
}
