/*
 * Caleb Lam
 * YourMediaPage
 * Updated: Jan. 9, 2020
 * Code for the class YourMediaPage. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using NebulaPlayerApp.Classes;
using NebulaPlayerApp.DataClasses;
using static NebulaPlayerApp.StaticClasses.NBRegistry; // NBRegistry's methods and properties will exist here without stating the class.

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NebulaPlayerApp
{
    /// <summary>
    /// Displays all your imported media. You can even clear the list as well.
    /// </summary>
    public sealed partial class YourMediaPage : Page
    {
        private ObservableCollection<NBMediaDataItem> mediaDataItems = new ObservableCollection<NBMediaDataItem>(); // Media data items. This stores items to display in the ListView and are different from just a NBMedia file and its inherited classes.

        private List<string> validMediaFormats = new List<string>(); // Valid media formats for file picker dialog. To be defined later.

        public YourMediaPage()
        {
            this.InitializeComponent();

            ReadOnlyDictionary<MediaType, List<string>> supportedFormats = GetSupportedFormats(); // Load in all the valid data formats.
            foreach (MediaType genre in supportedFormats.Keys)
            {
                foreach(string format in supportedFormats[genre])
                {
                    validMediaFormats.Add(format);
                }
            }
            ObservableCollection<NBMedia> registeredMedias = GetMedias(); // Get the current medias from NBRegistry.
            registeredMedias.CollectionChanged += RegisteredMedias_CollectionChanged; // When the saved medias change, the RegisteredMedias_CollectionChanged will be called.
        }

        /// <summary>
        /// Add the data of a single media.
        /// </summary>
        /// <param name="media"></param>
        private void addToMediaDataList(NBMedia media)
        {
            NBMediaDataItem newItem = new NBMediaDataItem(media);

            if (!mediaDataItems.Contains(newItem))
            {
                mediaDataItems.Add(newItem);
            }
        }

        /// <summary>
        /// Add the data of the medias in a list.
        /// </summary>
        /// <param name="newMedias"></param>
        private void addToMediaDataList(IList<NBMedia> newMedias)
        {
            foreach (NBMedia media in newMedias)
            {
                addToMediaDataList(media);
            }
        }

        /// <summary>
        /// Searches and removes data items of a specific media.
        /// </summary>
        /// <param name="toRemove"></param>
        private void removeFromMediaDataList(NBMedia toRemove)
        {
            IEnumerable<NBMediaDataItem> foundMediaDataItems = mediaDataItems.Where(item => item.Path == toRemove.Path);
            foreach (NBMediaDataItem item in foundMediaDataItems.ToList())
            {
                mediaDataItems.Remove(item);
            }
        }

        /// <summary>
        /// Fired when the list of saved media from NBRegistry changes.
        /// </summary>
        /// <param name="e">The event arguments to retrieve information about what happened.</param>
        private void RegisteredMedias_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) // Items that got added to the saved medias list.
            {
                foreach (object newMedia in e.NewItems)
                {
                    addToMediaDataList(newMedia as NBMedia); // Add the new stuff to the data items list.
                }
            }
            

            if (e.OldItems != null) // Single items that got deleted without clearing the whole saved medias list.
            {
                foreach (object oldMedia in e.OldItems)
                {
                    removeFromMediaDataList(oldMedia as NBMedia); // Remove the data items that are deleted in the registry as well.
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Reset) // All saved medias got deleted. Reset the data items here as well.
            {
                mediaDataItems.Clear(); // Clear the list. The registry of medias is empty anyways.
            }
        }

        /// <summary>
        /// When I click on a new item from the medias list, this will be called.
        /// </summary>
        /// <param name="e">Stores information about what happened to the selected item(s).</param>
        private void lstMedia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object prevItem in e.RemovedItems)
            {
                NBMediaDataItem item = prevItem as NBMediaDataItem;

                item.IsSelected = false;
            }

            foreach (object prevItem in e.AddedItems)
            {
                NBMediaDataItem item = prevItem as NBMediaDataItem;

                item.IsSelected = true;
            }
        }

        /// <summary>
        /// Before this page loads, this needs to happen.
        /// </summary>
        private void pgYourMedia_Loading(FrameworkElement sender, object args)
        {
            ObservableCollection<NBMedia> registeredMedias = GetMedias(); // get the stored medias.
            addToMediaDataList(registeredMedias.ToList()); // Add all the data items from the medias.
        }

        /// <summary>
        /// Opens up a file picker and lets you choose what to add to the registry when the Import button is clicked.
        /// </summary>
        private async void btnImport_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.VideosLibrary;

            foreach (string format in validMediaFormats)
            {
                picker.FileTypeFilter.Add(format);
            }
            

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    AddMedia(file);
                }
                catch
                {
                    new MessageDialog("Something went wrong while trying to discipher this file. It may be corrupted or invalid.").ShowAsync();
                }
            }
        }

        /// <summary>
        /// Clears all saved medias when the Clear List button is clicked.
        /// </summary>
        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            DeleteAllStoredMedias();
        }

        /// <summary>
        /// When the Play button is pressed, this is run to play the media.
        /// </summary>
        /// <param name="sender">Where the call comes from.</param>
        /// <param name="e">The information about the click.</param>
        private void btnPlayMedia_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            NBMediaDataItem mediaData = (NBMediaDataItem)clickedButton.DataContext;

            PlayMediasArgs args = new PlayMediasArgs(this, mediaData.MediaSource);
            PlayMediaCommand playMediaCommand = new PlayMediaCommand();

            if (playMediaCommand.CanExecute(args))
            {
                playMediaCommand.Execute(args);
            }
        }

        /// <summary>
        /// When the delete button is clicked, the media deletion process will execute when it passes all checks.
        /// </summary>
        /// <param name="sender">Where the call comes from.</param>
        /// <param name="e">The information about the click.</param>
        private void btnDeleteMedia_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            NBMediaDataItem mediaData = (NBMediaDataItem)clickedButton.DataContext;

            DeleteMediaArgs args = new DeleteMediaArgs(mediaData.MediaSource);
            DeleteMediaCommand deleteMediaCommand = new DeleteMediaCommand();

            if (deleteMediaCommand.CanExecute(args))
            {
                deleteMediaCommand.Execute(args);
            }
        }
    }
}
