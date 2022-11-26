using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private GameManager gameManager;
    private float speed = 4f;
    public float delay = 2.5f;
    [SerializeField] float countdown;
    bool hasExploded = false;
    public GameObject ExplosionParticle;
    public float radius;
    private AudioSource sound;
    public AudioClip boom;
  
    private float volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        countdown = randomExplosionTime();
        gameManager = GameObject.Find("SpawnObstacles").GetComponent<GameManager>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Sound();
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * gameManager.Speed * Time.deltaTime);
            
        }
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !hasExploded)
        {
            
            explode();
            hasExploded = true;
            
        }

    }

    void explode()
    {
        Instantiate(ExplosionParticle, transform.position, transform.rotation);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i]);
            if (colliders[i].tag == "Player")
            {
                Destroy(colliders[i].gameObject);
                gameManager.GameOver();
            }


        }
        
        Destroy(gameObject);
        destroyParticle();

    }
    IEnumerator Sound(){
        yield return new WaitForSeconds(1);
        sound.PlayOneShot(boom,0.9f);
    }

    IEnumerator destroyParticle()
    {
        yield return new WaitForSeconds(2);
        Destroy(ExplosionParticle);

    }

    float randomExplosionTime(){
        float delay = Random.Range(1,2.5f);

        return delay;
    }

}
