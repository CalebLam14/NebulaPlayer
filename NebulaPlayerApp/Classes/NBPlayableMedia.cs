/*
 * Caleb Lam
 * NBPlayableMedia
 * Updated: Jan. 9, 2020
 * Code for the class NBPlayableMedia. (See summary of class for details.)
 */

using System;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// Class that houses the video and audio files, which have duration.
    /// </summary>
    abstract class NBPlayableMedia : NBMedia
    {
        private TimeSpan duration; // Total duration.

        /// <summary>
        /// Method to check the format of the supplied media file to check if it is valid. See also <seealso cref="NBMedia.CheckFormat"/>
        /// </summary>
        protected abstract override void CheckFormat();

        /// <summary>
        /// The duration of the file.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return duration;
            }

            protected set
            {
                duration = value;
            }
        }
    }
}
