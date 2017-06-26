using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework;
using System;

namespace project_4_android
{
    [Activity(Label = "project 4 android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }
        //public static void ShowKeyboard()
        //{
        //    var pView = KeyboardConfig.game.Services.GetService<View>();
        //    var inputMethodManager = KeyboardConfig.Application.GetSystemService(Context.InputMethodService) as InputMethodManager;
        //    inputMethodManager.ShowSoftInput(pView, ShowFlags.Forced);
        //    inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        //}
        //public static void HideKeyboard()
        //{
        //    InputMethodManager inputMethodManager = KeyboardConfig.Application.GetSystemService(Context.InputMethodService) as InputMethodManager;
        //    inputMethodManager.HideSoftInputFromWindow(KeyboardConfig.pView.WindowToken, HideSoftInputFlags.None);
        //}
    }
}

