﻿//===============================================================================================================
// System  : Sandcastle Reflection Data Manager
// File    : VersionConverter.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 06/28/2015
// Note    : Copyright 2015, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains a value converter that converts between Version and String
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code and can be found at the project website: https://GitHub.com/EWSoftware/SHFB.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
// ==============================================================================================================
// 06/27/2015  EFW  Created the code
//===============================================================================================================

using System;
using System.Globalization;
using System.Windows.Data;

namespace ReflectionDataManager
{
    /// <summary>
    /// This value converter converts between <see cref="Version"/> and <see cref="String"/>
    /// </summary>
    public class VersionConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
                return String.Empty;

            return ((Version)value).ToString();
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Version version;

            if(value == null || !Version.TryParse((string)value, out version))
                version = new Version();

            return version;
        }
    }
}
