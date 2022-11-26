using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalliingRock : MonoBehaviour
{
    private GameManager gameManager;
    public AnimationCurve speed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("SpawnObstacles").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.isGameActive)
        {

            transform.Translate(Vector3.back * gameManager.Speed * Time.deltaTime);
            var euler = transform.eulerAngles;
            euler.x = Random.Range(0.0f, 360.0f);
            transform.eulerAngles = euler;
        }


    }


}
