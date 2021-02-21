using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardForLifetime : MonoBehaviour
{
    public float speed;
    public float lifetime;
    float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
