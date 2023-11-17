using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }
    private int playerLives;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerLives = 5;
    }

    public int getPlayerLives(int lives)
    {
        playerLives = lives;
        return playerLives;
    }

    public void gameOver()
    {
        if(playerLives<=0)
        {
            Debug.Log("GAMEOVER");
            playerLives = 5;
            SceneManager.LoadScene(0);
        }
    }
    public void Update()
    {
       
        gameOver();
    }
}
