using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject content;

    private bool _paused;
    
    private void Awake()
    {
        content.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        content.SetActive(true);
        _paused = true;
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        content.SetActive(false);
        _paused = false;
    }
}
