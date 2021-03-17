/*
 * Caleb Lam
 * NBAudio
 * Updated: Jan. 9, 2020
 * Code for the class NBAudio. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using static NebulaPlayerApp.StaticClasses.NBRegistry;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// Media data object for all audio.
    /// </summary>
    class NBAudio : NBPlayableMedia
    {
        private TimeSpan duration; // Total duration.

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }

        /// <summary>
        /// Construct the data with a supported media file.
        /// </summary>
        /// <param name="file">The media file. Make sure it is supported by the app.</param>
        private NBAudio(StorageFile file)
            : this(file.Path, file.Name, file.FileType)
        {
            mediaFile = file;
        }

        /// <summary>
        /// The most basic way of setting this up by providing all the needed values.
        /// </summary>
        /// <param name="path">Path to the media file.</param>
        /// <param name="name">Name of the media file.</param>
        /// <param name="format">Extension of the media file.</param>
        private NBAudio(string path, string name, string format)
            : base()
        {
            this.path = path;
            this.format = format;
            CheckFormat();
            this.name = name;
        }

        /// <summary>
        /// Comes from the NBMedia class. Checks if the extension is valid or throw an error.
        /// </summary>
        protected override void CheckFormat()
        {
            List<string> supportedFormats = GetSupportedFormats()[MediaType.Audio];

            if (supportedFormats.IndexOf(format) == -1)
            {
                throw new ArgumentException("Please provide a valid file with a supported AUDIO format: " + string.Join(", ", supportedFormats));
            }
        }

        /// <summary>
        /// Set up the needed properties. In this case, the duration.
        /// </summary>
        private async Task<NBAudio> SetupPropertiesAsync()
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(path);
            MusicProperties properties = await file.Properties.GetMusicPropertiesAsync();
            duration = properties.Duration;

            return this;
        }

        /// <summary>
        /// "Construct" this object using a StorageFile object/media file.
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The newly constructed NBAudio object</returns>
        public static Task<NBAudio> FromStorageFileAsync(StorageFile file)
        {
            NBAudio nbAudio = new NBAudio(file);
            return nbAudio.SetupPropertiesAsync();
        }

        /// <summary>
        /// The most basic way of "constructing" this object by providing all the needed info.
        /// </summary>
        /// <param name="path">Path to the media file.</param>
        /// <param name="name">Name of the file</param>
        /// <param name="format">Extension of the file.</param>
        /// <returns>The newly constructed NBAudio object</returns>
        public static Task<NBAudio> FromGivenInfoAsync(string path, string name, string format)
        {
            NBAudio nbAudio = new NBAudio(path, name, format);
            return nbAudio.SetupPropertiesAsync();
        }
    }
}
