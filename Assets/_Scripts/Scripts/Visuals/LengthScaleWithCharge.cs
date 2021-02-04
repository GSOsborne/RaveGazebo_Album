using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthScaleWithCharge : MonoBehaviour
{
    public float minScale, maxScale, minNoise, maxNoise;
    ParticleSystemRenderer pSysRend;
    ParticleSystem pSys;

    // Start is called before the first frame update
    void Start()
    {
        pSysRend = GetComponent<ParticleSystemRenderer>();
        pSysRend.lengthScale = minScale;
        pSys = GetComponent<ParticleSystem>();
        var noise = pSys.noise;
        noise.strengthMultiplier = minNoise;
    }


    // Update is called once per frame
    void Update()
    {
        pSysRend.lengthScale = DavisDnB_AudioManager.Instance.chargeLevel / 100 * (maxScale - minScale) + minScale;
        var noise = pSys.noise;
        noise.strengthMultiplier = DavisDnB_AudioManager.Instance.chargeLevel / 100 * (maxNoise - minNoise) + minNoise;
        //Debug.Log(emission.rateOverTimeMultiplier);
    }
}
