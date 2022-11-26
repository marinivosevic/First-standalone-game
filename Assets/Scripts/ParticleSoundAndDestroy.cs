using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSoundAndDestroy : MonoBehaviour
{
    private AudioSource sound;
    public AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        StartCoroutine(destoryD());
    }

    // Update is called once per frame
    void Update()
    {
        sound.PlayOneShot(boom,0.9f);
        
    }
    IEnumerator destoryD(){
        yield return new WaitForSeconds(2);
        Destroy(transform.gameObject);
    }
}

