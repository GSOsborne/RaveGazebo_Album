using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class WallTriggerBurst : MonoBehaviour
{
    ParticleSystem pSys;
    public MusicLayer wallLayer;
    // Start is called before the first frame update
    void Start()
    {
        pSys = GetComponent<ParticleSystem>();

        DavisDnB_AudioManager.WallTriggerEvent += BurstSystem;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= BurstSystem;
    }

    void BurstSystem(MusicLayer givenLayer)
    {
        if (givenLayer == wallLayer)
        {
            pSys.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
