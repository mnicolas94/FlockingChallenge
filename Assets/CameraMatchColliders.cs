using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatchColliders : MonoBehaviour
{
    public new Camera camera;

    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        AdjustColliders();
    }

    [NaughtyAttributes.Button()]
    public void AdjustColliders()
    {
        float aspect = camera.aspect;
        float height = camera.orthographicSize;
        float width = height * aspect;

        var leftOffset = leftCollider.offset;
        leftOffset.x = -width - leftCollider.size.x * 0.5f;
        leftCollider.offset = leftOffset;
        
        var rightOffset = rightCollider.offset;
        rightOffset.x = width + rightCollider.size.x * 0.5f;
        rightCollider.offset = rightOffset;
    }
    
}
