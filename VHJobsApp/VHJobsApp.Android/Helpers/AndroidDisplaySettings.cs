using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TMDbApp.Interfaces;
using Android.Content.Res;

namespace TMDbApp.Droid.Helpers
{
    public class AndroidDisplaySettings : IDisplaySettings
    {
        public int GetHeight()
        {
            return Resources.System.DisplayMetrics.HeightPixels;
        }
        public int GetWidth()
        {
            return Resources.System.DisplayMetrics.WidthPixels;
        }
    }
}