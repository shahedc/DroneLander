using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DroneLander.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Flash(x => x.Text("Sign In"));
            app.SetOrientationLandscape();
            app.PressVolumeDown();
            app.PressVolumeDown();
            app.SetOrientationPortrait();
            app.Tap(x=> x.Marked("StartButton"));
            app.WaitForElement(x=> x.Button("Reset"));
            app.Flash(x => x.Marked("Reset"));
            app.PressVolumeUp();
            app.PressVolumeUp();
        }

        [Test]
        public void SignInAndCheckActivity()
        {
            app.Tap(x => x.Text("Start"));
            app.SetSliderValue(x => x.Class("FormsSeekBar"), 1000);
            System.Threading.Thread.Sleep(2000);
            app.Screenshot("Drone Lander in action");
            app.Tap(x => x.Text("Reset"));
        }


        //[Test]
        //public void SignInAndCheckActivity()
        //{
        //    app.Tap(x => x.Marked("Sign In"));

        //    app.WaitForElement(c => c.WebView().Css("INPUT#i0116"));
        //    app.EnterText(x => x.WebView().Css("INPUT#i0116"), "YOUR_MICROSOFT_ACCOUNT_EMAIL_ADDRESS");
        //    app.Tap(x => x.WebView().Css("INPUT#idSIButton9"));
        //    System.Threading.Thread.Sleep(4000);
        //    app.EnterText(x => x.WebView().Css("INPUT#i0118"), "YOUR_MICROSOFT_ACCOUNT_PASSWORD");
        //    app.Tap(x => x.WebView().Css("INPUT#idSIButton9"));


        //    app.Tap(x => x.Marked("Activity"));
        //    app.WaitForElement(x => x.Text("Kaboom"));
        //    app.Back();
        //    app.Tap(x => x.Text("Start"));
        //    app.SetSliderValue(x => x.Class("FormsSeekBar"), 1000);
        //    System.Threading.Thread.Sleep(2000);
        //    app.Tap(x => x.Text("Reset"));
        //}
    }
}

