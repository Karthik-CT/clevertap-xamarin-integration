using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.Clevertap.Android.Sdk;
using System.Collections.Generic;
using Java.Util;
using Android.Widget;
using Com.Clevertap.Android.Sdk.Displayunits;
using Com.Clevertap.Android.Sdk.Displayunits.Model;
using Android.Util;

namespace XamarinClevertapIntegraton.Droid
{
    [Activity(Label = "XamarinClevertapIntegraton", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IInboxMessageButtonListener, IDisplayUnitListener
    {

        private CleverTapAPI cleverTapAPI;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            cleverTapAPI = CleverTapAPI.GetDefaultInstance(Android.App.Application.Context);
            cleverTapAPI.SetDisplayUnitListener(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void IInboxMessageButtonListener.OnInboxButtonClick(IDictionary<string, string> p0)
        {
            throw new NotImplementedException();
        }

        void IDisplayUnitListener.OnDisplayUnitsLoaded(IList<CleverTapDisplayUnit> p0)
        {
            Toast.MakeText(Android.App.Application.Context, "Display Units Loaded", ToastLength.Short).Show();
            foreach (CleverTapDisplayUnit p in p0) 
            {
                Log.Debug("KKDisplay", p.Contents[0].Title);
                Log.Debug("KKDisplay", p.Contents[0].Message);

                cleverTapAPI.PushDisplayUnitClickedEventForID(p.UnitID);
                cleverTapAPI.PushDisplayUnitViewedEventForID(p.UnitID);
            }
            //Log.Debug("CLEVERTAP", p0.ToString());
        }
    }
}