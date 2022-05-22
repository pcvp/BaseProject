﻿using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseApp.Converters {
    public class InvertBooleanConverter : IValueConverter, IMarkupExtension {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}