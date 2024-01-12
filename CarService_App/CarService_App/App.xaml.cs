using CarService_App.Services;
using CarService_App.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace CarService_App
{
    public partial class App : Application
    {
        // Define the database name
        public const string DATABASE_NAME = "Cars.db";
        public static DatabaseService database;
        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    database = new DatabaseService(databasePath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CarServicePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }


}


