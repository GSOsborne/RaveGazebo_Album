using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseAndSizeWithCharge : MonoBehaviour
{
    public float minNoise, maxNoise, minSize, maxSize;
    ParticleSystem pSys;

    // Start is called before the first frame update
    void Start()
    {
        pSys = GetComponent<ParticleSystem>();
        var noise = pSys.noise;
        noise.strength = minNoise;
        var main = pSys.main;
        main.startSizeMultiplier = minSize;
    }

    // Update is called once per frame
    void Update()
    {
        var noise = pSys.noise;
        noise.strength = DavisDnB_AudioManager.Instance.chargeLevel / 100 * (maxNoise - minNoise) + minNoise;
        var main = pSys.main;
        main.startSizeMultiplier = DavisDnB_AudioManager.Instance.chargeLevel / 100 * (maxSize - minSize) + minSize;
    }
}
