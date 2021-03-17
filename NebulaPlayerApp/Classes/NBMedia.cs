/*
 * Caleb Lam
 * NBMedia
 * Updated: Jan. 9, 2020
 * Code for the class NBMedia. (See summary of class for details.)
 */

using Windows.Storage;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// Basic properties describing a media file.
    /// </summary>
    abstract class NBMedia
    {
        protected string path; // Target media file's path.
        protected string name; // Name of media.
        protected string format; // File format of media.
        protected StorageFile mediaFile; // File of media as a StorageFile.
        protected StorageFile dataFile; // Saved NBME data file as a StorageFile.

        public string Path
        {
            get
            {
                return path;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Format
        {
            get
            {
                return format;
            }
        }

        public StorageFile MediaFile
        {
            get
            {
                return mediaFile;
            }
        }

        public StorageFile DataFile
        {
            get
            {
                return dataFile;
            }

            set
            {
                if (value != null)
                {
                    dataFile = value;
                }
            }
        }

        protected abstract void CheckFormat(); // For the inherited classes to use for extension checking to make sure you are loading the files right.
    }
}
