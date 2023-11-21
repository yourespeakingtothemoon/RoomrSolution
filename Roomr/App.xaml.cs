using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}