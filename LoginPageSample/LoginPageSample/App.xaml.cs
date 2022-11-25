using System;
using System.IO;
using LoginPageSample.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageSample
{
    public partial class App : Application
    {

        static AccountDatabase database;

        // Create the database connection as a singleton.
        public static AccountDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AccountDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Accounts.db3"));
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new LoginPageSample.Pages.LoginPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

