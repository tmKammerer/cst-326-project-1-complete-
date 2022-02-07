using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int left;
    public int right;
    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isLeft)
        {
            right++;
        }
        else
        {
            left++;
        }

        Debug.Log("P1: "+left+" P2:"+right);

        if (left == 5)
        {
            Debug.Log("P1 wins!\n");
        }else if (right == 5)
        {
            Debug.Log("P2 wins!\n");
        }
    }
}
