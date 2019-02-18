using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp02
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookPage : ContentPage
	{
		public NewBookPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_OnActivated(object sender, EventArgs e)
        {
            // Navigates us to the New book page when ToolBarItem is clicked
            Navigation.PushAsync(new MainPage());
        }
    }
}