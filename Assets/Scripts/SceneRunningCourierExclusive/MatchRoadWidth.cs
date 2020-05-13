using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRoadWidth : MonoBehaviour
{
    public new Camera camera;
    public SpriteRenderer road;
    
    void Start()
    {
//        MatchWidth();
        MatchBottomPos();
    }

    [NaughtyAttributes.Button()]
    public void MatchWidth()
    {
        float roadWidht = road.bounds.size.x;
        float aspect = camera.aspect;
        float camNewHeight = roadWidht / aspect * 0.5f;
        camera.orthographicSize = camNewHeight;
    }

    [NaughtyAttributes.Button()]
    public void MatchBottomPos()
    {
        Vector3 camPos = camera.transform.position;
        float halfHeight = camera.orthographicSize;
        float roadHalfHeight = road.bounds.extents.y;
        Vector2 roadPos = road.transform.position;
        camPos.y = roadPos.y - roadHalfHeight + halfHeight;
        camera.transform.position = camPos;
    }
}
