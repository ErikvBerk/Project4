using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace inputFields
{
    [Activity(Label = "inputFields", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.SensorLandscape)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            TextView text = FindViewById<TextView>(Resource.Id.editText2);
            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Text = string.Format("Click to confirm name");

            button.Click += delegate {
                string name = text.Text;
            };
        }
}
}

