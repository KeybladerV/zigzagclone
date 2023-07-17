using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.Device
{
    public static class DeviceEvent
    {
        public static readonly Event<DeviceType>              DeviceTypeChanged        = new Event<DeviceType>(typeof(DeviceEvent), nameof(DeviceTypeChanged));
        public static readonly Event<DeviceOrientation>       DeviceOrientationChanged = new Event<DeviceOrientation>(typeof(DeviceEvent), nameof(DeviceOrientationChanged));
        public static readonly Event<DeviceScreenOrientation> ScreenOrientationChanged = new Event<DeviceScreenOrientation>(typeof(DeviceEvent), nameof(ScreenOrientationChanged));
    }
}