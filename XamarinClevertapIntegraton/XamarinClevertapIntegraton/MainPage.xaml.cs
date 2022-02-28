using Android.Util;
using Android.Widget;
using Com.Clevertap.Android.Sdk;
using Com.Clevertap.Android.Sdk.Displayunits.Model;
using Java.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace XamarinClevertapIntegraton
{
  
    public partial class MainPage : ContentPage
    {  
        private CleverTapAPI cleverTapAPI;

        
        public MainPage()
        {
            InitializeComponent();
            cleverTapAPI = CleverTapAPI.GetDefaultInstance(Android.App.Application.Context);
            
            //Notification Channel
            CleverTapAPI.CreateNotificationChannel(Android.App.Application.Context, "testkk123", "KK Xamarin Notification", "Karthik Xamarin Notification", 5, true);

            //onUserLogin
            userLoginPushProfile();

            //App Inbox
            cleverTapAPI.InitializeInbox();

        }

        private void Button_PushEvent_Clicked(object sender, EventArgs e)
        {
            cleverTapAPI.PushEvent("ProductXam View");
            Toast.MakeText(Android.App.Application.Context, "Pushed a Event", ToastLength.Short).Show();
        }

        private void Button_PushProfile_Clicked(object sender, EventArgs e)
        {
            profilePush();
            Toast.MakeText(Android.App.Application.Context, "Pushed a Event", ToastLength.Short).Show();
        }

        private void Button_Notification_Clicked(object sender, EventArgs e)
        {
            cleverTapAPI.PushEvent("Karthiks Noti Event");
            Toast.MakeText(Android.App.Application.Context, "Notification pushed button clicked", ToastLength.Short).Show();
        }

        private void Button_InApp_Clicked(object sender, EventArgs e)
        {
            cleverTapAPI.PushEvent("Karthiks InApp Event");
            Toast.MakeText(Android.App.Application.Context, "InApp Button clicked", ToastLength.Short).Show();
        }

        private void Button_AppInbox_Clicked(object sender, EventArgs e)
        {
            cleverTapAPI.PushEvent("Karthiks App Inbox Event");
            showInbox();
            Toast.MakeText(Android.App.Application.Context, "App Inbox Button clicked", ToastLength.Short).Show();
        }

        private void Button_NativeDisplay_Clicked(object sender, EventArgs e)
        {
            cleverTapAPI.PushEvent("Karthiks Native Display Event");
            Toast.MakeText(Android.App.Application.Context, "Native Display Button clicked", ToastLength.Short).Show();
        }

        private void showInbox() 
        {
            IList<string> tabs = new List<string>();
            tabs.Add("Promotions");
            tabs.Add("Offers");
            tabs.Add("Others");

            CTInboxStyleConfig styleConfig = new CTInboxStyleConfig();
            styleConfig.Tabs = tabs;
            styleConfig.TabBackgroundColor = "#FF0000";
            styleConfig.SelectedTabIndicatorColor = "#0000FF";
            styleConfig.SelectedTabColor = "#000000";
            styleConfig.UnselectedTabColor = "#FFFFFF";
            styleConfig.BackButtonColor = "#000000";
            styleConfig.NavBarTitleColor = "#000000";
            styleConfig.NavBarTitle = "MY INBOX";
            styleConfig.NavBarColor = "#FFFFFF";
            styleConfig.InboxBackgroundColor = "#F3F3F3";

            cleverTapAPI.ShowAppInbox(styleConfig);
        }

        private void userLoginPushProfile()
        {
            IDictionary<string, Java.Lang.Object> profile = new Dictionary<string, Java.Lang.Object>();

            profile.Add("Name", "Karthik Xamarin");
            profile.Add("Identity", "kkxam1234");
            profile.Add("Email", "kkxamarin@gmail.com");
            profile.Add("Phone", "+916667778881");
            profile.Add("Gender", "M");
            profile.Add("DOB", new Date());
            cleverTapAPI.OnUserLogin(profile);
        }

        private void profilePush()
        {
            IDictionary<string, Java.Lang.Object> profile = new Dictionary<string, Java.Lang.Object>();
            profile.Add("Customer Type", "Gold");
            profile.Add("MSG-email", true);
            profile.Add("MSG-sms", true);
            profile.Add("MSG-whatsapp", true);
            cleverTapAPI.PushProfile(profile);
        }

        public void InboxDidInitialize()
        {
            Toast.MakeText(Android.App.Application.Context, "Inbox Initialized", ToastLength.Short).Show();
            Log.Debug("CLEVERTAP", "Inbox Initialized");
        }

        public void InboxMessagesDidUpdate()    
        {
            Toast.MakeText(Android.App.Application.Context, "Inbox Updated", ToastLength.Short).Show();
            Log.Debug("CLEVERTAP", "Inbox UPdated");
        }
    }
}
