using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// First page of the application that runs
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestApp02
{
    public partial class App : Application
    {
        public static string DatabaseLocation = "";
        public App()
        {
            InitializeComponent();

            // Navigation page allows us to navigate to different pages
            // it's argument (new MainPage()) is the main page the app loads to 
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {

            MainPage = new NavigationPage(new MainPage());
            DatabaseLocation = databaseLocation;

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
