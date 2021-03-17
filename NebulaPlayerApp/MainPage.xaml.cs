/*
 * Caleb Lam
 * MainPage
 * Updated: Jan. 9, 2020
 * Code for the class MainPage. (See summary of class for details.)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NebulaPlayerApp.StaticClasses;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NebulaPlayerApp
{
    /// <summary>
    /// The main page of the app. This is where it loads other pages.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            NBRegistry.Init(); // Initializa the registry by loading the saved medias and playlists.
        }

        private string currentTag = ""; // Each page tab on the top is tagged with a word. The three are "media", "playlists" and "player". This keeps track of where we are.

        /// <summary>
        /// When one of the page tabs is clicked.
        /// </summary>
        /// <param name="args">Information about the click.</param>
        private void nvTabs_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem) as NavigationViewItem; // Find which item is clicked.
            navigate(item); // Change page based on that clicked item.
        }

        private void navigate(NavigationViewItem item)
        {
            string tag = item.Tag.ToString(); // Get the tag of the clicked item.

            if (currentTag != tag) // Change page only if it is different. Navigate switches the page by specifying which type of page you want to switch to.
            {
                currentTag = tag;
                switch (tag)
                {
                    case "media":
                        frMainContent.Navigate(typeof(YourMediaPage));
                        break;

                    case "player":
                        frMainContent.Navigate(typeof(PlayerPage));
                        break;

                    case "people":
                        frMainContent.Navigate(typeof(BandPage));
                        break;
                }
            }
        }

        private void navigate(NavigationViewItem item, object args)
        {
            string tag = item.Tag.ToString(); // Get the tag of the clicked item.

            if (currentTag != tag) // Change page only if it is different. Navigate switches the page by specifying which type of page you want to switch to.
            {
                currentTag = tag;
                switch (tag)
                {
                    case "media":
                        frMainContent.Navigate(typeof(YourMediaPage), args);
                        break;

                    case "player":
                        frMainContent.Navigate(typeof(PlayerPage), args);
                        break;
                }
            }
        }

        public void SwitchToPage(string pageTag, object args)
        {
            List<object> foundItemsWithTag = nvTabs.MenuItems.Where(item => (item as NavigationViewItem).Tag.ToString() == pageTag).ToList();

            if (foundItemsWithTag.Count > 0)
            {
                NavigationViewItem targetItem = foundItemsWithTag[0] as NavigationViewItem;
                navigate(targetItem, args);
            }
        }

        private void frMainContent_Navigated(object sender, NavigationEventArgs e)
        {
            Type newPageType = e.Content.GetType();
            
            if (newPageType == typeof(YourMediaPage))
            {
                nvTabs.SelectedItem = nvTabs.MenuItems[1];
                currentTag = "media";
            }
            else if (newPageType == typeof(PlayerPage))
            {
                nvTabs.SelectedItem = nvTabs.MenuItems[2];
                currentTag = "player";
            }
            
        }
    }
}
