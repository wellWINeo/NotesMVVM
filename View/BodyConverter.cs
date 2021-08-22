using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

using NotesMVVM.Model;

namespace NotesMVVM.View
{
    class BodyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var symbolLen = 15;
            var noteBody = value as string;

            if (noteBody.Contains('\n'))
                noteBody = noteBody.Split('\n')[0].TrimEnd();

            return noteBody.Length >= symbolLen ?
                $"{noteBody.Substring(0, symbolLen)}..." :
                noteBody;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
