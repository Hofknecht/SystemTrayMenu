// <copyright file="StaticResources.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Resources
{
    using System.Drawing;
    using System.Windows.Media;
    using SystemTrayMenu.Utilities;

    internal class StaticResources
    {
        internal static readonly Icon LoadingIcon = Properties.Resources.Loading;

        private static readonly object LoadingImgSrcLock = new ();

        private static ImageSource? loadingImgSrc;

        internal static ImageSource LoadingImgSrc
        {
            get
            {
                if (loadingImgSrc == null)
                {
                    lock (LoadingImgSrcLock)
                    {
                        if (loadingImgSrc == null)
                        {
                            loadingImgSrc = Properties.Resources.Loading.ToImageSource();
                            loadingImgSrc.Freeze(); // Make it accessible by any thread
                        }
                    }
                }

                return loadingImgSrc;
            }
        }
    }
}
