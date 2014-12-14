﻿//===============================================================================================================
// System  : Sandcastle Help File Builder Visual Studio Package
// File    : XmlCommentsLinkQuickInfoControllerProvider.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 12/08/2014
// Note    : Copyright 2014, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains the class that creates the quick info controller specific to XML comments elements
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code.  It can also be found at the project website: http://SHFB.CodePlex.com.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
//===============================================================================================================
// 12/01/2014  EFW  Created the code
//===============================================================================================================

using System.Collections.Generic;
using System.ComponentModel.Composition;

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace SandcastleBuilder.Package.GoToDefinition
{
    /// <summary>
    /// This class creates the quick info controller specific to XML comments elements
    /// </summary>
    [Export(typeof(IIntellisenseControllerProvider))]
    [Name("XML Comments Link Quick Info Controller")]
    [ContentType("csharp")]
    internal sealed class XmlCommentsLinkQuickInfoControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        internal IQuickInfoBroker QuickInfoBroker { get; set; }

        /// <inheritdoc />
        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            if(!MefProviderOptions.EnableGoToDefinition)
                return null;

            return new XmlCommentsLinkQuickInfoController(textView, subjectBuffers, this);
        }
    }
}