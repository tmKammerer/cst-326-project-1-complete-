using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowScript : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collider)
    {
        Destroy(this);
    }
}