using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
    public static DragMovement Instance;
    public float movementMultiplier;
    bool movementEnabled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("There's too many Drag Movement Instances!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        movementEnabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveMovementVector(Vector3 recievedVelocityVector)
    {
        if (movementEnabled)
        {
            //Debug.Log(recievedVelocityVector);
            Vector3 interpretedMovementVector = new Vector3(recievedVelocityVector.x, 0f, recievedVelocityVector.z);
            transform.position += interpretedMovementVector * movementMultiplier;
        }

    }

    public void WallForce(Vector3 planeNormalVector)
    {
        transform.position += planeNormalVector * .08f;
    }

    public void DisableMovement()
    {
        movementEnabled = false;
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }
}
