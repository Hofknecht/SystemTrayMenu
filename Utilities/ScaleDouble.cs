// <copyright file="ScaleDouble.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows.Markup;

    internal class ScaleDouble : MarkupExtension
    {
        private readonly double value;

        public ScaleDouble(string original)
        {
            value = double.Parse(original);
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => Scaling.Scale(value);
    }
}
