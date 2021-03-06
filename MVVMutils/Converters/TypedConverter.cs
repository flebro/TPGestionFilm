﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMutils.Converters
{
    /// <summary>
    /// Implémetation abstraite de IValueConverter afin de failiter la création de converter et plus particulièrement en assurer le Safe Typing
    /// </summary>
    /// <typeparam name="U">Type source</typeparam>
    /// <typeparam name="T">Type de destination</typeparam>
    public abstract class TypedConverter<U, T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is U castedValue)
            {
                return Convert(castedValue, parameter, culture);
            }
            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is T castedValue)
            {
                return ConvertBack(castedValue, parameter, culture);
            }
            throw new ArgumentException();
        }

        protected abstract T Convert(U value, object parameter, CultureInfo culture);

        protected abstract U ConvertBack(T value, object parameter, CultureInfo culture);

    }
}
