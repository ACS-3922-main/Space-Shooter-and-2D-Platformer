using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public int score = 0;
    public int lives = 30000;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    private int gameWinScore = 900;
    [SerializeField] private Text gameOverText;
    private GameObject ship;


    void Start() {
        ship = GameObject.Find("Ship");
    }

    public void Hit() {
        this.score +=10; 
        if(this.score < gameWinScore)
        {
            scoreText.text = "Score: " + score ;
        }
        else
        {
            GameOver();
        }
    }

    public void Miss() {
        this.lives--;
        if(this.lives > 0)
        {
            livesText.text = "Lives: " + lives ;
        }
        else
        {
            livesText.text = "Lives: 0";
            GameOver();
        }
    }

    public void GameOver() {
        if (score == gameWinScore) {
            gameOverText.text = "PLAYER WINS";
        }
        else if (lives == 0) {
           Destroy(ship);
           gameOverText.text = "PLAYER LOSES";
        }
        gameOverText.gameObject.SetActive(true);
    }
}
