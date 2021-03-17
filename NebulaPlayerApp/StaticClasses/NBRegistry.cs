/*
 * Caleb Lam
 * NBRegistry
 * Updated: Jan. 9, 2020
 * Code for the class NBRegistry. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using NebulaPlayerApp.Classes;

namespace NebulaPlayerApp.StaticClasses
{
    /// <summary>
    /// A class that acts as a registry of the app. Manages the storage and reading of saved media and playlist data.
    /// </summary>
    static class NBRegistry
    {
        // Constants: These are mainly for defining file formats and locations.

        // These are the names of the storage folders for saving media and playlist data.
        private const string MEDIA_STORAGE_NAME = "medias";

        // These are the file formats to save the data as.
        private const string MEDIA_STORAGE_FORMAT = ".nbme";

        //------

        private static ObservableCollection<NBMedia> medias = new ObservableCollection<NBMedia>(); // List of media data.

        // These are all the supported file formats, listed by media type.
        private static readonly ReadOnlyDictionary<MediaType, List<string>> supportedFormats = new ReadOnlyDictionary<MediaType, List<string>>(
            new Dictionary<MediaType, List<string>>()
            {
                [MediaType.Video] = new List<string>() { ".mp4", ".mov", ".wmv", ".flv", ".avi" },
                [MediaType.Audio] = new List<string>() { ".mp3", ".wav" },
                [MediaType.Image] = new List<string>() { ".png", ".jpeg", ".jpg", ".gif" },
            }
        );

        // These enums define the genre of media. You don't wanna get the Unknown enum normally.
        public enum MediaType
        {
            Image,
            Audio,
            Video,
            Unknown
        }

        /// <summary>
        /// Exports the imported media into a .nbme file and save it in a local folder. It is located in AppData, which is a hidden folder and therefore makes this application really uninteresting on school computers due to their restrictions.
        /// The file is saved like this:
        /// <list type="number">
        ///     <item>Name of the file with extension</item>
        ///     <item>Extension of the file</item>
        ///     <item>Path to the file</item>
        /// </list>
        /// Returns the saved NBME file for reference later.
        /// </summary>
        /// <param name="media">The media object to save.</param>
        public static async Task<StorageFile> SaveNewMedia(NBMedia media)
        {
            StorageFolder dataStorage = ApplicationData.Current.LocalFolder;
            StorageFolder mediasStorageFolder;

            try // Create a save data folder in case it does not exist.
            {
                mediasStorageFolder = await dataStorage.GetFolderAsync(MEDIA_STORAGE_NAME);
            }
            catch (FileNotFoundException)
            {
                mediasStorageFolder = await dataStorage.CreateFolderAsync(MEDIA_STORAGE_NAME);
            }

            string mediaName = media.Name;
            string fileName = mediaName.Substring(0, mediaName.LastIndexOf('.')) + MEDIA_STORAGE_FORMAT;
            StorageFile targetNBMediaFile = await mediasStorageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting); // Create the file or overwrite if it exists already.

            // The data to save.
            // TODO: Save in either hex or binary.
            List<string> contentLines = new List<string>()
            {
                media.Format,
                media.Path,
            };

            try // Try writing the file and notify users if anything bad happens.
            {
                await FileIO.WriteLinesAsync(targetNBMediaFile, contentLines);
                return targetNBMediaFile;
            }
            catch (Exception ex)
            {
                await new MessageDialog("Can\'t save " + mediaName + ": " + ex.Message).ShowAsync();
                return null;
            }
        }

        public static async void DeleteSavedMedia(NBMedia media)
        {
            if (media.DataFile != null)
            {
                try
                {
                    await media.DataFile.DeleteAsync();
                }
                catch (Exception ex)
                {
                    await new MessageDialog("Can\'t delete " + media.Name + "\'s NBME file: " + ex.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// From the storage folder, import the saved media from .nbme files. Ignores all invalid and corrupted files.
        /// For the format of each .nbme file, see: <see cref="SaveNewMedia(NBMedia)"/>
        /// </summary>
        public static async void LoadMedias()
        {
            StorageFolder dataStorage = ApplicationData.Current.LocalFolder;
            StorageFolder mediasStorageFolder;

            try
            {
                mediasStorageFolder = await dataStorage.GetFolderAsync(MEDIA_STORAGE_NAME);
            }
            catch (FileNotFoundException)
            {
                mediasStorageFolder = await dataStorage.CreateFolderAsync(MEDIA_STORAGE_NAME);
            }

            IReadOnlyList<StorageFile> foundFiles = await mediasStorageFolder.GetFilesAsync(); // Get the files.

            int problemFilesCount = 0; // Stores the number of corrupted files to display later.
            foreach (StorageFile file in foundFiles)
            {
                if (file.FileType == MEDIA_STORAGE_FORMAT) // Invalid files are ignored and do not count towards the problem files count.
                {
                    try // Read the lines of the file.
                    {
                        IList<string> contentLines = await FileIO.ReadLinesAsync(file);
                        string targetFormat = contentLines[0];
                        string targetPath = contentLines[1];

                        StorageFile mediaFile = await StorageFile.GetFileFromPathAsync(targetPath); // This errors if the path is invalid. Suitable for a validity check.
                    
                        MediaType mediaType = GetMediaType(targetFormat); // Get the type of media and import it.

                        NBMedia resultantMedia;
                        switch (mediaType)
                        {
                            case MediaType.Audio:
                                resultantMedia = await NBAudio.FromStorageFileAsync(mediaFile).ConfigureAwait(true);
                                break;

                            case MediaType.Video:
                                resultantMedia = await NBVideo.FromStorageFileAsync(mediaFile).ConfigureAwait(true);
                                break;

                            case MediaType.Image:
                                resultantMedia = await NBImage.FromStorageFileAsync(mediaFile).ConfigureAwait(true);
                                break;

                            default:
                                throw new ArgumentException("This file is either unsupported or invalid."); // In case all else fails, throws the error to make it count towards the problem files.
                        }

                        resultantMedia.DataFile = file;
                        medias.Add(resultantMedia);
                    }
                    catch (Exception)
                    {
                        problemFilesCount++;
                        // new MessageDialog("Something went wrong while opening a media data file.").ShowAsync();
                    }

                }
            }

            if (problemFilesCount > 0) // If there are any corrupted files, notify users about that.
            {
                string fileWordForm = (problemFilesCount > 1) ? "files" : "file"; // I like grammar and spelling. 1 problem file will return "file" and multiple problem files will return "files".
                await new MessageDialog($"Something went wrong while opening {problemFilesCount} media data {fileWordForm}. All problematic files are ignored due to possible corruption or denied access.\n\nPlease make sure to turn on File System Access for the Nebula Player app in\nSettings > Privacy > File System.\n\nIf it is allowed, please clear the list by clicking on the Clear List button and reimport all media.").ShowAsync();
            }
        }

        /// <summary>
        /// Wipes all data in the media storage folder. There is no turning back after deletion, so there is a confirmation dialog before doing it.
        /// </summary>
        public async static void DeleteAllStoredMedias()
        {
            // Confirmation dialog.
            ContentDialog confirmationDialog = new ContentDialog()
            {
                Title = "Clear Media List",
                Content = "Are you sure you want to clear everything in this list? This cannot be undone and all saved media data will be lost!",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No"
            };

            ContentDialogResult result = await confirmationDialog.ShowAsync();

            // If the user clicks Yes...
            if (result == ContentDialogResult.Primary)
            {
                // Get the folder.
                StorageFolder dataStorage = ApplicationData.Current.LocalFolder;
                StorageFolder mediasStorageFolder;

                try
                {
                    mediasStorageFolder = await dataStorage.GetFolderAsync(MEDIA_STORAGE_NAME);
                }
                catch (FileNotFoundException)
                {
                    mediasStorageFolder = await dataStorage.CreateFolderAsync(MEDIA_STORAGE_NAME);
                }

                IReadOnlyList<StorageFile> foundFiles = await mediasStorageFolder.GetFilesAsync(); // Get all the files.

                foreach (StorageFile file in foundFiles)
                {
                    try // Try to delete all those files. Notify the users if a problem occurs.
                    {
                        await file.DeleteAsync();
                    }
                    catch (Exception)
                    {
                        await new MessageDialog("File cannot be deleted. You may have to delete it in " + mediasStorageFolder.Path).ShowAsync();
                    }
                }
            }

            medias.Clear(); // Clear the list of saved media.
        }
            
        /// <summary>
        /// Run this when the app loads.
        /// </summary>
        public static void Init()
        {
            LoadMedias();
        }

        /// <summary>
        /// Returns the list of registered media.
        /// </summary>
        /// <returns>List of registered media.</returns>
        public static ObservableCollection<NBMedia> GetMedias()
        {
            return medias;
        }

        /// <summary>
        /// Searches and finds the media with the supplied path from the registry.
        /// </summary>
        /// <param name="path">The path to look for.</param>
        /// <returns>If found, returns the first media data file. Otherwise, null.</returns>
        public static NBMedia GetMediaFromPath(string path)
        {
            List<NBMedia> foundMedias = medias.Where(media => media.Path == path).ToList();

            if (foundMedias.Count > 0)
            {
                return foundMedias[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add a new media data to the registry.
        /// </summary>
        /// <param name="newMedia">The new media data.</param>
        public static async void AddMedia(NBMedia newMedia)
        {
            if (!medias.Where(media => media.Path == newMedia.Path).Any()) // If the registry doesn't have this media data, add it.
            {
                medias.Add(newMedia);
                StorageFile dataFile = await SaveNewMedia(newMedia).ConfigureAwait(true);
                newMedia.DataFile = dataFile;
            }
            else
            {
                await new MessageDialog("This media file has already been added!").ShowAsync(); // Notify the user this has already been added.
            }
        }

        /// <summary>
        /// Add a list of new media data to the registry.
        /// For more info about this method, see: <seealso cref="AddMedia(NBMedia)"/>
        /// </summary>
        /// <param name="newMedia">The list of new media data.</param>
        public static void AddMedia(List<NBMedia> newMedias)
        {
            foreach (NBMedia media in newMedias)
            {
                AddMedia(media);
            }
        }

        /// <summary>
        /// Add a new media data to the registry from an actual media file.
        /// </summary>
        /// <param name="file">THe supplied media file. Make sure it is in a supported format.</param>
        public static async void AddMedia(StorageFile file)
        {
            try
            {
                MediaType mediaType = GetMediaType(file.FileType); // Figure out the type of file and add the right media data.

                switch (mediaType)
                {
                    case MediaType.Audio:
                        AddMedia(await NBAudio.FromStorageFileAsync(file).ConfigureAwait(true));
                        break;

                    case MediaType.Video:
                        AddMedia(await NBVideo.FromStorageFileAsync(file).ConfigureAwait(true));
                        break;

                    case MediaType.Image:
                        AddMedia(await NBImage.FromStorageFileAsync(file).ConfigureAwait(true));
                        break;

                    default:
                        throw new ArgumentException("This file is either unsupported or invalid."); // In case all else fails, throw an error.
                }
            }
            catch (Exception e)
            {
                await new MessageDialog("Something went wrong, so we could not add this media at all: " + e.Message).ShowAsync(); // If something goes wrong, notify the users.
            }
        }

        /// <summary>
        /// Removes a media data from the registry.
        /// </summary>
        /// <param name="target">The media data to remove.</param>
        public static async void RemoveMedia(NBMedia target)
        {
            if (medias.Contains(target)) // Find the target...
            {
                // remove the target NBME file first.
                // Confirmation dialog.
                ContentDialog confirmationDialog = new ContentDialog()
                {
                    Title = "Remove Media",
                    Content = "Are you sure you want to remove the selected media in this list? This cannot be undone and the media\'s data will be lost! (Don\'t worry, the media file itself will not be deleted.)",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No"
                };

                ContentDialogResult result = await confirmationDialog.ShowAsync();

                // If the user clicks Yes...
                if (result == ContentDialogResult.Primary)
                {
                    DeleteSavedMedia(target);
                    medias.Remove(target); // Remove it.
                }
                
            }
            else
            {
                await new MessageDialog("This media file does not exist!").ShowAsync(); // Notify users if not found.
            }
        }

        /// <summary>
        /// Returns the supported file formats of this app. This cannot be edited.
        /// </summary>
        /// <returns>The dictionary of supported file formats.</returns>
        public static ReadOnlyDictionary<MediaType, List<string>> GetSupportedFormats()
        {
            return supportedFormats;
        }

        /// <summary>
        /// Returns the genre of the media file based on the media data. The genre is based on what the specific media class it is.
        /// </summary>
        /// <param name="media"></param>
        /// <returns>The media genre.</returns>
        public static MediaType GetMediaType(NBMedia media)
        {
            Type mediaType = media.GetType();
            if (mediaType == typeof(NBAudio))
            {
                return MediaType.Audio;
            }
            else if (mediaType == typeof(NBVideo))
            {
                return MediaType.Video;
            }
            else if (mediaType == typeof(NBImage))
            {
                return MediaType.Image;
            }
            else
            {
                return MediaType.Unknown; // Return unknown for any other class.
            }
        }

        /// <summary>
        /// Returns the genre of the media file based on the given file extension.
        /// </summary>
        /// <param name="format">The file extension.</param>
        /// <returns>The media genre.</returns>
        public static MediaType GetMediaType(string format)
        {
            foreach (MediaType genre in supportedFormats.Keys) // Go through the list for each key.
            {
                if (supportedFormats[genre].IndexOf(format) != -1) // If the extension is included in a genre...
                {
                    return genre; // Return it.
                }
            }
            return MediaType.Unknown; // Return unknown genre.
        }
    }
}
