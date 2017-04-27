using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    public GameObject ball;
    
    public BlinkingScript blinkingScript;
    public SpawnBalconies spawnBalconies;
    public PlatformMovement platformMovement;

    public bool gameOver;
    public bool gamePaused;


    void Awake ()
    {
        ball.transform.position = spawnBalconies.balconies[0].transform.position;

        gamePaused = true;
        gameOver = false;
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Continue();
    }


    public void Pause()
    {
        Time.timeScale = 0.0f;
        gamePaused = true;
    }


    public void Continue()
    {
        Time.timeScale = 1.0f;
        gamePaused = false;
    }


    public void GameOver(bool isOver)
    {

        if(isOver==true)
        {
            gameOver = true;
            blinkingScript.StartBlinking();
            
            
        }

        else
        {
            gameOver = false;
        }

    }


    


}
