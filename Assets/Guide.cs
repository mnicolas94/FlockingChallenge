using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public FixedDirRule2D guideRule;

    public void SetDir(Vector2 dir)
    {
        guideRule.dir = dir;
    }
}
