// <copyright file="StaticResources.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Resources
{
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.Utilities;

    internal static class StaticResources
    {
        internal static readonly Icon LoadingIcon = Properties.Resources.Loading;

        private static readonly object ApplicationImgSrcLock = new();
        private static readonly object LoadingImgSrcLock = new ();

        private static ImageSource? applicationgImgSrc;
        private static ImageSource? loadingImgSrc;

        public static ImageSource? ApplicationImgSrc
        {
            get
            {
                if (applicationgImgSrc == null)
                {
                    lock (ApplicationImgSrcLock)
                    {
                        if (applicationgImgSrc == null)
                        {
                            applicationgImgSrc = LoadFromAssemblyManifestResources("Resources.SystemTrayMenu.png");
                            applicationgImgSrc?.Freeze(); // Make it accessible for any thread
                        }
                    }
                }

                return applicationgImgSrc;
            }
        }

        public static ImageSource LoadingImgSrc
        {
            get
            {
                if (loadingImgSrc == null)
                {
                    lock (LoadingImgSrcLock)
                    {
                        if (loadingImgSrc == null)
                        {
                            loadingImgSrc = Properties.Resources.Loading.ToBitmapSource();
                            loadingImgSrc.Freeze(); // Make it accessible for any thread
                        }
                    }
                }

                return loadingImgSrc;
            }
        }

        private static ImageSource? LoadFromAssemblyManifestResources(string name)
        {
            Assembly myassembly = Assembly.GetExecutingAssembly();
            string myname = myassembly.GetName().Name ?? string.Empty;

            using (Stream? imgstream = myassembly.GetManifestResourceStream(myname + "." + name))
            {
                if (imgstream != null)
                {
                    BitmapImage imageSource = new();
                    imageSource.BeginInit();
                    imageSource.StreamSource = imgstream;
                    imageSource.EndInit();

                    return imageSource;
                }
            }

            return null;
        }
    }
}
