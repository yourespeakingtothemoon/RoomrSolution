using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr
{
    public partial class App : Application
    {
        public static Person loggedInPerson;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}