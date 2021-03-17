/*
 * Caleb Lam
 * PlayerPage
 * Updated: Jan. 9, 2020
 * Coded methods for the class PlayerPage. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using NebulaPlayerApp.Classes;
using NebulaPlayerApp.StaticClasses;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NebulaPlayerApp
{
    /// <summary>
    /// This is where you play the media. This uses the NBPlayerState to store temporary player information, including time position, saved media if no new media is passed.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        public PlayerPage()
        {
            InitializeComponent();
        }

        // The current MediaPlayer object for playback.
        private MediaPlayer currentMediaPlayer;

        /// <summary>
        /// Saves the current state of the player, which includes the source and position into the source.
        /// </summary>
        private void savePlayerState()
        {
            // savedSource = currentMediaPlayer.Source;
            NBPlayerState.CurrentPosition = currentMediaPlayer.PlaybackSession.Position;
        }

        /// <summary>
        /// Load back where we are and the current source to continue from there.
        /// </summary>
        private async void loadPlayerState()
        {
            // Check if each stored setting is available (not null) and change the media player element based on that.

            if (NBPlayerState.CurrentPlaylist != null)
            {
                if (NBPlayerState.CurrentSourceIndex != null)
                {
                    if (NBRegistry.GetMedias().Contains(NBPlayerState.CurrentMediaList[(int)NBPlayerState.CurrentSourceIndex]))
                    {
                        NBPlayerState.CurrentPlaylist.MoveTo((uint)NBPlayerState.CurrentSourceIndex);

                        string mediaName = NBPlayerState.CurrentMediaList[(int)NBPlayerState.CurrentSourceIndex].Name;
                        lblMediaTitle.Text = mediaName;
                    }
                    else
                    {
                        NBPlayerState.CurrentPlaylist.Items.RemoveAt((int)NBPlayerState.CurrentSourceIndex);
                        if (NBPlayerState.CurrentSourceIndex + 1 < NBPlayerState.CurrentPlaylist.Items.Count)
                        {
                            NBPlayerState.CurrentPlaylist.MoveTo((uint)NBPlayerState.CurrentSourceIndex + 1);
                        }
                        else if (NBPlayerState.CurrentSourceIndex - 1 >= 0)
                        {
                            NBPlayerState.CurrentPlaylist.MoveTo((uint)NBPlayerState.CurrentSourceIndex - 1);
                        }
                        else
                        {
                            currentMediaPlayer.Source = null;
                            lblMediaTitle.Text = "Nope. No media here yet...";
                        }
                    }
                }

                if (NBPlayerState.CurrentPosition != null)
                {
                    currentMediaPlayer.PlaybackSession.Position = NBPlayerState.CurrentPosition;
                }
            }
            else if (NBPlayerState.CurrentImage != null)
            {
                medPlayer.Visibility = Visibility.Collapsed;

                FileRandomAccessStream stream = (FileRandomAccessStream)await NBPlayerState.CurrentImage.MediaFile.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                await image.SetSourceAsync(stream);
                imgDisplayer.Source = image;

                imgDisplayerFrame.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Loads a new source into the player from a media data object. 
        /// </summary>
        /// <param name="targetMedia">The object to provide for loading into the player.</param>
        private async void loadSource(List<NBMedia> targetMedias)
        {
            if (NBPlayerState.CurrentPlaylist != null)
            {
                NBPlayerState.CurrentPlaylist.CurrentItemChanged -= Playlist_CurrentItemChanged;
            }
            
            if (targetMedias[0].GetType() != typeof(NBImage))
            {
                imgDisplayerFrame.Visibility = Visibility.Collapsed;
                medPlayer.Visibility = Visibility.Visible;

                MediaPlaybackList playlist = new MediaPlaybackList();
                List<NBPlayableMedia> mediaList = new List<NBPlayableMedia>();

                foreach (NBMedia media in targetMedias)
                {
                    MediaSource source = MediaSource.CreateFromStorageFile(media.MediaFile);
                    MediaPlaybackItem playbackItem = new MediaPlaybackItem(source);
                    playbackItem.CanSkip = true;
                    playlist.Items.Add(playbackItem);
                }
                NBPlayerState.CurrentMediaList = targetMedias;
                NBPlayerState.CurrentSourceIndex = 0;
                NBPlayerState.CurrentImage = null;

                playlist.CurrentItemChanged += Playlist_CurrentItemChanged;
                playlist.ItemFailed += Playlist_ItemFailed;

                NBPlayerState.CurrentPlaylist = playlist;
                currentMediaPlayer.Source = playlist;
                
                currentMediaPlayer.Play();
            }
            else
            {
                medPlayer.Visibility = Visibility.Collapsed;

                FileRandomAccessStream stream = (FileRandomAccessStream)await targetMedias[0].MediaFile.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                await image.SetSourceAsync(stream);
                imgDisplayer.Source = image;

                NBPlayerState.CurrentImage = targetMedias[0] as NBImage;
                NBPlayerState.CurrentSourceIndex = 0;
                NBPlayerState.CurrentPosition = new TimeSpan(0);
                NBPlayerState.CurrentPlaylist = null;

                imgDisplayerFrame.Visibility = Visibility.Visible;
            }

            lblMediaTitle.Text = targetMedias[(int)NBPlayerState.CurrentSourceIndex].Name;
        }

        /// <summary>
        /// This is here in case something goes wrong while importing the media.
        /// </summary>
        /// <param name="sender">The list that called the fail.</param>
        /// <param name="args">Information about the fail.</param>
        private void Playlist_ItemFailed(MediaPlaybackList sender, MediaPlaybackItemFailedEventArgs args)
        {
            MediaPlaybackItemError e = args.Error;
            new MessageDialog("Something went wrong, so we could not play this media: " + e.ErrorCode).ShowAsync();
        }

        /// <summary>
        /// When the current item of the list changes.
        /// </summary>
        /// <param name="sender">The list that called the change.</param>
        /// <param name="args">Information about the change. Includes the previous and new item.</param>
        private async void Playlist_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            int itemIndex = sender.Items.IndexOf(args.NewItem);
            if (itemIndex != -1)
            {
                NBPlayerState.CurrentSourceIndex = itemIndex;
                
                string mediaName = NBPlayerState.CurrentMediaList[(int)NBPlayerState.CurrentSourceIndex].Name;

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    lblMediaTitle.Text = mediaName;
                });
                
            }
        }

        /// <summary>
        /// When you are leaving the page. This is where the caching runs.
        /// </summary>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            currentMediaPlayer.Pause(); // Pause the playback.
            savePlayerState(); // Save the player's state to load later.

            medPlayer.SetMediaPlayer(null);
            currentMediaPlayer.Dispose();
            base.OnNavigatedFrom(e); // Actually navigate to another page.
        }

        /// <summary>
        /// When you are coming to this page. This loads the cached data.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PlayMediasArgs playArgs = e.Parameter as PlayMediasArgs; // Did you come to this page to play something new?

            currentMediaPlayer = new MediaPlayer();
            currentMediaPlayer.Source = (playArgs == null) ? NBPlayerState.CurrentPlaylist : null;
            medPlayer.SetMediaPlayer(currentMediaPlayer);
            
            if (playArgs != null)
            {
                loadSource(playArgs.Medias); // If so, load the new source.
            }
            else
            {
                loadPlayerState(); // Otherwise, continue playing the current source.
            }
            base.OnNavigatedTo(e); // Actually navigate to this page.
        }
    }
}
