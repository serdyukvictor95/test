using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gameplay.ShipControllers.CustomControllers;
public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
   

    void Start ()
    {
        ResetGame();
        
    }
     void Update ()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetGame(){
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        score = 0;
        UpdateScore();
        gameOver = false;
    }

    private void OnEnable() 
    {        
        EnemyShipController.OnEnemyDestroyed += AddScore;
        PlayerShipController.OnPlayerDestroyed +=GameOver;
        
    }

    private void OnDisable() 
    {        
        EnemyShipController.OnEnemyDestroyed -= AddScore;
        PlayerShipController.OnPlayerDestroyed -=GameOver;
    }
  
    public void GameOver ()
    {
         gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gameOver = true;
    }

}