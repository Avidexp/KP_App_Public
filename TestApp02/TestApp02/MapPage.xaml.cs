using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp02
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            CameraButton.Clicked += CameraButton_OnClicked;
        }
        private async void CameraButton_OnClicked(object sender, EventArgs e)
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }

        }

        private async void Button2_OnClicked(object sender, EventArgs e)
        {

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
       
                if (location != null)
                {
                    if (location != null)
                    {
                        string test =
                            $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                        await DisplayAlert("Success", test, "Thanks!", "Cancel");
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }
                }
            }
            //catch (FeatureNotSupportedException fnsEx)
            //{
            //    // Handle not supported on device exception
            //}
            //catch (FeatureNotEnabledException fneEx)
            //{
            //    // Handle not enabled on device exception
            //}
            //catch (PermissionException pEx)
            //{
            //    // Handle permission exception
            //}
            catch (Exception ex)
            {
                await DisplayAlert("Failure", ex.Message, "Okay Thanks!");
                // Unable to get location
            }
        }
        public class RequestModel
        {
            public string CustomerTicketNumber { get; set; }
            public string DeliveryTicketNumber { get; set; }
            public string UnleadedGas { get; set; }
            public string SuperGas { get; set; }
            public string ClearDiesel { get; set; }
            public string RedDiesel { get; set; }
            public string Lat { get; set; }
            public string Long { get; set; }
            public DateTime dateSent { get; set; }
            public string Address { get; set; }
        }
        private async void ForSubmitBtn_Clicked(object sender, EventArgs e)
        {
            bool CustomerNumberEmpty = string.IsNullOrEmpty(CustomerNumber.Text);
            bool DeliveryTicketEmpty = string.IsNullOrEmpty(DeliveryTicket.Text);

            bool UnleadedGasEmpty = string.IsNullOrEmpty(UnleadedGas.Text);
            bool SuperGasEmpty = string.IsNullOrEmpty(SuperGas.Text);
            bool ClearDieselEmpty = string.IsNullOrEmpty(ClearDiesel.Text);
            bool RedDieselEmpty = string.IsNullOrEmpty(RedDiesel.Text);

            if (DeliveryTicketEmpty || CustomerNumberEmpty  )
            {
                
            

            }
            else
            {
                string CustomerNumber = this.CustomerNumber.Text;
                string DeliveryTicketNumber = DeliveryTicket.Text;
                string UnleadedGas = this.UnleadedGas.Text;
                string SuperGas = this.SuperGas.Text;
                string ClearDiesel = this.ClearDiesel.Text;
                string RedDiesel = this.RedDiesel.Text;
                bool RedDieselChecked = RedDieselCheck.IsChecked;
                bool SuperGasChecked = SuperGasCheck.IsChecked;
                bool ClearDieselChecked = ClearDieselCheck.IsChecked;
                bool UnleadedChecked = UnleadedGasCheck.IsChecked;

                string Address;
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {

                        // after lat lng, then issue rest request to google maps to get address
                        string test =
                            $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                        RequestModel requestModel = new RequestModel();
                        requestModel.CustomerTicketNumber = CustomerNumber;
                        requestModel.DeliveryTicketNumber = DeliveryTicketNumber;
                        requestModel.Lat = location.Latitude.ToString();
                        requestModel.Long = location.Longitude.ToString();
                        requestModel.dateSent = DateTime.Now;

                        if (ClearDieselChecked)
                        {
                            requestModel.ClearDiesel = ClearDiesel;

                        }

                        if (SuperGasChecked)
                        {
                            requestModel.SuperGas = SuperGas;

                        }

                        if (RedDieselChecked)
                        {
                            requestModel.RedDiesel = RedDiesel;

                        }

                        if (UnleadedChecked)
                        {
                            requestModel.UnleadedGas = UnleadedGas;
                        }

                        string fullRequest = JsonConvert.SerializeObject(requestModel);
                        await DisplayAlert("Success", fullRequest, "Thanks!", "Cancel");

                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    }
                }

                catch (Exception ex)
                {
                    await DisplayAlert("Failure", ex.Message, "Okay Thanks!");
                    // Unable to get location
                }

            }

        }

        
    }
}