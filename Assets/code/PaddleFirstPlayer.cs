using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleFirstPlayer : MonoBehaviour
{

    public float movementPerSec = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementAxis = Input.GetAxis("Horizontal");
        //Transform transform = GetComponent<transform>();

        Vector3 force = Vector3.up * movementAxis * movementPerSec*Time.deltaTime;
        
        Rigidbody rbody = GetComponent<Rigidbody>();
        if (rbody)
        {
            rbody.AddForce(force, ForceMode.VelocityChange);
        }

        //transform.position += Vector3.up * movementAxis*movementPerSec * Time.deltaTime;

        /* if (Input.GetKeyDown(KeyDown.W))
         {
             Transform transform = GetComponent<transform>();
             transform.position += Vector3.up*movementPerSec*Time.deltaTime;
         }

         if (Input.GetKeyDown(KeyDown.S))
         {
             Transform transform = GetComponent<transform>();
             transform.position += -Vector3.up * movementPerSec*Time.deltaTime;
         }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();
        float xCenter = bbox.bounds.center.x;
        Debug.Log("Center at: " + xCenter + "collided object at" + collision.transform.position.y);
        Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;
    }
}
