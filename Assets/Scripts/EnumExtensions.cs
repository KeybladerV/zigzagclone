using System;
using Components.Character;
using UnityEngine;

public static class EnumExtensions<T> where T : Enum
{
    public static T Random()
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
}

public static class EnumExtensions
{
    public static MovementDirection GetOpposite(this MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Left => MovementDirection.Right,
            MovementDirection.Right => MovementDirection.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    public static Vector3 GetVector3(this MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Left => Vector3.forward,
            MovementDirection.Right => Vector3.right,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}