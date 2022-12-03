// <copyright file="Translate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows.Markup;

    public class Translate : MarkupExtension
    {
        private readonly string original;

        public Translate(string original)
        {
            this.original = original;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => Translator.GetText(original);
    }
}
