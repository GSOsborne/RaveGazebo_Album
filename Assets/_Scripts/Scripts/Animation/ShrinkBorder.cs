using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkBorder : MonoBehaviour
{
    public float nextScale;
    public float destroySize;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        StartCoroutine(ShrinkUntilDeath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShrinkUntilDeath()
    {
        while (gameObject.transform.localScale.x > destroySize)
        {
            transform.localScale = new Vector3(transform.localScale.x * nextScale, transform.localScale.y *nextScale, transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        //Debug.Log("The final size was " + transform.localScale.x);
        Destroy(gameObject);

    }
}
