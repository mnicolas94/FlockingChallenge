using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete]
public class WavesControllerClone : MonoBehaviour
{
    public WavesController wc;

    public DictionaryFpFp flockPopulatorsSwap;
    
    public float timeOffset;

    private WavesController _clone;

    private void Awake()
    {
        Clone();
    }

    [NaughtyAttributes.Button()]
    public void Clone()
    {
        _clone = Instantiate(wc, transform);

        foreach (var wave in _clone.waves)
        {
            if (flockPopulatorsSwap.ContainsKey(wave.populator))
            {
                wave.populator = flockPopulatorsSwap[wave.populator];
                wave.seconds += timeOffset;
            }
        }
    }
}

[System.Serializable]
public class DictionaryFpFp : SerializableDictionaryBase<FlockPopulator2D, FlockPopulator2D>{}
