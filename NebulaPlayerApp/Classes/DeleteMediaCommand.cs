/*
 * Caleb Lam
 * DeleteMediaCommand
 * Updated: Jan. 13, 2020
 * Code for the class DeleteMediaCommand. (See summary of class for details.)
 */

using NebulaPlayerApp.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NebulaPlayerApp.Classes
{
    /// <summary>
    /// The command used to switch to the Player page and play the selected media.
    /// </summary>
    class DeleteMediaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged; // Must be here regardless of whether it is used. It may be fired by ICommand. This is fired when the permission to execute changes.

        /// <summary>
        /// Determines whether this command can execute. Returns whether the conditions to run are satisfied.
        /// Condition: A DeleteMediaArgs, which stores which media to delete, exists.
        /// </summary>
        /// <param name="parameter">The given parameter, which can be anything.</param>
        /// <returns>A boolean, which is the decision.</returns>
        public bool CanExecute(object parameter)
        {
            return parameter != null && (parameter.GetType() == typeof(DeleteMediaArgs));
        }

        /// <summary>
        /// Checks if the command can execute first, then executes the media deletion process.
        /// </summary>
        /// <param name="parameter">The given parameter, which can be anything.</param>
        public void Execute(object parameter)
        {
            DeleteMediaArgs args = parameter as DeleteMediaArgs;
            NBRegistry.RemoveMedia(args.TargetMedia);
        }
    }
}
