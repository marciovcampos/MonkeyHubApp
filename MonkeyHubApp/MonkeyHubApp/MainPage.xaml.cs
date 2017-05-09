using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;


namespace MonkeyHubApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation?.PushAsync(new MainPage());
        }

        private void ButtonModal_Clicked(object sender, EventArgs e)
        {
            Navigation?.PushModalAsync(new NavigationPage(new MainPage()));
        }               

        private void ButtonModalVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation?.PopModalAsync();
        }


    }
}
