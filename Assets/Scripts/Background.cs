using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float Speed = 5f;
    private Vector3 StartPosition;
    public int RestartPosition;
    [SerializeField] GameManager gameManager;
    
    void Start()
    {
        StartPosition = transform.position;
        gameManager = GameObject.Find("SpawnObstacles").GetComponent<GameManager>();
    }

   
    void Update()
    {
        if(gameManager.isGameActive)
        {
            gameManager.UpdateScore(transform.position.z);
            //Moving background untill it reaches desired position
            if(transform.position.z < RestartPosition)
            {
                transform.position = StartPosition;
            }
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            
        }
        
    }
}
