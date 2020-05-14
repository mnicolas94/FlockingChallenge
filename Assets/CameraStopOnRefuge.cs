using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStopOnRefuge : MonoBehaviour
{
    public new FollowFlock camera;
    public Collider2D refuge;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == refuge)
        {
            camera.following = false;
        }
    }
}
