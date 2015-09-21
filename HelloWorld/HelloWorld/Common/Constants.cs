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
            public static readonly string AppxAssetsFolder = "ms-appx:///Assets/";
        }

        public static class PlaneImageUri
        {
            public static readonly Uri PlaneSide = new Uri("planeSide.jpg", UriKind.Relative);
            public static readonly Uri PlaneTop = new Uri("planeTop.jpg", UriKind.Relative);
        }

        public static class ButtonImageUri
        {
            public static readonly string PlaneSideButtonNotSelected = "planeSideButtonNotSelected.jpg";
            public static readonly string PlaneSideButtonSelected = "planeSideButtonSelected.jpg";

            public static readonly string PlaneTopButtonNotSelected = "LoadOnPlaneGreen.png";
            public static readonly string PlaneTopButtonSelected = "LoadOnPlaneRed.png";


        }


    }
}
