using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpoint : MonoBehaviour
{
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 up => transform.up;
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 down => -transform.up;
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 forward => transform.forward;
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 back => -transform.forward;
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 right => transform.right;
    [NaughtyAttributes.ShowNativeProperty]
    public Vector3 left => -transform.right;
}
