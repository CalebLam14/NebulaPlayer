/*
 * Caleb Lam
 * BandsPage
 * Updated: Jan. 9, 2020
 * Code for the class BandsPage. (See summary of class for details.)
 */

using System;
using Windows.ApplicationModel;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NebulaPlayerApp
{
    /// <summary>
    /// Page to take you to the K-Pop and Albums database app. It is a work in progress.
    /// </summary>
    public sealed partial class BandPage : Page
    {
        
        public BandPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When the Launch Bands App button is clicked, this runs. Does nothing as of now.
        /// </summary>
        /// <param name="sender">Where the call comes from.</param>
        /// <param name="e">THe information about the click.</param>
        private async void btnLaunchBands_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Bands");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLaunchAlbums_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Albums");
            }
        }
    }
}
