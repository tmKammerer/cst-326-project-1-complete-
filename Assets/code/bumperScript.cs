using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperScript : MonoBehaviour
{
    public float movementPerSec = 1f;
    public bool isLeft;
    float movementAxis;
    Vector3 force;

    public AudioClip bumperReact;
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

    public void OnCollisionEnter(Collision other)
    {
        

        var paddleBounds = GetComponent<BoxCollider>().bounds;
        float maxPaddleHeight = paddleBounds.max.z;
        float minPaddleHeight = paddleBounds.min.z;

        float pctHeight = (other.transform.position.z - minPaddleHeight) / (maxPaddleHeight - minPaddleHeight);
        float bounceDirection = (pctHeight - 0.5f) / 0.5f;

        Vector3 currentVelocity = other.relativeVelocity;
        float newSign = currentVelocity.x > 0 ? -1f : 1f;
        float newRotSign = newSign < 0f ? 1f : -1f;
        float newSpeed = currentVelocity.magnitude * 1.2f;
        Vector3 newVelocity = new Vector3(newSign, 0f, 0f) * newSpeed;
        newVelocity = Quaternion.Euler(0f, newRotSign * 60f * bounceDirection, 0f)*newVelocity;

        //Debug.Log(other.gameObject.name);
        AudioSource bumper = GetComponent<AudioSource>();

        if (other.rigidbody != null)
        {
            other.rigidbody.velocity = newVelocity;
            
            bumper.clip = bumperReact;
            bumper.Play();
        }
        


    }

    
}
