using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            // Alert to tell the user the button has been pressed
            //DisplayAlert("Success", "We have handled the click event", "Great!");
            Navigation.PushAsync(new MapPage());
        }



        private void MapToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}
