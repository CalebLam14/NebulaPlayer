/*
 * Caleb Lam
 * NBImage
 * Updated: Jan. 9, 2020
 * Code for the class NBImage. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.FileProperties;
using static NebulaPlayerApp.StaticClasses.NBRegistry;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// Media data object for an image.
    /// </summary>
    class NBImage : NBMedia
    {
        private Size size; // Resolution/size of image.

        public Size Size
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Construct the data with a supported media file.
        /// </summary>
        /// <param name="file">The media file. Make sure it is supported by the app.</param>
        private NBImage(StorageFile file)
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
        private NBImage(string path, string name, string format)
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
            List<string> supportedFormats = GetSupportedFormats()[MediaType.Image];

            if (supportedFormats.IndexOf(format) == -1)
            {
                throw new ArgumentException("Please provide a valid file with a supported IMAGE format: " + string.Join(", ", supportedFormats));
            }
        }

        /// <summary>
        /// Set up the needed properties. In this case, the size.
        /// </summary>
        private async Task<NBImage> SetupPropertiesAsync()
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(path);
            ImageProperties properties = await file.Properties.GetImagePropertiesAsync();

            size = new Size(properties.Width, properties.Height);
            return this;
        }

        /// <summary>
        /// "Construct" this object using a StorageFile object/media file.
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The newly constructed NBImage object</returns>
        public static Task<NBImage> FromStorageFileAsync(StorageFile file)
        {
            NBImage nbImage = new NBImage(file);
            return nbImage.SetupPropertiesAsync();
        }

        /// <summary>
        /// The most basic way of "constructing" this object by providing all the needed info.
        /// </summary>
        /// <param name="path">Path to the media file.</param>
        /// <param name="name">Name of the file</param>
        /// <param name="format">Extension of the file.</param>
        /// <returns>The newly constructed NBImage object</returns>
        public static Task<NBImage> FromGivenInfoAsync(string path, string name, string format)
        {
            NBImage nbImage = new NBImage(path, name, format);
            return nbImage.SetupPropertiesAsync();
        }
    }
}
