using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    public static FadeController Instance;
    public float fadeOutTime, fadeBackInTime;

    Image image;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("You have too many fade controllers!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeOut()
    {
        Debug.Log("Fading to black.");
        StopAllCoroutines();
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        float remainingTime = fadeOutTime;
        while (remainingTime > 0f)
        {
            image.color = new Color (0,0,0, (1-remainingTime)/fadeOutTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        image.color = new Color(0, 0, 0, 1);

    }

    public void StartFadeIn()
    {
        Debug.Log("Fading back in.");
        StopAllCoroutines();
        StartCoroutine(FadeBackIn());
    }

    IEnumerator FadeBackIn()
    {
        float remainingTime = fadeBackInTime;
        while (remainingTime > 0f)
        {
            image.color = new Color(0, 0, 0, remainingTime/fadeBackInTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        image.color = new Color(0, 0, 0, 0);
    }
}
