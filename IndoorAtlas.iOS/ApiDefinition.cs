using System;
using CoreGraphics;
using CoreLocation;
using CoreMotion;
using Foundation;
using IndoorAtlas;
using ObjCRuntime;

namespace IndoorAtlas.iOS
{
    // @interface IAFloor : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface IAFloor : INSCoding
    {
        // +(IAFloor * _Nonnull)floorWithLevel:(NSInteger)level;
        [Static]
        [Export("floorWithLevel:")]
        IAFloor FloorWithLevel(nint level);

        // @property (readonly, nonatomic) NSInteger level;
        [Export("level")]
        nint Level { get; }

        // @property (readonly, nonatomic) IACertainty certainty;
        [Export("certainty")]
        double Certainty { get; }
    }

    // @interface IAFloorPlan : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface IAFloorPlan : INSCoding
    {
        // @property (readonly, nonatomic) NSString * _Nullable floorPlanId;
        [NullAllowed, Export("floorPlanId")]
        string FloorPlanId { get; }

        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSURL * _Nullable imageUrl;
        [NullAllowed, Export("imageUrl")]
        NSUrl ImageUrl { get; }

        // @property (readonly, nonatomic) NSUInteger width;
        [Export("width")]
        nuint Width { get; }

        // @property (readonly, nonatomic) NSUInteger height;
        [Export("height")]
        nuint Height { get; }

        // @property (readonly, nonatomic) float pixelToMeterConversion;
        [Export("pixelToMeterConversion")]
        float PixelToMeterConversion { get; }

        // @property (readonly, nonatomic) float meterToPixelConversion;
        [Export("meterToPixelConversion")]
        float MeterToPixelConversion { get; }

        // @property (readonly, nonatomic) float widthMeters;
        [Export("widthMeters")]
        float WidthMeters { get; }

        // @property (readonly, nonatomic) float heightMeters;
        [Export("heightMeters")]
        float HeightMeters { get; }

        // @property (readonly, nonatomic) IAFloor * _Nullable floor;
        [NullAllowed, Export("floor")]
        IAFloor Floor { get; }

        // @property (readonly, nonatomic) double bearing;
        [Export("bearing")]
        double Bearing { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D center;
        [Export("center")]
        CLLocationCoordinate2D Center { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D topLeft;
        [Export("topLeft")]
        CLLocationCoordinate2D TopLeft { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D topRight;
        [Export("topRight")]
        CLLocationCoordinate2D TopRight { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D bottomLeft;
        [Export("bottomLeft")]
        CLLocationCoordinate2D BottomLeft { get; }

        // -(CGPoint)coordinateToPoint:(CLLocationCoordinate2D)coord;
        [Export("coordinateToPoint:")]
        CGPoint CoordinateToPoint(CLLocationCoordinate2D coord);

        // -(CLLocationCoordinate2D)pointToCoordinate:(CGPoint)point;
        [Export("pointToCoordinate:")]
        CLLocationCoordinate2D PointToCoordinate(CGPoint point);

        // -(id _Nullable)initWithId:(NSString * _Nullable)floorPlanId width:(NSUInteger)width height:(NSUInteger)height wgs2pix:(NSArray * _Nullable)wgsToPixel pix2wgs:(NSArray * _Nullable)pixelToWgs;
        [Export("initWithId:width:height:wgs2pix:pix2wgs:")]
        IntPtr Constructor([NullAllowed] string floorPlanId, nuint width, nuint height, [NullAllowed] NSObject[] wgsToPixel, [NullAllowed] NSObject[] pixelToWgs);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull kIATraceId __attribute__((visibility("default")));
        [Field("kIATraceId", "__Internal")]
        NSString kIATraceId { get; }
    }

    // @interface IARegion : NSObject
    [BaseType(typeof(NSObject))]
    interface IARegion
    {
        // @property (nonatomic, strong) NSString * _Nonnull identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (assign, nonatomic) enum ia_region_type type;
        [Export("type", ArgumentSemantic.Assign)]
        ia_region_type Type { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable timestamp;
        [NullAllowed, Export("timestamp", ArgumentSemantic.Strong)]
        NSDate Timestamp { get; set; }
    }

    // @interface IAGeofence : IARegion
    [BaseType(typeof(IARegion))]
    interface IAGeofence
    {
        // @property (assign, nonatomic) struct ia_bounding_box boundingBox;
        [Export("boundingBox", ArgumentSemantic.Assign)]
        ia_bounding_box BoundingBox { get; set; }

        // @property (nonatomic, strong) IAFloor * _Nullable floor;
        [NullAllowed, Export("floor", ArgumentSemantic.Strong)]
        IAFloor Floor { get; set; }

        // -(BOOL)containsCoordinate:(CLLocationCoordinate2D)coordinate;
        [Export("containsCoordinate:")]
        bool ContainsCoordinate(CLLocationCoordinate2D coordinate);
    }

    // @interface IAPolygonGeofence : IAGeofence
    [BaseType(typeof(IAGeofence))]
    interface IAPolygonGeofence
    {
        // @property (readonly, nonatomic, strong) NSArray<NSNumber *> * _Nonnull points;
        [Export("points", ArgumentSemantic.Strong)]
        NSNumber[] Points { get; }

        // +(IAPolygonGeofence * _Nonnull)polygonGeofenceWithIdentifier:(NSString * _Nonnull)identifier andFloor:(IAFloor * _Nullable)floor edges:(NSArray<NSNumber *> * _Nonnull)edges;
        [Static]
        [Export("polygonGeofenceWithIdentifier:andFloor:edges:")]
        IAPolygonGeofence PolygonGeofenceWithIdentifier(string identifier, [NullAllowed] IAFloor floor, NSNumber[] edges);
    }

    // @interface IAStatus : NSObject
    [BaseType(typeof(NSObject))]
    interface IAStatus
    {
        // @property (assign, nonatomic) enum ia_status_type type;
        [Export("type", ArgumentSemantic.Assign)]
        ia_status_type Type { get; set; }
    }

    // @interface IALocation : NSObject
    [BaseType(typeof(NSObject))]
    interface IALocation
    {
        // +(IALocation * _Nonnull)locationWithCLLocation:(CLLocation * _Nonnull)location;
        [Static]
        [Export("locationWithCLLocation:")]
        IALocation LocationWithCLLocation(CLLocation location);

        // +(IALocation * _Nonnull)locationWithFloorPlanId:(NSString * _Nonnull)floorPlanId;
        [Static]
        [Export("locationWithFloorPlanId:")]
        IALocation LocationWithFloorPlanId(string floorPlanId);

        // +(IALocation * _Nonnull)locationWithVenueId:(NSString * _Nonnull)venueId andFloor:(IAFloor * _Nullable)floor;
        [Static]
        [Export("locationWithVenueId:andFloor:")]
        IALocation LocationWithVenueId(string venueId, [NullAllowed] IAFloor floor);

        // @property (readonly, nonatomic) CLLocation * _Nullable location;
        [NullAllowed, Export("location")]
        CLLocation Location { get; }

        // @property (readwrite, nonatomic) IAFloor * _Nullable floor;
        [NullAllowed, Export("floor", ArgumentSemantic.Assign)]
        IAFloor Floor { get; set; }

        // @property (readwrite, nonatomic) IARegion * _Nullable region;
        [NullAllowed, Export("region", ArgumentSemantic.Assign)]
        IARegion Region { get; set; }
    }

    // @interface IAHeading : NSObject
    [BaseType(typeof(NSObject))]
    interface IAHeading
    {
        // @property (readonly, nonatomic) CLLocationDirection trueHeading;
        [Export("trueHeading")]
        double TrueHeading { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nullable timestamp;
        [NullAllowed, Export("timestamp", ArgumentSemantic.Copy)]
        NSDate Timestamp { get; }
    }

    // @interface IAAttitude : NSObject
    [BaseType(typeof(NSObject))]
    interface IAAttitude
    {
        // @property (readonly, nonatomic) CMQuaternion quaternion;
        [Export("quaternion")]
        CMQuaternion Quaternion { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nullable timestamp;
        [NullAllowed, Export("timestamp", ArgumentSemantic.Copy)]
        NSDate Timestamp { get; }
    }

    // @protocol IALocationManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IALocationManagerDelegate
    {
        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didUpdateLocations:(NSArray * _Nonnull)locations;
        [Export("indoorLocationManager:didUpdateLocations:")]
        void DidUpdateLocations(IALocationManager manager, IALocation[] locations);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didEnterRegion:(IARegion * _Nonnull)region;
        [Export("indoorLocationManager:didEnterRegion:")]
        void DidEnterRegion(IALocationManager manager, IARegion region);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didExitRegion:(IARegion * _Nonnull)region;
        [Export("indoorLocationManager:didExitRegion:")]
        void DidExitRegion(IALocationManager manager, IARegion region);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager statusChanged:(IAStatus * _Nonnull)status;
        [Export("indoorLocationManager:statusChanged:")]
        void StatusChanged(IALocationManager manager, IAStatus status);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager calibrationQualityChanged:(enum ia_calibration)quality;
        [Export("indoorLocationManager:calibrationQualityChanged:")]
        void CalibrationQualityChanged(IALocationManager manager, ia_calibration quality);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didReceiveExtraInfo:(NSDictionary * _Nonnull)extraInfo;
        [Export("indoorLocationManager:didReceiveExtraInfo:")]
        void DidReceiveExtraInfo(IALocationManager manager, NSDictionary extraInfo);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didUpdateHeading:(IAHeading * _Nonnull)newHeading;
        [Export("indoorLocationManager:didUpdateHeading:")]
        void DidUpdateHeading(IALocationManager manager, IAHeading newHeading);

        // @optional -(void)indoorLocationManager:(IALocationManager * _Nonnull)manager didUpdateAttitude:(IAAttitude * _Nonnull)newAttitude;
        [Export("indoorLocationManager:didUpdateAttitude:")]
        void DidUpdateAttitude(IALocationManager manager, IAAttitude newAttitude);
    }

    // @interface IALocationManager : NSObject
    [BaseType(typeof(NSObject))]
    interface IALocationManager
    {
        // @property (readonly, nonatomic) enum ia_calibration calibration;
        [Export("calibration")]
        ia_calibration Calibration { get; }

        // @property (readwrite, nonatomic) IALocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Assign)]
        IALocation Location { get; set; }

        // @property (readwrite, nonatomic) IAAttitude * _Nullable attitude;
        [NullAllowed, Export("attitude", ArgumentSemantic.Assign)]
        IAAttitude Attitude { get; set; }

        // @property (readwrite, nonatomic) IAHeading * _Nullable heading;
        [NullAllowed, Export("heading", ArgumentSemantic.Assign)]
        IAHeading Heading { get; set; }

        // @property (assign, nonatomic) CLLocationDistance distanceFilter;
        [Export("distanceFilter")]
        double DistanceFilter { get; set; }

        // @property (assign, nonatomic) CLLocationDegrees headingFilter;
        [Export("headingFilter")]
        double HeadingFilter { get; set; }

        // @property (assign, nonatomic) CLLocationDegrees attitudeFilter;
        [Export("attitudeFilter")]
        double AttitudeFilter { get; set; }

        // @property (assign, nonatomic) enum ia_location_accuracy desiredAccuracy;
        [Export("desiredAccuracy", ArgumentSemantic.Assign)]
        ia_location_accuracy DesiredAccuracy { get; set; }

        // @property (readonly, nonatomic, strong) NSArray<IAGeofence *> * _Nullable monitoredGeofences;
        [NullAllowed, Export("monitoredGeofences", ArgumentSemantic.Strong)]
        IAGeofence[] MonitoredGeofences { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nullable extraInfo;
        [NullAllowed, Export("extraInfo")]
        NSDictionary ExtraInfo { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        IALocationManagerDelegate Delegate { get; set; }

        // @property (readwrite, nonatomic, weak) id<IALocationManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(NSString * _Nonnull)versionString;
        [Static]
        [Export("versionString")]
        string VersionString { get; }

        // +(IALocationManager * _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        IALocationManager SharedInstance { get; }

        // -(void)setApiKey:(NSString * _Nonnull)key andSecret:(NSString * _Nonnull)secret;
        [Export("setApiKey:andSecret:")]
        void SetApiKey(string key, string secret);

        // -(void)startUpdatingLocation;
        [Export("startUpdatingLocation")]
        void StartUpdatingLocation();

        // -(void)stopUpdatingLocation;
        [Export("stopUpdatingLocation")]
        void StopUpdatingLocation();

        // -(void)startMonitoringForGeofence:(IAGeofence * _Nonnull)geofence;
        [Export("startMonitoringForGeofence:")]
        void StartMonitoringForGeofence(IAGeofence geofence);

        // -(void)stopMonitoringForGeofence:(IAGeofence * _Nonnull)geofence;
        [Export("stopMonitoringForGeofence:")]
        void StopMonitoringForGeofence(IAGeofence geofence);
    }

    // @protocol IAFetchTask <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IAFetchTask
    {
        // @required -(void)cancel;
        [Abstract]
        [Export("cancel")]
        void Cancel();
    }

    // @interface IAResourceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface IAResourceManager
    {
        // @property (readonly, nonatomic) IALocationManager * _Nullable locationManager;
        [NullAllowed, Export("locationManager")]
        IALocationManager LocationManager { get; }

        // +(IAResourceManager * _Nullable)resourceManagerWithLocationManager:(IALocationManager * _Nullable)locationManager;
        [Static]
        [Export("resourceManagerWithLocationManager:")]
        [return: NullAllowed]
        IAResourceManager ResourceManagerWithLocationManager([NullAllowed] IALocationManager locationManager);

        // -(id<IAFetchTask> _Nullable)fetchFloorPlanWithId:(NSString * _Nullable)floorPlanId andCompletion:(void (^ _Nullable)(IAFloorPlan * _Nullable, NSError * _Nullable))completionBlock;
        [Export("fetchFloorPlanWithId:andCompletion:")]
        [return: NullAllowed]
        IAFetchTask FetchFloorPlanWithId([NullAllowed] string floorPlanId, [NullAllowed] Action<IAFloorPlan, NSError> completionBlock);

        // -(id<IAFetchTask> _Nullable)fetchFloorPlanImageWithId:(NSString * _Nullable)floorPlanId andCompletion:(void (^ _Nullable)(NSData * _Nullable, NSError * _Nullable))completionBlock __attribute__((deprecated("Use fetchFloorPlanImageWithUrl instead")));
        [Export("fetchFloorPlanImageWithId:andCompletion:")]
        [return: NullAllowed]
        IAFetchTask FetchFloorPlanImageWithId([NullAllowed] string floorPlanId, [NullAllowed] Action<NSData, NSError> completionBlock);

        // -(id<IAFetchTask> _Nullable)fetchFloorPlanImageWithUrl:(NSURL * _Nonnull)floorPlanUrl andCompletion:(void (^ _Nullable)(NSData * _Nullable, NSError * _Nullable))completionBlock;
        [Export("fetchFloorPlanImageWithUrl:andCompletion:")]
        [return: NullAllowed]
        IAFetchTask FetchFloorPlanImageWithUrl(NSUrl floorPlanUrl, [NullAllowed] Action<NSData, NSError> completionBlock);
    }
}
