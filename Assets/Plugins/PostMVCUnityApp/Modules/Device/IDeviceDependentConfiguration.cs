namespace Build1.PostMVC.Unity.App.Modules.Device
{
    public interface IDeviceDependentConfiguration
    {
        DevicePlatform DevicePlatform { get; }
        DeviceType     DeviceType     { get; }
    }
}