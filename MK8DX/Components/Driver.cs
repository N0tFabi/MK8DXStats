using Spire.Xls;
using MK8DX.Components.Helper;
using MK8DX.Components.Helper;

namespace MK8DX.Components;

public class Driver : IMK8DXObject
{
    public string Label { get; set; }
    public ComponentProperty Properties { get; set; }

    public Driver()
    {
        Properties ??= new();
    }

    public static Driver[] GetDrivers()
    {
        Driver[] drivers = GetDrivers(MK8DXConstants.DRIVERS_WORKSHEET_INDEX);
        return drivers;
    }

    private static Driver[] GetDrivers(int worksheetIndex)
    {
        Driver[] drivers = ExcelHelper.GetMK8DXObjectInfo<Driver>(MK8DXConstants.MK8DXStatsDataPath, worksheetIndex, false);
        return drivers;
    }

    public override string ToString()
    {
        string result = $"{Label}";
        return result;
    }
}
