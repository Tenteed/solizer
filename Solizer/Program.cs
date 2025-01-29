using System.Management;

const string DeviceProperty = "Caption";

List<string> GetAllDevices()
{
    var devices =  new List<string>();

    using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

    foreach (var device in searcher.Get())
    {
        if (device[DeviceProperty] is not null)
        {
            devices.Add(device[DeviceProperty].ToString());
        }    
    }

    searcher.Dispose();
    return devices;
}

var devices = GetAllDevices();
devices.ForEach(x => Console.WriteLine(x));