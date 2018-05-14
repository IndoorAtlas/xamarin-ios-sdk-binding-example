using System;
using UIKit;
using IndoorAtlas.iOS;
using CoreGraphics;

namespace IndoorAtlasBindingClient
{
    public partial class ViewController : UIViewController
    {
        private IALocationManager locationManager;
        private LocationHandler locationHandler;

        private partial class LocationHandler : IALocationManagerDelegate
        {
            public override void DidUpdateLocations(IALocationManager manager, IALocation[] locations)
            {
                var cl = locations[0].Location;
                Console.WriteLine("lat: {0} lon: {1}", cl.Coordinate.Latitude, cl.Coordinate.Longitude);
            }
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Console.WriteLine("Starting");

            locationHandler = new LocationHandler();
            locationManager = new IALocationManager();

            locationManager.SetApiKey("API-KEY", "API-SECRET");
            locationManager.Delegate = locationHandler;
            locationManager.StartUpdatingLocation();

        }
    }
}
