using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public RunnerCourier runner;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        runner.Move(h);
    }
}
