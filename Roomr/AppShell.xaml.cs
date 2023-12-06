using Roomr.Data;

namespace Roomr
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void Shell_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            await Current.GoToAsync("//MainPage");
        }

        private void listenerChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var listener = sender as TabBar;
            Console.WriteLine(listener.CurrentItem.Title);
            if (listener.CurrentItem.Title == "ProfilePage")
            {
                Globals.ProfilePerson = Globals.loggedInPerson;
            }
        }
    }
}