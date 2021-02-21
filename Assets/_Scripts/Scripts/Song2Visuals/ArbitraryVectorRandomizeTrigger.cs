using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reaktion;

public class ArbitraryVectorRandomizeTrigger : MonoBehaviour
{
    public TransformGear[] transGears;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeGearVector()
    {
        foreach (TransformGear gear in transGears)
        {
            float ogMagnitude = gear.position.arbitraryVector.magnitude;
            //Debug.Log("OG Magnitude was: " + ogMagnitude);
            Vector3 randomizedVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * ogMagnitude;
            //Debug.Log("Randomized Vector was: " + randomizedVector);
            gear.position.arbitraryVector = randomizedVector;
        }
    }
}
