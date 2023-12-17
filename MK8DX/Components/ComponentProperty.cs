namespace MK8DX.Components;

public class TopSpeed
{
    public int Ground { get; set; }
    public int Water { get; set; }
    public int Glider { get; set; }
    public int AntiGravity { get; set; }
}

public class Handling
{
    public int Ground { get; set; }
    public int Water { get; set; }
    public int Glider { get; set; }
    public int AntiGravity { get; set; }
}

public class ComponentProperty
{
    public static ComponentProperty instance = new();

    public int MiniTurbo { get; set; }
    public TopSpeed TopSpeed { get; set; }
    public int Accel { get; set; }
    public int Weight { get; set; }
    public Handling Handling { get; set; }
    public int Traction { get; set; }
    public int Invincibility { get; set; }

    public ComponentProperty()
    {
        this.TopSpeed = new();
        this.Handling = new();
    }

    public override string ToString()
    {
        string result = $"Mini-Turbo: {MiniTurbo}, Acceleration: {Accel}, Ground Speed: {TopSpeed.Ground}";
        return result;
    }
}

public enum EComponentType
{
    Driver,
    Vehicle,
    Tire,
    Glider
}

public enum EComponentProperty
{
    MiniTurbo,
    GroundSpeed,
    WaterSpeed,
    GliderSpeed,
    AntiGravitySpeed,
    Accel,
    Weight,
    GroundHandling,
    WaterHandling,
    GliderHandling,
    AntiGravityHandling,
    Traction,
    Invincibility,

    STier, // This is a special property that is used to determine the tier of a combo
    ATier, // This is a special property that is used to determine the tier of a combo
    BTier  // This is a special property that is used to determine the tier of a combo
}