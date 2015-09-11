using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TMissionMobile.Common
{
    public static class Constants
    {
        public static class FolderNames
        {
            public static readonly string AssetsFolder = "Assets";
        }

        public static class ImageUri
        {
            public static readonly Uri PlaneSide = new Uri("planeSide.jpg", UriKind.Relative);
            public static readonly Uri PlaneTop = new Uri("planeTop.jpg", UriKind.Relative);
            
                
        }

    }
}
