using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using FFImageLoading.Forms.Droid;

namespace VHJobsApp.Droid
{
    [Activity(Label = "VHJobsApp", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CachedImageRenderer.Init();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App(new AppSetup()));
        }
    }
}