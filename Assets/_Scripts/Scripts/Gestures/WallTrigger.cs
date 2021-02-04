using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class WallTrigger : MonoBehaviour
{

    public MusicLayer layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WallTriggered()
    {
        if (DavisDnB_AudioManager.Instance.songPlaying)
        {
            DavisDnB_AudioManager.Instance.TriggerWallEvent(layer);
            Debug.Log("Wall sent " + layer + " trigger!");
        }
        else
        {
            Debug.Log("Wall sent nothing cus the song isn't playing.");
        }
    }
}
