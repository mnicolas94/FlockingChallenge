using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public Camera camera;
    
    public Collider2D guidePrefab;
    public int initGuides;
    public float guidesIncrementCooldown;

    public Flock2D flock;
    
    private int _guidesLeft;
    private float _lasTimeSpawned;

    private Collider2D _currentSpawning;
    private Vector3 _lastClickDown;

    private void Update()
    {
        // TODO implementar
        Vector3 pointer = camera.ScreenToWorldPoint(Input.mousePosition);
        pointer.z = transform.position.z;
        if (Input.GetMouseButtonDown(0))
        {
            // instanciar
            _currentSpawning = Instantiate(guidePrefab, pointer, Quaternion.identity, transform);
            _currentSpawning.enabled = false;  // para que no se tenga en cuenta aún por las reglas del flock
            _lastClickDown = pointer;
            
        } else if (Input.GetMouseButton(0))
        {
            if (_currentSpawning)
            {
                // girar guía q estoy instanciando
                _currentSpawning.transform.LookAt2D(pointer);
                if (Input.GetKeyDown(KeyCode.Escape))  // abortar instanciamiento
                {
                    Destroy(_currentSpawning.gameObject);
                    _currentSpawning = null;
                }
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            // ponerle la dirección final
            _currentSpawning.transform.LookAt2D(pointer);
            _currentSpawning.enabled = true;  // para que se tenga en cuenta por las reglas del flock
            _currentSpawning = null;  // quitarlo de referencia
        }
    }
    
}
