using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int lives = 3;
    public Text livesText;
    int numOfBricks;
    bool gameOver;

    public GameObject GameOverUI;
    void Awake()
    {
        livesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
    }

    private void Update()
    {
        if(gameOver && Input.anyKeyDown)
        {
            Restart();
        }
    }
    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            GameOver();
        }
    }

    public void HitBrick()
    {
        numOfBricks--;
        if (numOfBricks == 0)
        {
            Invoke("NextLevel", 1f);
        }
    }

    private void GameOver()
    {
        gameOver = true;
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    private void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
        
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }


}
