/*
 * Caleb Lam
 * NBVideo
 * Updated: Jan. 9, 2020
 * Code for the class NBVideo. (See summary of class for details.)
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
    /// Media data object for all videos.
    /// </summary>
    class NBVideo : NBPlayableMedia
    {
        /// <summary>
        /// Construct the data with a supported media file.
        /// </summary>
        /// <param name="file">The media file. Make sure it is supported by the app.</param>
        private NBVideo(StorageFile file)
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
        private NBVideo(string path, string name, string format)
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
            List<string> supportedFormats = GetSupportedFormats()[MediaType.Video];

            if (supportedFormats.IndexOf(format) == -1)
            {
                throw new ArgumentException("Please provide a valid file with a supported VIDEO format: " + string.Join(", ", supportedFormats));
            }
        }

        /// <summary>
        /// Set up the needed properties. In this case, the duration.
        /// </summary>
        private async Task<NBVideo> SetupPropertiesAsync()
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(path);
            VideoProperties properties = await file.Properties.GetVideoPropertiesAsync();
            Duration = properties.Duration;
            return this;
        }

        /// <summary>
        /// "Construct" this object using a StorageFile object/media file.
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The newly constructed NBVideo object</returns>
        public static Task<NBVideo> FromStorageFileAsync(StorageFile file)
        {
            NBVideo nbVideo = new NBVideo(file);
            return nbVideo.SetupPropertiesAsync();
        }

        /// <summary>
        /// The most basic way of "constructing" this object by providing all the needed info.
        /// </summary>
        /// <param name="path">Path to the media file.</param>
        /// <param name="name">Name of the file</param>
        /// <param name="format">Extension of the file.</param>
        /// <returns>The newly constructed NBVideo object</returns>
        public static Task<NBVideo> FromGivenInfoAsync(string path, string name, string format)
        {
            NBVideo nbVideo = new NBVideo(path, name, format);
            return nbVideo.SetupPropertiesAsync();
        }
    }
}
