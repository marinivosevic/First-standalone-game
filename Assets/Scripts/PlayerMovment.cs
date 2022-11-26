using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5;
    private GameManager gameManager;
    private Rigidbody PlayerRb;
    private AudioSource Sound;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("SpawnObstacles").GetComponent<GameManager>();
        Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive == false)
        {
            PlayerRb.Sleep();
        }
        
        else
        {
            PlayerRb.WakeUp();
            if(Input.GetKey(KeyCode.Space))
            {
            PlayerRb.AddForce(Vector3.up * speed);
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
            PlayerRb.AddForce(Vector3.left * speed);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
            PlayerRb.AddForce(Vector3.right * speed);
            }
        }
        
        
    }
    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Obstacle")
        {
            Sound.PlayOneShot(clip, 0.7f);
            gameManager.GameOver();
            
        }
        
        
       
    }
}
