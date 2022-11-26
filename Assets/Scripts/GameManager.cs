using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public List<GameObject> Obstacle;
    [Header("Float Variables")]

    public float TImePassed;
    public float Speed = 2.5f;
    public float ObstacleSpawnTime;

    [Header("Text Variables")]
    private float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public Button restartButton;

    [Header("Bool Variables")]
    public bool AddedSpeed = false;
    [SerializeField] bool reduceSpwanTime = false;
    public bool isGameActive = false;




    // Start is called before the first frame update
    void Start()
    {

        Speed = 2.5f;
        ObstacleSpawnTime = 2f;
        TImePassed = 1;
        isGameActive = true;

        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnObstacle());
        GameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);



    }
    public void UpdateScore(float scoreToUpdate)
    {
        score += Mathf.Round(-1 * (scoreToUpdate / 10));
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {


        TImePassed += Time.deltaTime;
        
        if (Mathf.Round(TImePassed) % 15 == 0 && AddedSpeed == false && reduceSpwanTime == false)
        {
            Speed += 2f;
            ObstacleSpawnTime -= 0.15f;
            AddedSpeed = true;
            reduceSpwanTime = true;
            StartCoroutine("AddedSpeedBool");
        }





    }

    public void GameOver()
    {

        isGameActive = false;
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnObstacle()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(ObstacleSpawnTime);
            int index = Random.Range(0, Obstacle.Count);
            //Checks if the index is 2 so that it spawns right over a player
            if (index == 2)
            {
                Instantiate(Obstacle[index], new Vector3(Player.transform.position.x + Random.Range(5, 20), 10, -5), Obstacle[index].transform.rotation);
            }
            else
            {
                Instantiate(Obstacle[index],RandomPosition(), Obstacle[index].transform.rotation);
            }

        }
    }
    IEnumerator AddedSpeedBool()
    {
        yield return new WaitForSeconds(5);
        AddedSpeed = false;
        reduceSpwanTime = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    Vector3 RandomPosition()
    {
        float YPosition = Player.transform.position.y +  Random.Range(0, 6.5f);
        float XPosition = Player.transform.position.x + 20;

        return new Vector3(XPosition, YPosition, -5);
    }

}
