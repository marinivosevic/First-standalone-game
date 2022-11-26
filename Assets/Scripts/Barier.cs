using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("uslo");
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
        
        
       
    }
}
