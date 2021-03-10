using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class RotateSpeedWithCharge : MonoBehaviour
{
    RotateSlowly rotateSlowly;
    public float minSpeed, maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSlowly = GetComponent<RotateSlowly>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateSlowly.rotateSpeed = (DavisDnB_AudioManager.Instance.chargeLevel / 100) * (maxSpeed - minSpeed) + minSpeed;
    }
}
