using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject powerupPrefab;

    [SerializeField]
    private float enemiesInterval = 3f;

    private const float X_RANGE_POSITION = 7f;

    public static GameManager instance;
    private bool isGameOver;
    private bool isSpawnEnemies;

    private int score;

    public void AddScore(int pts)
    {
        this.score += pts;
        Debug.Log("Score: " + this.score);
        UIManager.instance.UpdateScore(score);
        CheckForPowerUp();
    }

    private void CheckForPowerUp()
    {
        int number = Random.Range(1, 11);   
        if(number > 5)
        {
            // Instanciar power up
        }
    }


    public void GameOver()
    {
        isGameOver = true;
        StopSpawnEnemies();
        UIManager.instance.ShowMenuUI();
    }

    private void StartSpawnEnemies()
    {
        isSpawnEnemies = true;
        StartCoroutine(SpawnEnemies());
    }

    private void StopSpawnEnemies()
    {
        isSpawnEnemies = false;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isGameOver = true;
        isSpawnEnemies = false;
        UIManager.instance.ShowMenuUI();
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            isGameOver = false;
            StartSpawnEnemies();
            Instantiate(playerPrefab);
            this.score = 0;
            UIManager.instance.ShowGameUI();
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (isSpawnEnemies)
        {
            Vector3 newPosition = new Vector3(
               Random.Range(-X_RANGE_POSITION, X_RANGE_POSITION), 
                this.transform.position.y,
                0f
                );

            Instantiate(enemyPrefab, newPosition, this.transform.rotation);

            yield return new WaitForSeconds(enemiesInterval);
        }

    }


}
