using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // general
    public bool isGameRunning = false;
    public bool gameOver = false;

    public static GameManager instance;

    // end level stuff
    [SerializeField]
    private GameObject endLevelMenu;

    // game over stuff
    [SerializeField]
    private GameObject gameOverMenu;


    // coin stuff
    [SerializeField]
    private TMP_Text coinCountText;
    private int coinCount;

    // score stuff
    [SerializeField]
    private TMP_Text scoreText;
    private int score;

    // ui parts to set false after load scene or gameover
    [SerializeField]
    private GameObject[] uiParts;

    // score related methods
    public void IncrementScoreByAmount(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    
    public int GetCoinCount()
    {
        return coinCount;
    }

    public void IncrementCoinByAmount(int amount)
    {
        coinCount += amount;
        coinCountText.text = (coinCount).ToString();
    }


    // this is about make this GamaManger exist during the whole game
    private void Awake()
    {
        // Singleton Zımbırtısı
        // Eğer ilk defa giriyorsa bir scene'e,
        // GameManager Instance'ı olmadığı için atama yapıyoruz
        if (instance == null || instance == this)
        {
            instance = this;
            // DontDestroyOnLoad(this);
        }
        else
        {
            // Eğer null değilse zaten daha önce girilmiş
            // ve buranın instance'ı var demektir
            Destroy(this.gameObject);
        }

    }

    // this is for to start game when the the screen is tapped
    public void StartGame()
    {
        isGameRunning = true;
        gameOver = false;
    }


    public void GameOver()
    {
        gameOver = true;
        isGameRunning = false;

        gameOverMenu.SetActive(true);

        HideUIParts();
    }

    public void EndLevel()
    {
        isGameRunning = false;

        endLevelMenu.SetActive(true);
        HideUIParts();
    }

    private void HideUIParts()
    {
        foreach (var part in uiParts)
        {
            part.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        catch
        {
            Debug.LogError("Couldn't reload the scene");
        }
    }

    public void LoadNextLevel()
    {
        // for now lets just use reset
        ResetLevel();


        //try
        //{
        //    int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        //catch
        //{
        //    Debug.LogError("The Index of the next scene that you wanted to load, doesn't exist");
        //}

    }

}
