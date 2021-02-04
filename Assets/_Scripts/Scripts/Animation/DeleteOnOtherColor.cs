using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class DeleteOnOtherColor : MonoBehaviour
{
    public float deleteSpeed;
    public MusicLayer thisObjectsMusicLayer;
    // Start is called before the first frame update
    void Start()
    {
        DavisDnB_AudioManager.WallTriggerEvent += CheckColor;
    }

    void CheckColor(MusicLayer givenLayer)
    {
        if (givenLayer != thisObjectsMusicLayer)
        {
            StartCoroutine(ShrinkTillDeath());
        }
    }

    IEnumerator ShrinkTillDeath()
    {
        Transform transform = GetComponent<Transform>();
        while (transform.localScale.x > .15)
        {
            transform.localScale = new Vector3(transform.localScale.x - deleteSpeed * Time.deltaTime, transform.localScale.y - deleteSpeed * Time.deltaTime, transform.localScale.z - deleteSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= CheckColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
