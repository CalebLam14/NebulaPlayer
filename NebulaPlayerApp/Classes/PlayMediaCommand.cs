/*
 * Caleb Lam
 * PlayMediaCommand
 * Updated: Jan. 9, 2020
 * Code for the class PlayMediaCommand. (See summary of class for details.)
 */

using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// The command used to switch to the Player page and play the selected media.
    /// </summary>
    class PlayMediaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged; // Must be here regardless of whether it is used. It may be fired by ICommand. This is fired when the permission to execute changes.

        /// <summary>
        /// Determines whether this command can execute. Returns whether the conditions to run are satisfied.
        /// Condition: A PlayMediasArgs, which houses all of the information about the transition and media, exists.
        /// </summary>
        /// <param name="parameter">The given parameter, which can be anything.</param>
        /// <returns>A boolean, which is the decision.</returns>
        public bool CanExecute(object parameter)
        {
            return parameter != null && (parameter.GetType() == typeof(PlayMediasArgs));
        }

        /// <summary>
        /// Checks if the command can execute first, then transitions to the player and runs it.
        /// </summary>
        /// <param name="parameter">The given parameter, which can be anything.</param>
        public void Execute(object parameter)
        {
            PlayMediasArgs args = parameter as PlayMediasArgs;
            Frame frame = args.FromPage.Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(PlayerPage), args); // Transition with the media arguments for the Player to know we are playing something new.
            }
        }
    }
}
