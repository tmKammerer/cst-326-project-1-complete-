using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperScript : MonoBehaviour
{
    public float movementPerSec = 1f;
    public bool isLeft;
    float movementAxis;
    Vector3 force;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {


        if (isLeft)
        {
            movementAxis = Input.GetAxis("Vertical");
            force = Vector3.up * movementAxis * movementPerSec * Time.deltaTime;
        }
        else
        {
            movementAxis= Input.GetAxis("Vertical2");
            force = Vector3.up * movementAxis * movementPerSec * Time.deltaTime;
        }
    
            

        Rigidbody rbody = GetComponent<Rigidbody>();
            if (rbody)
            {
                rbody.AddForce(force, ForceMode.VelocityChange);
            }

           
        
           


        
    }

    
}
