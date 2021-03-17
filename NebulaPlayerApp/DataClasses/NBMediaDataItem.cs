/*
 * Caleb Lam
 * NBMediaDataItem
 * Updated: Jan. 9, 2020
 * Code for the class NBMediaDataItem. (See summary of class for details.)
 */

using System;
using System.ComponentModel;
using NebulaPlayerApp.Classes;
using static NebulaPlayerApp.StaticClasses.NBRegistry;

namespace NebulaPlayerApp.DataClasses
{
    /// <summary>
    /// Class used to provide info about what to display on the list in the Your Media page.
    /// </summary>
    class NBMediaDataItem : INotifyPropertyChanged
    {
        private string name = ""; // Name of media
        private string path = ""; // Path to media file
        private MediaType type; // Type of media (for changing the icons. This is automatically configured based on given media data object.
        private bool isSelected = false; // Is it selected? This is automatically toggled by YourMediaPage.xaml.cs.
        private NBMedia mediaSource = null; // Where did the information of this data item come from? Should be a Media object.

        public NBMedia MediaSource
        {
            get
            {
                return mediaSource;
            }

            private set
            {
                if (value.Path != null)
                {
                    mediaSource = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                    RaisePropertyChanged("Path");
                }
            }
        }

        public MediaType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
                RaisePropertyChanged("Type");
            }
        }

        public Uri IconUri
        {
            get
            {
                // Set the URI of the icon based on MediaType. The URI must start with "ms-appx:///" or it will throw very weird errors.
                switch (type)
                {
                    case MediaType.Audio:
                        return new Uri("ms-appx:///Assets/MusicNote.png");

                    case MediaType.Image:
                        return new Uri("ms-appx:///Assets/PhotoIcon.png");

                    case MediaType.Video:
                        return new Uri("ms-appx:///Assets/MovieRollTape.png");

                    default:
                        return new Uri("ms-appx:///Assets/QuestionMark.png");
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        // This is to implement the property changed events in case anything changes here.
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Supply a plylist source and the data item will set its values based on it.
        /// </summary>
        /// <param name="source">The Media object.</param>
        public NBMediaDataItem(NBMedia source)
            : this(source.Name, source, source.Path, GetMediaType(source))
        {

        }

        /// <summary>
        /// The most basic way of setting this data item up is to supply all the values it needs.
        /// </summary>
        /// <param name="name">Media name.</param>
        /// <param name="source">The Media object.</param>
        /// <param name="path">Path to the media file.</param>
        /// <param name="type">The media genre.</param>
        public NBMediaDataItem(string name, NBMedia source, string path, MediaType type = MediaType.Image)
        {
            this.name = name;
            mediaSource = source;
            this.path = path;
            this.type = type;
        }
    }
}
