using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//will be responsible for: spawning hazards,

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    private int score;
    private void Start() //unity calls this very first frame this gameobject enabled 
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = ""; //at start turns off labels 
        score = 0;
        updateScore();
        StartCoroutine(SpawnWaves());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator SpawnWaves() //will instantiate our hazards   (CO-ROTINE) call by doing start corotine name
    {
        yield return new WaitForSeconds(startWait);  //give a little time for game to start before playing 
        while (true)  //infinite loop to spawn waves
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //z and y are single value cause dont need y and z constant
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }
    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        updateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }
}
