using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRoadWidth : MonoBehaviour
{
    public new Camera camera;
    public SpriteRenderer road;

    [NaughtyAttributes.Button()]
    public void MatchWidth()
    {
        float roadWidht = road.bounds.size.x;
        float aspect = camera.aspect;
        float camNewHeight = roadWidht / aspect * 0.5f;
        camera.orthographicSize = camNewHeight;
    }

    void Start()
    {
        MatchWidth();
    }
}
