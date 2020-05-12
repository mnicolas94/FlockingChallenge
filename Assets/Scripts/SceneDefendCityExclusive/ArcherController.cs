using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public new Camera camera;
    public Archer archer;
    
    void Update()
    {
        var pointer = camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            var dir = pointer - archer.transform.position;
            archer.Attack(dir);
        }
    }
}
