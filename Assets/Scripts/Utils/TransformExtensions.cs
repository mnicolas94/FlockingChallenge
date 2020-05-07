using UnityEngine;

public static class TransformExtensions
{
    public static void LookAt2D(this Transform transform, Vector3 target)
    {
        Vector3 pos = transform.position;
        target.z = pos.z;
        transform.LookAt(pos + Vector3.forward, target - pos);
    }
}