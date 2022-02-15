using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{

    public float movementSpeed = 3f;

    private Rigidbody ballGo;
    public AudioClip ballScream;
    public AudioClip ballSlow;
    public AudioClip ballFast;

    public GameObject spawnPoint;
    private float sx;
    private float sy;
    public GameObject pillF;
    public GameObject pillS;
    // Start is called before the first frame update
    void Start()
    {
         sx = Random.Range(0, 2) == 0 ? -1 : 1;
         sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity= new Vector3(movementSpeed *sx, movementSpeed*sy, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 direction = new Vector3(0, 0, 0);

        ContactPoint contact = collision.GetContact(0);

        if (contact.point.x > collision.transform.position.x)
        {
            direction = new Vector3(0, 0, 1);
        }
        else
        {
            direction = new Vector3(0, 0, -1);
        }

        Rigidbody ballVel = this.GetComponent<Rigidbody>();
        ballVel.AddForce(ballVel.velocity / 5, ForceMode.VelocityChange);


       // Debug.Log(ballVel);
        
        
        //ballVel.AddForce(direction)



        //Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;



        // Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.yellow);
        


    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "fast")
        {
            float newSpeed = 6f;
            GetComponent<Rigidbody>().velocity = new Vector3(newSpeed * sx, newSpeed * sy, 0f);
            AudioSource speed = GetComponent<AudioSource>();
            speed.clip = ballFast;
            speed.Play();
            Destroy(pillF,0.5f);
        }
        else if (collider.tag == "slow")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed * sx, movementSpeed * sy, 0f);
            AudioSource speed = GetComponent<AudioSource>();
            speed.clip = ballSlow;
            speed.Play();
            Destroy(pillS,0.5f);
        }
        else if(collider.tag=="goal")
        {
            AudioSource ball = GetComponent<AudioSource>();
            ball.clip = ballScream;
            ball.Play();
            Vector3 origin = new Vector3(0, 7, 0);
            this.transform.position = spawnPoint.transform.position;

            sx = Random.Range(0, 2) == 0 ? -1 : 1;
            sy = Random.Range(0, 2) == 0 ? -1 : 1;

            GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed * sx, movementSpeed * sy, 0f);
        }
    }
}
