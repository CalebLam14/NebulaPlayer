/*
 * Caleb Lam
 * NebulaBridge/Program
 * Updated: Jan. 9, 2020
 * Code for the class Program for the Nebulabridge console app. (See summary of class for details.)
 */

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KpopBandDatabase;
using KpopAlbumDatabase;

namespace NebulaBridge
{
    /// <summary>
    /// Main class for the bridge console app. Automatically hides the window and opens the application stated by the passed parameter from the main app.
    /// This class uses user32.dll, which is a C++ library.
    /// </summary>
    class Program
    {
        const string DEFAULT_APP = "bands"; // Default app to launch.

        // Captions (text displayed on top of the window) of the bands and albums database windows.
        const string BANDS_DATABASE_CAPTION = "Bands Database";
        const string ALBUMS_DATABASE_CAPTION = "Albums Database";

        /// <summary>
        /// Finds the integer pointer that points to the window with class name and the caption specified.
        /// </summary>
        /// <param name="lpClassName">Target class name.</param>
        /// <param name="lpWindowName">Target window caption.</param>
        /// <returns>The integer pointer to the window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)] // This method is from the user32.dll library.
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName); // Gets the current console window.

        /// <summary>
        /// Toggles how the specified window is shown.
        /// </summary>
        /// <param name="hWnd">The integer pointer to the window.</param>
        /// <param name="nCmdShow">0 to make the window invisible; 1 to make it visible.</param>
        /// <returns>If the window was previously visible, the return value is true. If the window was previously hidden, the return value is false.</returns>
        [DllImport("user32.dll")] // This method is from the user32.dll library.
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); // Toggles the supply window to show.

        /// <summary>
        /// Brings the specified window to the front.
        /// </summary>
        /// <param name="hWnd">The integer pointer to the window.</param>
        /// <returns>Whether the operation succeeds.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd); // Brings the target window to the front.

        /// <summary>
        /// The main code for the NebulaBridge app. The parameters will be automatically supplied by the main player app.
        /// </summary>
        /// <param name="args">Supplied arguments. The first two elements in the args array are information about the invocation of this method. All custom information given in the program (ex. information about the app to open which comes from the main player app) starts from the third element in the array.</param>
        [STAThread]
        private static void Main(string[] args)
        {

            string appName = (args.Length > 2) ? args[2] : DEFAULT_APP; // All passed parameters start with index 2. (0 and 1 are for information regarding the call of this Main method.)

            IntPtr windowHandle = FindWindow(null, "NebulaBridge"); // Get the handler (integer pointer) for the console window.

            if (windowHandle != IntPtr.Zero) // If the console window is found.
            {
                //Hide the window
                ShowWindow(windowHandle, 0); // 0 = SW_HIDE
            }

            IntPtr appWindowHandle;
            switch (appName)
            {
                case "bands": // Launch bands window
                    appWindowHandle = FindWindow(null, BANDS_DATABASE_CAPTION);
                    if (appWindowHandle == IntPtr.Zero) // If the bands database window is not found.
                    {
                        // Run the bands database app.
                        KpopBandDatabaseForm bandDatabaseForm = new KpopBandDatabaseForm();
                        bandDatabaseForm.Text = BANDS_DATABASE_CAPTION;
                        openNewApplication(bandDatabaseForm);
                    }
                    else // If found...
                    {
                        bringExistingAppWindowToFront(appWindowHandle); // Bring the existing window to the front.
                    }
                    break;

                case "albums": // Launch albums window
                    appWindowHandle = FindWindow(null, ALBUMS_DATABASE_CAPTION);
                    if (appWindowHandle == IntPtr.Zero) // If the albums database window is not found.
                    {
                        // RUn the albums database app.
                        KpopAlbumDatabaseForm albumDatabaseForm = new KpopAlbumDatabaseForm();
                        albumDatabaseForm.Text = ALBUMS_DATABASE_CAPTION;
                        openNewApplication(albumDatabaseForm);
                    }
                    else // If found...
                    {
                        bringExistingAppWindowToFront(appWindowHandle); // Bring the existing window to the front.
                    }
                    break;
            }
        }

        /// <summary>
        /// Opens the specified app in a new window.
        /// </summary>
        /// <param name="targetForm">The form to open.</param>
        private static void openNewApplication(Form targetForm)
        {
            Application.Run(targetForm);
        }

        /// <summary>
        /// Brings an existing app window to the front.
        /// </summary>
        /// <param name="hWnd">The integer pointer to the target window.</param>
        private static void bringExistingAppWindowToFront(IntPtr hWnd)
        {
            ShowWindow(hWnd, 9); // If the window is minimized, restore it using command 9.
            SetForegroundWindow(hWnd); // Bring it to the front.
        }
    }
}
