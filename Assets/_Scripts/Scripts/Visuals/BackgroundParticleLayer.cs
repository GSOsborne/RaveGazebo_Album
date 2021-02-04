using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class BackgroundParticleLayer : MonoBehaviour
{
    public MusicLayer whichLayer;
    public EmissionWithCharge[] backgroundParticleObjects;
    // Start is called before the first frame update
    void Start()
    {
        DavisDnB_AudioManager.WallTriggerEvent += BackgroundParticleManaging;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= BackgroundParticleManaging;
    }

    void BackgroundParticleManaging(MusicLayer givenLayer)
    {
        if (givenLayer == whichLayer)
        {
            foreach (EmissionWithCharge emissionScript in backgroundParticleObjects)
            {
                emissionScript.CorrectColor();
            }
        }
        else
        {
            foreach (EmissionWithCharge emissionScript in backgroundParticleObjects)
            {
                emissionScript.StopOnWrongColor();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
