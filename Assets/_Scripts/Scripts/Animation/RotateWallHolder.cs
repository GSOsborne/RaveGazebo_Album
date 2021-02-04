using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class RotateWallHolder : MonoBehaviour
{
    Animator animator;
    public PlaybackSpeed movingPlaybackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("MovingPlaybackSpeed", false);
        DavisDnB_AudioManager.PlaybackSpeedChange += CheckToStartMoving;
        DavisDnB_AudioManager.StopAllMusic += StopTheRotation;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.PlaybackSpeedChange -= CheckToStartMoving;
        DavisDnB_AudioManager.StopAllMusic -= StopTheRotation;
    }

    void CheckToStartMoving(PlaybackSpeed givenSpeed)
    {
        if (givenSpeed == movingPlaybackSpeed)
        {
            animator.SetBool("MovingPlaybackSpeed", true);
        }
        else
        {
            animator.SetBool("MovingPlaybackSpeed", false);
        }
    }

    void StopTheRotation()
    {
        animator.SetBool("MovingPlaybackSpeed", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
