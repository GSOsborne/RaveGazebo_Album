using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class BurstOnGesture : MonoBehaviour
{
    //public bool checkIfLH;
    ParticleSystem pStm;
    public Gradient redGradient, orangeGradient, yellowGradient, greenGradient, blueGradient, purpleGradient;

    public GestureTracking thisControllerGTrack, otherControllerGTrack;
    // Start is called before the first frame update
    void Start()
    {
        pStm = GetComponent<ParticleSystem>();
        DavisDnB_AudioManager.WallTriggerEvent += Burst;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= Burst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Burst(MusicLayer mLayer)
    {
        var pStmMain = pStm.main;
        if (thisControllerGTrack.currentVelocity.magnitude > otherControllerGTrack.currentVelocity.magnitude)
        {
            switch (mLayer)
            {
                case MusicLayer.Dholak:
                    pStmMain.startColor = redGradient;
                    break;
                case MusicLayer.Squeaker:
                    pStmMain.startColor = orangeGradient;
                    break;
                case MusicLayer.Charleston:
                    pStmMain.startColor = yellowGradient;
                    break;
                case MusicLayer.Sniper:
                    pStmMain.startColor = greenGradient;
                    break;
                case MusicLayer.OGProd:
                    pStmMain.startColor = blueGradient;
                    break;
                case MusicLayer.Funk:
                    pStmMain.startColor = purpleGradient;
                    break;
            }

            pStm.Play();
        }
    }
}
