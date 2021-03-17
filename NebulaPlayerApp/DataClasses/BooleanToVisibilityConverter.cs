/*
 * Caleb Lam
 * BooleanToVisibilityConverter
 * Updated: Jan. 9, 2020
 * Code for the class BooleanToVisibilityConverter. (See summary of class for details.)
 */

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace NebulaPlayerApp.DataClasses
{
    /// <summary>
    /// Converts a boolean (true or false) to a Visibility settings (Visible or Collapsed), and vice versa.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// FOrward conversion. Converts boolean to visibility. Only supports Visible (true) and Collapsed (false) values.
        /// </summary>
        /// <param name="value">The supplied BOOLEAN value.</param>
        /// <param name="targetType">The target data type to convert to. (Visibility)</param>
        /// <param name="parameter">The supplied additional info.</param>
        /// <param name="language">Language to use in the converter.</param>
        /// <returns>The Visibility value.</returns>
        public object Convert(object value, Type targetType, object parameter,
            string language)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Reverse conversion. Converts visibility to boolean. Only supports Visible (true) and Collapsed (false) values.
        /// </summary>
        /// <param name="value">The supplied VISIBILITY value.</param>
        /// <param name="targetType">The target data type to convert to. (Boolean)</param>
        /// <param name="parameter">The supplied additional info.</param>
        /// <param name="language">Language to use in the converter.</param>
        /// <returns>The boolean value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter,
            string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
