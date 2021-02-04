using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class MaterialChangeWithSpeed : MonoBehaviour
{

    public Material slowMat, medMat, fastMat;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DavisDnB_AudioManager.PlaybackSpeedChange += ChangeMaterialWithSpeed;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= ChangeMaterialWithSpeed;
    }

    void ChangeMaterialWithSpeed(PlaybackSpeed givenSpeed)
    {
        switch (givenSpeed)
        {
            case PlaybackSpeed.Slow:
                rend.material = slowMat;
                break;
            case PlaybackSpeed.Medium:
                rend.material = medMat;
                break;
            case PlaybackSpeed.Fast:
                rend.material = fastMat;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
