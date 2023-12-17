using MK8DX.Components.Helper;
using Spire.Xls;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MK8DX.Components.Optimizing;

public class Optimizer : IMK8DXObject
{
    public string Label { get; set; }
    public ComponentProperty Properties { get; set; }

    public static T[] Optimize<T>(T[] collection, EComponentProperty optimizingFor) where T : IMK8DXObject, new()
    {
        for (int i = 0; i < collection.Length; i++)
        {
            for (int j = i; j < collection.Length; j++)
            {
                if ((int)GetProperty(collection[i], optimizingFor) < (int)GetProperty(collection[j], optimizingFor))
                {
                    T tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;
                }
            }
        }

        return collection;
    }

    public static T[] OptimizeDepth<T>(T[] collection, EComponentProperty[] optimizingRoute) where T : IMK8DXObject, new()
    {
        if (optimizingRoute.Length <= 0 || collection.Length <= 1)
            return collection;

        Array.Sort(collection, (x, y) =>
        {
            int result = 0;
            foreach (var route in optimizingRoute)
            {
                result = Comparer<int>.Default.Compare((int)GetProperty(x, route), (int)GetProperty(y, route));
                if (result != 0)
                    break;
            }
            return result;
        });

        return collection.Reverse().ToArray();
    }

    public static Combo[] OptimizeCombo_full(EComponentProperty[] optimizingRoute)
    {
        Driver[] drivers = Driver.GetDrivers().ToArray();
        Vehicle[] vehicles = Vehicle.GetVehicles().ToArray();
        Tire[] tires = Tire.GetTires().ToArray();
        Glider[] gliders = Glider.GetGliders().ToArray();

        drivers = OptimizeDepth(drivers, optimizingRoute);
        vehicles = OptimizeDepth(vehicles, optimizingRoute);
        tires = OptimizeDepth(tires, optimizingRoute);
        gliders = OptimizeDepth(gliders, optimizingRoute);

        Combo[] combos = new Combo[drivers.Length * vehicles.Length * tires.Length * gliders.Length];

        int index = 0;
        foreach (Driver driver in drivers)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                foreach (Tire tire in tires)
                {
                    foreach (Glider glider in gliders)
                    {
                        combos[index] = new Combo(driver, vehicle, tire, glider);
                        index++;
                    }
                }
            }
        }

        return combos;
    }
    
    public static Combo OptimizeCombo(EComponentProperty[] optimizingRoute)
    {
        Driver[] drivers = Driver.GetDrivers().ToArray();
        Vehicle[] vehicles = Vehicle.GetVehicles().ToArray();
        Tire[] tires = Tire.GetTires().ToArray();
        Glider[] gliders = Glider.GetGliders().ToArray();

        drivers = OptimizeDepth(drivers, optimizingRoute);
        vehicles = OptimizeDepth(vehicles, optimizingRoute);
        tires = OptimizeDepth(tires, optimizingRoute);
        gliders = OptimizeDepth(gliders, optimizingRoute);

        Combo combo = new();

        combo.Driver = drivers[0];
        combo.Vehicle = vehicles[0];
        combo.Tire = tires[0];
        combo.Glider = gliders[0];

        return combo;
    }


    private static T[] BubbleSort<T>(T[] collection, EComponentProperty optimizingFor) where T : IMK8DXObject, new()
    {
        for (int i = 0; i < collection.Length; i++)
        {
            for (int j = i; j < collection.Length; j++)
            {
                if ((int)GetProperty(collection[i], optimizingFor) < (int)GetProperty(collection[j], optimizingFor))
                {
                    T tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;
                }
            }
        }

        return collection;
    }

    private static object GetProperty<T>(T obj, EComponentProperty property) where T : IMK8DXObject, new()
    {
        var p = obj.Properties;

        return property switch
        {
            EComponentProperty.MiniTurbo => p.MiniTurbo,
            EComponentProperty.GroundSpeed => p.TopSpeed.Ground,
            EComponentProperty.WaterSpeed => p.TopSpeed.Water,
            EComponentProperty.GliderSpeed => p.TopSpeed.Glider,
            EComponentProperty.AntiGravitySpeed => p.TopSpeed.AntiGravity,
            EComponentProperty.Accel => p.Accel,
            EComponentProperty.Weight => p.Weight,
            EComponentProperty.GroundHandling => p.Handling.Ground,
            EComponentProperty.WaterHandling => p.Handling.Water,
            EComponentProperty.GliderHandling => p.Handling.Glider,
            EComponentProperty.AntiGravityHandling => p.Handling.AntiGravity,
            EComponentProperty.Traction => p.Traction,
            EComponentProperty.Invincibility => p.Invincibility,
            EComponentProperty.STier => p.MiniTurbo + p.TopSpeed.Ground,
            EComponentProperty.ATier => p.Accel + p.TopSpeed.AntiGravity,
            EComponentProperty.BTier => p.Traction + p.Invincibility + p.TopSpeed.Glider + p.TopSpeed.Water
                + p.Handling.Water + p.Handling.Ground + p.Handling.Glider + p.Handling.AntiGravity + p.Weight,
            _ => throw new NotImplementedException()
        };
    }
} 