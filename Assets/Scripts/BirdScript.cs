using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 1f;
    private GameObject targ;
    public int TimeUntilDeath =  6;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("SpawnObstacles").GetComponent<GameManager>();
        StartCoroutine("KillBird");
        targ = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
            if(gameManager.isGameActive)
            {
                transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, .01f);
                transform.LookAt(Player);
            }
            
    }

    IEnumerator KillBird()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        
    }
}
