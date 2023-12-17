using MK8DX.Components.Helper;

namespace MK8DX.Components;

public class Glider : IMK8DXObject
{
    public string Label { get; set; }
    public ComponentProperty Properties { get; set; }

    public Glider()
    {
        Properties ??= new();
    }

    public static Glider[] GetGliders()
    {
        Glider[] gliders = GetGliders(MK8DXConstants.GLIDERS_WORKSHEET_INDEX);
        return gliders;
    }

    private static Glider[] GetGliders(int worksheetIndex)
    {
        Glider[] gliders = ExcelHelper.GetMK8DXObjectInfo<Glider>(MK8DXConstants.MK8DXStatsDataPath, worksheetIndex, false);
        return gliders;
    }

    public override string ToString()
    {
        string result = $"{Label}";
        return result;
    }
}
