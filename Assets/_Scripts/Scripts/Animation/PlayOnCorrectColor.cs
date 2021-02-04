using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reaktion;
using static DavisDnB_AudioManager;

public class PlayOnCorrectColor : MonoBehaviour
{
    Spawner thisSpawner;
    public MusicLayer thisSpawnersMusicLayer;

    // Start is called before the first frame update
    void Start()
    {
        thisSpawner = GetComponent<Spawner>();
        thisSpawner.enabled = false;
        DavisDnB_AudioManager.WallTriggerEvent += CheckColor;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= CheckColor;
    }

    void CheckColor(MusicLayer givenLayer)
    {
        //Debug.Log("Checking color");
        if (givenLayer == thisSpawnersMusicLayer)
        {
            //Debug.Log("Oh yeah, " + givenLayer + " boutta spawn.");
            StartCoroutine(BurstSpawnForSomeSeconds());
        }
        else
        {
            StopAllCoroutines();
            thisSpawner.enabled = false;
        }
    }

    IEnumerator BurstSpawnForSomeSeconds()
    {
        //Debug.Log("Made it to the coroutine.");
        yield return new WaitForSeconds(.5f); // This is to prevent overload of spawners spawning and etc when you're just waving your hands wildly.
        thisSpawner.enabled = true;
        yield return new WaitForSeconds(.5f + DavisDnB_AudioManager.Instance.chargeLevel * .02f);
        //Debug.Log("Added additional " + DavisDnB_AudioManager.Instance.chargeLevel * .02f + " seconds cuz of charge.");
        thisSpawner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
