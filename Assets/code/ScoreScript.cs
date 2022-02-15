using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int left;
    public int right;

    public bool isLeft;

    public AudioClip scoreSound;
    public AudioClip getOut;

    public TextMeshProUGUI scoreLeft;
    public TextMeshProUGUI scoreRight;

    [SerializeField] private Transform ball;
    [SerializeField] private Transform spawn;

    public GameObject bally;
    public float movementSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        scoreLeft.text = $"{left}";
        scoreRight.text = $"{right}";
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
            scoreRight.text = $"{right}";
            scoreRight.color = new Color(255, 0, 0);
            scoreLeft.color = new Color(255, 0, 0);
            ball.transform.position = spawn.transform.position;
            float sx = Random.Range(0, 2) == 0 ? -1 : 1;
            float sy = Random.Range(0, 2) == 0 ? -1 : 1;
            ball.GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed * sx, movementSpeed * sy, 0f);
        }
        else
        {
            left++;
            scoreLeft.text = $"{left}";
            scoreLeft.color = new Color(0, 0, 255);
            scoreRight.color = new Color(0, 0, 255);
            ball.transform.position = spawn.transform.position;
            float sx = Random.Range(0, 2) == 0 ? -1 : 1;
            float sy = Random.Range(0, 2) == 0 ? -1 : 1;
            ball.GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed * sx, movementSpeed * sy, 0f);
        }

        Debug.Log("P1: "+left+" P2:"+right);

        if (left == 5)
        {
            scoreLeft.text = $"P1 Wins!";
            scoreRight.text = $"P1 Wins!";
            scoreRight.color = new Color(255, 0, 0);
            scoreLeft.color = new Color(255, 0, 0);
            Debug.Log("P1 wins!\n");
            Destroy(bally,0.001f);
            AudioSource win = GetComponent<AudioSource>();
            win.clip = getOut;
            win.Play();
        }else if (right == 5)
        {
            scoreLeft.text = $"P2 Wins!";
            scoreRight.text = $"P2 Wins!";
            scoreLeft.color = new Color(0, 0, 255);
            scoreRight.color = new Color(0, 0, 255);
            Debug.Log("P2 wins!\n");
            Destroy(bally,0.001f);
            AudioSource win = GetComponent<AudioSource>();
            win.clip = getOut;
            win.Play();
        }
        AudioSource score = GetComponent<AudioSource>();
        score.clip = scoreSound;
        score.Play();


        
    }
}
