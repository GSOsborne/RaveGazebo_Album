using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalMiscellanyShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger detected.");
        if (other.CompareTag("Miscellany"))
        {
            //Debug.Log("BOUTTA DESTROY A MISCELLANEOUS BITCH: " + other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
