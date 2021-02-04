using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragMovement;
using static FadeController;
using UnityEngine.UI;

public class FadeOutWall : MonoBehaviour
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
        //Debug.Log("Something entered the trigger: " + other.name);
        if (other.tag == "Player")
        {
            Debug.Log("You're veering just a bit off course there friend.");
            FadeController.Instance.StartFadeOut();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Pushing you back to someplace safe!");
            DragMovement.Instance.WallForce(transform.up);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Welcome back to the land of the living.");
            FadeController.Instance.StartFadeIn();

        }
    }
}
