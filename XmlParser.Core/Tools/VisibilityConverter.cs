﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XmlParser.Core.Tools
{
    public class VisibilityConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value == null ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Not needed
        }

        #endregion
    }
}
