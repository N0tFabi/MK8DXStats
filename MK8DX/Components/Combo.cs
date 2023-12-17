using MK8DX.Components.Optimizing;

namespace MK8DX.Components;

public class Combo
{
    public Driver Driver { get; set; }
    public Vehicle Vehicle { get; set; }
    public Tire Tire { get; set; }
    public Glider Glider { get; set; }

    public Combo(Driver driver, Vehicle vehicle, Tire tire, Glider glider)
    {
        Driver = driver;
        Vehicle = vehicle;
        Tire = tire;
        Glider = glider;
    }

    public Combo()
        :this(new Driver(), new Vehicle(), new Tire(), new Glider())
    { }

    public int MiniTurbo
    {
        get
        {
            int result = Driver.Properties.MiniTurbo + Vehicle.Properties.MiniTurbo 
                       + Tire.Properties.MiniTurbo + Glider.Properties.MiniTurbo;
            return result;
        }
    }

    public int GroundSpeed
    {
        get
        {
            int result = Driver.Properties.TopSpeed.Ground + Vehicle.Properties.TopSpeed.Ground 
                       + Tire.Properties.TopSpeed.Ground + Glider.Properties.TopSpeed.Ground;
            return result;
        }
    }

    public int WaterSpeed
    {
        get
        {
            int result = Driver.Properties.TopSpeed.Water + Vehicle.Properties.TopSpeed.Water 
                       + Tire.Properties.TopSpeed.Water + Glider.Properties.TopSpeed.Water;
            return result;
        }
    }

    public int GliderSpeed
    {
        get
        {
            int result = Driver.Properties.TopSpeed.Glider + Vehicle.Properties.TopSpeed.Glider 
                       + Tire.Properties.TopSpeed.Glider + Glider.Properties.TopSpeed.Glider;
            return result;
        }
    }

    public int AntiGravitySpeed
    {
        get
        {
            int result = Driver.Properties.TopSpeed.AntiGravity + Vehicle.Properties.TopSpeed.AntiGravity 
                       + Tire.Properties.TopSpeed.AntiGravity + Glider.Properties.TopSpeed.AntiGravity;
            return result;
        }
    }

    public int Acceleration
    {
        get
        {
            int result = Driver.Properties.Accel + Vehicle.Properties.Accel 
                       + Tire.Properties.Accel + Glider.Properties.Accel;
            return result;
        }
    }

    public int Weight
    {
        get
        {
            int result = Driver.Properties.Weight + Vehicle.Properties.Weight 
                       + Tire.Properties.Weight + Glider.Properties.Weight;
            return result;
        }
    }

    public int GroundHandling
    {
        get
        {
            int result = Driver.Properties.Handling.Ground + Vehicle.Properties.Handling.Ground 
                       + Tire.Properties.Handling.Ground + Glider.Properties.Handling.Ground;
            return result;
        }
    }

    public int WaterHandling
    {
        get
        {
            int result = Driver.Properties.Handling.Water + Vehicle.Properties.Handling.Water 
                       + Tire.Properties.Handling.Water + Glider.Properties.Handling.Water;
            return result;
        }
    }

    public int GliderHandling
    {
        get
        {
            int result = Driver.Properties.Handling.Glider + Vehicle.Properties.Handling.Glider 
                       + Tire.Properties.Handling.Glider + Glider.Properties.Handling.Glider;
            return result;
        }
    }

    public int AntiGravityHandling
    {
        get
        {
            int result = Driver.Properties.Handling.AntiGravity + Vehicle.Properties.Handling.AntiGravity 
                       + Tire.Properties.Handling.AntiGravity + Glider.Properties.Handling.AntiGravity;
            return result;
        }
    }

    public int Traction
    {
        get
        {
            int result = Driver.Properties.Traction + Vehicle.Properties.Traction 
                       + Tire.Properties.Traction + Glider.Properties.Traction;
            return result;
        }
    }

    public int Invincibility
    {
        get
        {
            int result = Driver.Properties.Invincibility + Vehicle.Properties.Invincibility 
                       + Tire.Properties.Invincibility + Glider.Properties.Invincibility;
            return result;
        }
    }
}
