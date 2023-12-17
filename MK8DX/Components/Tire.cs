using MK8DX.Components.Helper;

namespace MK8DX.Components;

public class Tire : IMK8DXObject
{
    public string Label { get; set; }
    public ComponentProperty Properties { get; set; }

    public Tire()
    {
        Properties ??= new();
    }

    public static Tire[] GetTires()
    {
        Tire[] tires = GetTires(MK8DXConstants.TIRES_WORKSHEET_INDEX);
        return tires;
    }

    private static Tire[] GetTires(int worksheetIndex)
    {
        Tire[] tires = ExcelHelper.GetMK8DXObjectInfo<Tire>(MK8DXConstants.MK8DXStatsDataPath, worksheetIndex, true);
        return tires;
    }

    public override string ToString()
    {
        string result = $"{Label}";
        return result;
    }
}
