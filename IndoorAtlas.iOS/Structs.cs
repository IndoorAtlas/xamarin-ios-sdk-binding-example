using System;
using System.Runtime.InteropServices;
using CoreLocation;
using ObjCRuntime;

namespace IndoorAtlas.iOS
{
    [Native]
    public enum ia_region_type : long
    {
        Unknown,
        FloorPlan,
        Venue,
        Geofence
    }

    [Native]
    public enum ia_status_type : long
    {
        OutOfService = 0,
        Unavailable = 1,
        Available = 2,
        Limited = 10
    }

    [Native]
    public enum ia_calibration : long
    {
        Poor,
        Good,
        Excellent
    }

    [Native]
    public enum ia_location_accuracy : long
    {
        Best,
        Low
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct ia_bounding_box
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public CLLocationCoordinate2D[] coords;
    }
}
