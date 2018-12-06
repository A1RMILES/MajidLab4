using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //1 Global Access
    public static GameManager Instance;

    //2 amount of gold collected
    public int gold;

    //3 number of the wave being spawned
    public int waveNumber;

    //4 amount of enemies that escaped
    public int escapedEnemies;

    //5 amount of enemies escaped before you lose
    public int maxAllowedEscapedEnemies = 5;

    //6 set to true to see if player wins
    public bool enemySpawningOver;

    //7 
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;

    //8 set true if game over
    private bool gameOver;

    //1
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        //2
        if (!gameOver && enemySpawningOver)
        {
            // Check if no enemies left, if so win game
            //3
            if (EnemyManager.Instance.Enemies.Count == 0)
            {
                OnGameWin();
                UIManager.Instance.ShowWinScreen();
            }
        }
        // When ESC is pressed, quit to the title screen
        //4
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }
    //5
    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound,
        Camera.main.transform.position);
        gameOver = true;
    }
    //6
    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    //1
    public void OnEnemyEscape()
    {
        escapedEnemies++;
        UIManager.Instance.ShowDamage();
        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
            // Too many enemies escaped, you lose the game
            OnGameLose();
            UIManager.Instance.ShowLoseScreen();
        }
    }
    //2
    private void OnGameLose()
    {
        gameOver = true;
        AudioSource.PlayClipAtPoint(gameLoseSound,
        Camera.main.transform.position);
        EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();
    }
    //3
    public void RetryLevel()
    {
        SceneManager.LoadScene("Game");
    }
	
}
