﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ControlWorks
{
    public class ConversorTrueVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                if (value.ToString() != "")
                {
                    try
                    {
                        bool valor = (bool)value;
                        if (valor)
                        {
                            return Visibility.Visible;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
