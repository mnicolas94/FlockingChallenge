using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ScoreManager : MonoBehaviour
{
    public Flock2D citizensFlock;
    public Refuge refuge;
    public PlayableDirector winTimeline;
    public GameObject loseMenu;

    private int _citizensRefuged;
    private int _citizensCount;
    
    // Start is called before the first frame update
    void Start()
    {
        citizensFlock.eventBoidAdded += OnCitizenAdded;

        refuge.eventRefugeeArrived += OnRefugeeArrived;
    }

    private void OnCitizenAdded(Boid2D boid)
    {
        _citizensCount++;
        boid.GetComponent<Health>().eventDied.AddListener(OnCitizenDied);
    }

    private void OnRefugeeArrived(Boid2D obj)
    {
        _citizensRefuged++;
        if (_citizensRefuged == _citizensCount)
        {
            winTimeline.Play();
        }
    }

    private void OnCitizenDied()
    {
        _citizensCount--;
        if (_citizensCount == 0)
        {
            Time.timeScale = 0;  // poner pause
            loseMenu.SetActive(true);
        }
    }

    
}
