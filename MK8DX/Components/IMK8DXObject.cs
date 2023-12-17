namespace MK8DX.Components;

public interface IMK8DXObject
{
    string Label { get; set; }
    ComponentProperty Properties { get; set; }
}
