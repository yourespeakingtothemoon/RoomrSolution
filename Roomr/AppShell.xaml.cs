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
    }
}