using Spire.Xls;

namespace MK8DX.Components.Helper;

internal static class ExcelHelper
{
    public static string[] GetLabels(Worksheet worksheet, int rowIndex)
    {
        string[] labels = worksheet.Rows[rowIndex].Columns[0].Value.Split("\n");
        return labels;
    }

    public static ComponentProperty GetProperty(Worksheet worksheet, int rowIndex, int invinibilityIndex_base0)
    {
        ComponentProperty property = new();
        var columns = worksheet.Rows[rowIndex].Columns;
        property.MiniTurbo = columns[1].Value.ToInt32();
        property.TopSpeed.Ground = columns[2].Value.ToInt32();
        property.TopSpeed.Water = columns[3].Value.ToInt32();
        property.TopSpeed.Glider = columns[4].Value.ToInt32();
        property.TopSpeed.AntiGravity = columns[5].Value.ToInt32();
        property.Accel = columns[6].Value.ToInt32();
        property.Weight = columns[7].Value.ToInt32();
        property.Handling.Ground = columns[8].Value.ToInt32();
        property.Handling.Water = columns[9].Value.ToInt32();
        property.Handling.Glider = columns[10].Value.ToInt32();
        property.Handling.AntiGravity = columns[11].Value.ToInt32();
        property.Traction = columns[12].Value.ToInt32();
        property.Invincibility = columns[13 + invinibilityIndex_base0].Value.ToInt32();
        return property;
    }

    public static T[] GetMK8DXObjectInfo<T>(string filePath, int worksheetIndex, bool hasMultipleInvincibilityStats)
        where T : IMK8DXObject, new()
    {
        Workbook workbook = new();
        workbook.LoadFromFile(filePath);

        Worksheet worksheet = workbook.Worksheets[worksheetIndex];

        List<T> objects = new();

        for (int i = 2; i < worksheet.Rows.Count(); i++)
        {
            string[] labels = worksheet.Rows[i].Columns[0].Value.Split("\n");
            labels = labels.Select(str => str.Replace("\r", String.Empty)).ToArray();

            for (int j = 0; j < labels.Length; j++)
            {
                T obj = new();
                obj.Label = labels[j];
                obj.Properties = ExcelHelper.GetProperty(worksheet, i, hasMultipleInvincibilityStats ? j : 0);
                objects.Add(obj);
            }
        }

        return objects.ToArray();
    }
}
