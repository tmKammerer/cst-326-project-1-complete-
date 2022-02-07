using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{

    public float movementSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity= new Vector3(movementSpeed *sx, movementSpeed*sy, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;



        Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.yellow);

    }
}
