using UnityEngine;
public static class VectorEx 
{
    public static Vector3 WithAxis(this Vector3 vec, Axis axis, float value)
    {
        return new Vector3(axis == Axis.X ? value : vec.x,
            axis == Axis.Y ? value : vec.y, 
            axis == Axis.Z ? value : vec.z);
    }
}

public enum Axis
{
    X,Y,Z
}