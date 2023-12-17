using Microsoft.VisualBasic;
using MK8DX.Components.Helper;

namespace MK8DX.Components;

public class Vehicle : IMK8DXObject
{
    public string Label { get; set; }
    public ComponentProperty Properties { get; set; }

    public Vehicle()
    {
        Properties ??= new();
    }

    public static Vehicle[] GetVehicles()
    {
        Vehicle[] vehicles = GetVehicles(MK8DXConstants.VEHICLES_WORKSHEET_INDEX);
        return vehicles;
    }

    private static Vehicle[] GetVehicles(int worksheetIndex)
    {
        Vehicle[] vehicles = ExcelHelper.GetMK8DXObjectInfo<Vehicle>(MK8DXConstants.MK8DXStatsDataPath, worksheetIndex, true);
        return vehicles;
    }

    public override string ToString()
    {
        string result = $"{Label}";
        return result;
    }
}
