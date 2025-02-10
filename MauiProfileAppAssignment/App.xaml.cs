using MauiProfileAppAssignment.Pages;

namespace MauiProfileAppAssignment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProfilePage());

        }
    }
}
