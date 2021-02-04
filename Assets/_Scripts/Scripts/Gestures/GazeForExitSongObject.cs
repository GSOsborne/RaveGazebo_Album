using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeForExitSongObject : MonoBehaviour
{
    Animation slideAnim;
    bool slideUpActive;
    public float slideUpSpeed;
    public float relaxBackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        slideAnim = GetComponent<Animation>();
        Debug.Log(slideAnim);
        slideAnim.Play("ExitSphereSlider");
        slideAnim["ExitSphereSlider"].speed = 0;
        slideAnim["ExitSphereSlider"].normalizedTime = 0;
        slideUpActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (slideUpActive)
        {
            slideAnim["ExitSphereSlider"].normalizedTime = Mathf.Clamp(slideAnim["ExitSphereSlider"].normalizedTime + slideUpSpeed, 0, 1f);
        }
        else
        {
            slideAnim["ExitSphereSlider"].normalizedTime = Mathf.Clamp(slideAnim["ExitSphereSlider"].normalizedTime - relaxBackSpeed, 0, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Watch where you're going, " + other.name);
        if (other.tag == "Gaze")
        {
            slideUpActive = true;
            //Debug.Log("Sidling on over now!");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gaze")
        {
            slideUpActive = false;
            //Debug.Log("Bye!");
        }

    }
}
