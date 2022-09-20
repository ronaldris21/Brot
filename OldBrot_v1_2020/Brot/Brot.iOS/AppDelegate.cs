﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.LocalNotifications;
using UIKit;
using Xamarin.Forms.GoogleMaps.iOS;

namespace Brot.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override void WillEnterForeground(UIApplication uiApplication)
        {
            Plugin.LocalNotification.NotificationCenter.ResetApplicationIconBadgeNumber(uiApplication);
        }
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();


            //Nugets!! Brot

            //Initialazing Rounded Img
            ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();
            //Images
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            //Initializaing Popup
            Rg.Plugins.Popup.Popup.Init();
            var platformConfig = new PlatformConfig
            {
                ImageFactory = new CachingImageFactory()
            };
            Xamarin.FormsGoogleMaps.Init("AIzaSyC2DvWFK5J0cdcO42MsTszUic-FQbePXaQ", platformConfig);
            
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
